import os
import re

def fix_file_syntax(file_path):
    with open(file_path, 'r', encoding='utf-8') as f:
        content = f.read()

    # Fix missing brackets
    content = re.sub(r'(\w+\s+\w+\s*\([^)]*\))\s*(?!\{)', r'\1 {', content)

    # Fix invalid modifiers
    content = re.sub(r'(public|private)\s+(void|async\s+Task)\s+(\w+)\s*\(', r'\1 \2 \3(', content)

    # Ensure proper method closure
    content = re.sub(r'(\w+\s+\w+\s*\([^)]*\)\s*{[^}]*$)', r'\1\n}', content)

    with open(file_path, 'w', encoding='utf-8') as f:
        f.write(content)

def process_directory(directory):
    for root, _, files in os.walk(directory):
        for file in files:
            if file.endswith('.cs'):
                file_path = os.path.join(root, file)
                fix_file_syntax(file_path)

# Process specific files mentioned in errors
files_to_fix = [
    'Orchard.Web/Modules/Orchard.MessageBus/Services/DistributedShellStarter.cs',
    'Orchard.Web/Modules/Orchard.Azure/Services/FileSystems/AzureFileSystem.cs',
    'Orchard.Web/Modules/Orchard.Layouts/Drivers/LayoutPartDriver.cs',
    'Orchard.Web/Modules/Orchard.MessageBus/Services/DistributedShellTrigger.cs'
]

for file_path in files_to_fix:
    if os.path.exists(file_path):
        fix_file_syntax(file_path)
