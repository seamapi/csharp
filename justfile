# Build the package
build:
    dotnet pack --configuration Release --output pkg ./output/csharp/src/Seam

# Run the tests
test framework="":
    dotnet test ./output/csharp {{ if framework == "" { "" } else { "--framework " + framework } }}

# Lint
lint:
    dotnet csharpier --check ./output/csharp

# Format
format:
    dotnet csharpier ./output/csharp
