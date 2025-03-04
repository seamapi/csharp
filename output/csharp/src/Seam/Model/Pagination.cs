using System.Runtime.Serialization;
using System.Text;
using JsonSubTypes;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Linq;
using Seam.Model;

namespace Seam.Model
{
    [DataContract(Name = "seamModel_pagination_model")]
    public class Pagination
    {
        [JsonConstructorAttribute]
        protected Pagination() { }

        public Pagination(
            bool hasNextPage = default,
            string? nextPageCursor = default,
            string? nextPageUrl = default
        )
        {
            HasNextPage = hasNextPage;
            NextPageCursor = nextPageCursor;
            NextPageUrl = nextPageUrl;
        }

        [DataMember(Name = "has_next_page", IsRequired = true, EmitDefaultValue = false)]
        public bool HasNextPage { get; set; }

        [DataMember(Name = "next_page_cursor", IsRequired = false, EmitDefaultValue = false)]
        public string? NextPageCursor { get; set; }

        [DataMember(Name = "next_page_url", IsRequired = false, EmitDefaultValue = false)]
        public string? NextPageUrl { get; set; }

        public override string ToString()
        {
            JsonSerializer jsonSerializer = JsonSerializer.CreateDefault(null);

            StringWriter stringWriter = new StringWriter(
                new StringBuilder(256),
                System.Globalization.CultureInfo.InvariantCulture
            );
            using (JsonTextWriter jsonTextWriter = new JsonTextWriter(stringWriter))
            {
                jsonTextWriter.IndentChar = ' ';
                jsonTextWriter.Indentation = 2;
                jsonTextWriter.Formatting = Formatting.Indented;
                jsonSerializer.Serialize(jsonTextWriter, this, null);
            }

            return stringWriter.ToString();
        }
    }
}
