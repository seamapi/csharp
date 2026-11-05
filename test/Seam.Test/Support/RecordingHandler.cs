using System.Net;
using System.Text;

namespace Seam.Test.Support;

/// <summary>
/// An innermost <see cref="HttpMessageHandler"/> serving canned responses while recording every
/// attempt that reaches it.
/// </summary>
/// <remarks>
/// Use this only for the things the fake server cannot do: asserting what goes out on the wire,
/// counting retries, and serving malformed or delayed responses. Because it replaces the real
/// socket handler, every retry attempt is recorded, so <see cref="AttemptCount"/> counts
/// attempts, retries included. The last planned response repeats; with no plan every attempt
/// gets 200 <c>{}</c>.
/// </remarks>
public sealed class RecordingHandler : HttpMessageHandler
{
    private readonly List<Func<CancellationToken, Task<HttpResponseMessage>>> _plan = new();

    private int _next;

    public List<RecordedRequest> Requests { get; } = new();

    public int AttemptCount => Requests.Count;

    public RecordingHandler RespondWith(
        HttpStatusCode statusCode,
        string body = "{}",
        string contentType = "application/json",
        IReadOnlyDictionary<string, string>? headers = null
    )
    {
        _plan.Add((_) => Task.FromResult(CreateResponse(statusCode, body, contentType, headers)));

        return this;
    }

    /// <summary>Fails the attempt with a transport error.</summary>
    public RecordingHandler FailWith(Exception exception)
    {
        _plan.Add((_) => Task.FromException<HttpResponseMessage>(exception));

        return this;
    }

    /// <summary>
    /// Delays the response so the attempt outlives a shorter per-attempt timeout.
    /// </summary>
    public RecordingHandler RespondAfter(
        TimeSpan delay,
        HttpStatusCode statusCode,
        string body = "{}"
    )
    {
        _plan.Add(
            async (cancellationToken) =>
            {
                await Task.Delay(delay, cancellationToken);

                return CreateResponse(statusCode, body, "application/json", null);
            }
        );

        return this;
    }

    protected override async Task<HttpResponseMessage> SendAsync(
        HttpRequestMessage request,
        CancellationToken cancellationToken
    )
    {
        var body =
            request.Content == null
                ? ""
                : await request.Content.ReadAsStringAsync(cancellationToken);

        var headers = new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase);
        foreach (var (name, values) in request.Headers)
        {
            headers[name] = string.Join(",", values);
        }
        if (request.Content != null)
        {
            foreach (var (name, values) in request.Content.Headers)
            {
                headers[name] = string.Join(",", values);
            }
        }

        Requests.Add(new RecordedRequest(request.Method, request.RequestUri!, body, headers));

        if (_plan.Count == 0)
            return CreateResponse(HttpStatusCode.OK, "{}", "application/json", null);

        var producer = _plan[Math.Min(_next, _plan.Count - 1)];
        _next++;

        return await producer(cancellationToken);
    }

    private static HttpResponseMessage CreateResponse(
        HttpStatusCode statusCode,
        string body,
        string contentType,
        IReadOnlyDictionary<string, string>? headers
    )
    {
        var response = new HttpResponseMessage(statusCode)
        {
            Content = new StringContent(body, Encoding.UTF8, contentType),
        };

        if (headers != null)
        {
            foreach (var (name, value) in headers)
            {
                response.Headers.TryAddWithoutValidation(name, value);
            }
        }

        return response;
    }
}

public sealed record RecordedRequest(
    HttpMethod Method,
    Uri Uri,
    string Body,
    IReadOnlyDictionary<string, string> Headers
);
