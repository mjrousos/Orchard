#!/bin/bash

# Find all .csproj files
find . -name "*.csproj" -type f | while read -r project; do
    echo "Processing $project..."

    # Create backup
    cp "$project" "${project}.bak"

    # Remove WebApplication.targets import
    sed -i '/<Import Project=".*WebApplication.targets"/d' "$project"

    # Update target framework to net8.0
    sed -i 's/<TargetFramework>.*<\/TargetFramework>/<TargetFramework>net8.0<\/TargetFramework>/' "$project"

    # Add Microsoft.NET.Sdk.Web SDK reference if it's a web project
    if grep -q "Microsoft.WebApplication.targets" "${project}.bak"; then
        sed -i 's/Sdk="Microsoft.NET.Sdk"/Sdk="Microsoft.NET.Sdk.Web"/' "$project"
    fi
done
