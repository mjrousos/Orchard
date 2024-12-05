import os
import xml.etree.ElementTree as ET
import glob
from xml.dom import minidom

def prettify_xml(elem):
    """Return a pretty-printed XML string for the Element."""
    rough_string = ET.tostring(elem, 'utf-8')
    reparsed = minidom.parseString(rough_string)
    return reparsed.toprettyxml(indent="  ")

def fix_project_file(filepath):
    try:
        # Try to parse existing content
        try:
            tree = ET.parse(filepath)
            root = tree.getroot()
        except:
            # If parsing fails, create new structure
            root = ET.Element('Project')
            root.set('Sdk', 'Microsoft.NET.Sdk')

        # Ensure PropertyGroup with TargetFramework exists
        property_groups = root.findall('PropertyGroup')
        target_framework_found = False

        for prop_group in property_groups:
            tf = prop_group.find('TargetFramework')
            if tf is not None:
                tf.text = 'net8.0'
                target_framework_found = True
                break

        if not target_framework_found:
            prop_group = ET.SubElement(root, 'PropertyGroup')
            tf = ET.SubElement(prop_group, 'TargetFramework')
            tf.text = 'net8.0'

        # Preserve ItemGroup elements with ProjectReference and PackageReference
        new_root = ET.Element('Project')
        new_root.set('Sdk', 'Microsoft.NET.Sdk')

        # Copy PropertyGroup
        for prop_group in root.findall('PropertyGroup'):
            new_root.append(prop_group)

        # Copy ItemGroups with references
        for item_group in root.findall('ItemGroup'):
            if len(item_group.findall('ProjectReference')) > 0 or len(item_group.findall('PackageReference')) > 0:
                new_root.append(item_group)

        # Write the fixed content
        with open(filepath, 'w', encoding='utf-8') as f:
            f.write('<?xml version="1.0" encoding="utf-8"?>\n')
            f.write(prettify_xml(new_root))

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
