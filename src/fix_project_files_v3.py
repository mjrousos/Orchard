import os
import glob

def fix_project_file(filepath):
    try:
        with open(filepath, 'r', encoding='utf-8') as f:
            content = f.read()

        # Remove all XML declarations
        lines = content.split('\n')
        filtered_lines = [line for line in lines if not line.strip().startswith('<?xml')]

        # Add single XML declaration at the start
        final_content = '<?xml version="1.0" encoding="utf-8"?>\n'

        # Add Project SDK if not present
        if not any('Sdk="Microsoft.NET.Sdk"' in line for line in filtered_lines):
            final_content += '<Project Sdk="Microsoft.NET.Sdk">\n'

            # Add basic structure if needed
            if not any('<PropertyGroup>' in line for line in filtered_lines):
                final_content += '  <PropertyGroup>\n'
                final_content += '    <TargetFramework>net8.0</TargetFramework>\n'
                final_content += '  </PropertyGroup>\n'

            # Add remaining content
            final_content += '\n'.join(line for line in filtered_lines if not line.strip().startswith('<Project'))

            # Ensure project tag is closed
            if not any('</Project>' in line for line in filtered_lines):
                final_content += '\n</Project>'
        else:
            final_content += '\n'.join(filtered_lines)

        with open(filepath, 'w', encoding='utf-8') as f:
            f.write(final_content)

        print(f"Successfully processed {filepath}")

    except Exception as e:
        print(f"Error processing {filepath}: {str(e)}")

def main():
    # Find all .csproj files
    project_files = glob.glob('**/*.csproj', recursive=True)

    for proj_file in project_files:
        print(f"Processing {proj_file}")
        fix_project_file(proj_file)

if __name__ == "__main__":
    main()
