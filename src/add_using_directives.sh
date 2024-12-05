#!/bin/bash

# Add common using directives to files
find . -name "*.cs" -type f -exec sed -i '1i\using Orchard.ContentManagement;\nusing Orchard.Security;\nusing Orchard.UI.Admin;\nusing Orchard.DisplayManagement;\nusing Orchard.Localization;\nusing Orchard.Services;\nusing System.Web.Mvc;\nusing Orchard.Mvc.Filters;' {} \;

# Remove duplicate using directives
for file in $(find . -name "*.cs"); do
  awk '!seen[$0]++' "$file" > "${file}.tmp" && mv "${file}.tmp" "$file"
done
