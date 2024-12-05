#!/bin/bash
find . -name "AssemblyInfo.cs" -type f | while read -r file; do
    dir=$(dirname "$file")
    if grep -q '<Project Sdk="Microsoft.NET.Sdk">' "$dir"/*.csproj 2>/dev/null; then
        echo "Removing $file (SDK-style project)"
        rm "$file"
    fi
done
