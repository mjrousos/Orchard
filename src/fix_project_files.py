import os
import xml.etree.ElementTree as ET
import glob

def fix_project_file(filepath):
    # Read the file content
    with open(filepath, 'r', encoding='utf-8') as f:
        content = f.read()

    # Remove old XML declaration and Project elements
    lines = content.split('\n')
    filtered_lines = []
    in_project = False
    for line in lines:
        if '<?xml' in line:
            continue
        if '<Project ' in line:
            if 'Sdk="Microsoft.NET.Sdk"' in line or 'Sdk="Microsoft.NET.Sdk.Web"' in line:
                filtered_lines.append(line)
                in_project = True
            continue
        if '</Project>' in line:
            if in_project:
                filtered_lines.append(line)
            continue
        if in_project:
            filtered_lines.append(line)

    # If no SDK-style Project element was found, add one
    if not any('Sdk="Microsoft.NET.Sdk"' in line for line in filtered_lines):
        filtered_lines.insert(0, '<Project Sdk="Microsoft.NET.Sdk">')
        if not any('</Project>' in line for line in filtered_lines):
            filtered_lines.append('</Project>')

    # Update target framework
    has_target_framework = False
    for i, line in enumerate(filtered_lines):
        if '<TargetFramework>' in line:
            filtered_lines[i] = '    <TargetFramework>net8.0</TargetFramework>'
            has_target_framework = True
            break

    if not has_target_framework:
        # Add PropertyGroup if not present
        if not any('<PropertyGroup>' in line for line in filtered_lines):
            insert_pos = 1  # After Project element
            filtered_lines.insert(insert_pos, '  <PropertyGroup>')
            filtered_lines.insert(insert_pos + 1, '    <TargetFramework>net8.0</TargetFramework>')
            filtered_lines.insert(insert_pos + 2, '  </PropertyGroup>')

    # Write back the fixed content
    with open(filepath, 'w', encoding='utf-8') as f:
        f.write('\n'.join(filtered_lines))

def main():
    # Find all .csproj files
    project_files = glob.glob('**/*.csproj', recursive=True)

    for proj_file in project_files:
        print(f"Processing {proj_file}")
        try:
            fix_project_file(proj_file)
        except Exception as e:
            print(f"Error processing {proj_file}: {e}")

if __name__ == "__main__":
    main()
