#!/bin/bash

# Find all module project files
find ./Orchard.Web/Modules -name "*.csproj" -type f | while read -r project; do
    echo "Processing $project..."

    # Create backup
    cp "$project" "${project}.bak"

    # Update target framework to net8.0
    sed -i 's/<TargetFramework>.*<\/TargetFramework>/<TargetFramework>net8.0<\/TargetFramework>/' "$project"
    sed -i 's/<TargetFrameworkVersion>.*<\/TargetFrameworkVersion>/<TargetFramework>net8.0<\/TargetFramework>/' "$project"

    # Remove old framework references
    sed -i '/<Reference Include="System/d' "$project"
    sed -i '/<Reference Include="Microsoft.CSharp"/d' "$project"

    # Update to SDK-style project format if needed
    if ! grep -q "Sdk=\"Microsoft.NET.Sdk\"" "$project"; then
        sed -i '1i<Project Sdk="Microsoft.NET.Sdk">' "$project"
        sed -i '/<Project/! {/<?xml/d}' "$project"
        sed -i '/<Project [^>]*>/d' "$project"
    fi
done

# Run the script
chmod +x update_module_projects.sh && \
./update_module_projects.sh && \
git add . && \
git commit -m "Update module projects to target .NET 8.0" && \
dotnet restore Orchard.sln && \
dotnet build Orchard.sln
