#!/bin/bash

# Function to fix validation rule files
fix_validation_file() {
    local file="$1"
    # Create backup
    cp "$file" "${file}.bak"

    # Fix common syntax issues:
    # 1. Move private methods outside of public methods
    # 2. Add missing closing braces
    # 3. Fix method nesting
    awk '
    BEGIN {
        in_class = 0
        brace_count = 0
        buffer = ""
        private_methods = ""
    }

    /^[[:space:]]*public class/ { in_class = 1 }

    /^[[:space:]]*private/ {
        if (buffer != "") {
            print buffer
            buffer = ""
        }
        private_methods = private_methods $0 "\n"
        next
    }

    /^[[:space:]]*{/ { brace_count++ }
    /^[[:space:]]*}/ { brace_count-- }

    {
        if ($0 ~ /^[[:space:]]*private/) {
            private_methods = private_methods $0 "\n"
        } else {
            buffer = buffer $0 "\n"
        }
    }

    END {
        print buffer
        print private_methods
        # Add missing closing braces
        while (brace_count > 0) {
            print "    }"
            brace_count--
        }
    }
    ' "$file" > "${file}.tmp"

    mv "${file}.tmp" "$file"
}

# Process all validation rule files
find . -path "*/ValidationRules/*.cs" -type f | while read -r file; do
    echo "Fixing $file..."
    fix_validation_file "$file"
done

# Process all validator files
find . -path "*/Validators/*.cs" -type f | while read -r file; do
    echo "Fixing $file..."
    fix_validation_file "$file"
done
