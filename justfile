# Build the package
build:
    dotnet pack --configuration Release --output pkg ./src/Seam

# Run the tests
test framework="":
    dotnet test ./Seam.sln --settings coverlet.runsettings {{ if framework == "" { "" } else { "--framework " + framework } }}

# Lint
lint:
    dotnet csharpier --check --include-generated ./src ./test

# Format
format:
    dotnet csharpier --include-generated ./src ./test
