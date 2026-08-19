# Build the package
build:
    dotnet pack --configuration Release --output pkg ./src/Seam

# Run the tests
test framework="":
    dotnet test ./Seam.sln {{ if framework == "" { "" } else { "--framework " + framework } }}

# Lint
lint:
    dotnet csharpier --check ./src

# Format
format:
    dotnet csharpier ./src
