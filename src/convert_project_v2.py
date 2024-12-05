import os
import sys
import logging
import traceback
import xml.etree.ElementTree as ET
from pathlib import Path

logging.basicConfig(level=logging.DEBUG, format='%(asctime)s - %(levelname)s - %(message)s')
logger = logging.getLogger(__name__)

def is_test_project(file_path):
    """Determine if a project is a test project based on file path or content"""
    return 'Tests' in file_path or 'Test' in file_path

def map_package_to_core(package_id, version):
    """Map ASP.NET packages to their ASP.NET Core equivalents"""
    mappings = {
        "Microsoft.AspNet.Mvc": ("Microsoft.AspNetCore.Mvc", "8.0.0"),
        "Microsoft.AspNet.Razor": ("Microsoft.AspNetCore.Razor", "8.0.0"),
        "Microsoft.AspNet.WebPages": ("Microsoft.AspNetCore.Mvc.ViewFeatures", "8.0.0"),
        "Microsoft.Web.Infrastructure": None,  # Not needed in ASP.NET Core
        "Microsoft.CodeDom.Providers.DotNetCompilerPlatform": None,  # Not needed in ASP.NET Core
        "NUnit": ("NUnit", "3.14.0"),
        "NUnit.ConsoleRunner": ("NUnit.ConsoleRunner", "3.16.3"),
        "NUnit3TestAdapter": ("NUnit3TestAdapter", "4.5.0"),
        "Autofac": ("Autofac", "7.1.0"),
        "Autofac.Configuration": ("Autofac.Configuration", "6.0.0"),
        "Castle.Core": ("Castle.Core", "5.1.1"),
        "log4net": ("Microsoft.Extensions.Logging.Log4Net.AspNetCore", "7.0.0"),
        "Newtonsoft.Json": ("Newtonsoft.Json", "13.0.3"),
        "Microsoft.Extensions.DependencyInjection": ("Microsoft.Extensions.DependencyInjection", "8.0.0"),
        "Microsoft.Extensions.Configuration": ("Microsoft.Extensions.Configuration", "8.0.0"),
        "Microsoft.Extensions.Logging": ("Microsoft.Extensions.Logging", "8.0.0"),
        "Microsoft.AspNetCore.Mvc.ViewFeatures": ("Microsoft.AspNetCore.Mvc.ViewFeatures", "8.0.0"),
        "Microsoft.AspNetCore.Http": ("Microsoft.AspNetCore.Http", "8.0.0"),
        "Microsoft.AspNetCore.Http.Abstractions": ("Microsoft.AspNetCore.Http.Abstractions", "8.0.0"),
        "Microsoft.AspNetCore.Routing": ("Microsoft.AspNetCore.Routing", "8.0.0")
    }
    return mappings.get(package_id, (package_id, version))

def extract_package_references(project_file):
    """Extract package references from packages.config"""
    packages_config = os.path.join(os.path.dirname(project_file), "packages.config")
    references = []

    if os.path.exists(packages_config):
        try:
            tree = ET.parse(packages_config)
            root = tree.getroot()
            for package in root.findall(".//package"):
                references.append({
                    "Include": package.get("id"),
                    "Version": package.get("version")
                })
        except Exception as e:
            logger.error(f"Error parsing packages.config: {str(e)}")

    return references

def extract_project_references(root):
    """Extract project references from csproj file"""
    refs = []
    for ref in root.findall(".//{http://schemas.microsoft.com/developer/msbuild/2003}ProjectReference"):
        refs.append(ref.get('Include'))
    return refs

def convert_to_sdk_style(file_path):
    print(f"Converting {file_path} to SDK style")
    is_test = is_test_project(file_path)

    # Create backup
    backup_path = f"{file_path}.bak"
    if not os.path.exists(backup_path):
        with open(file_path, 'r', encoding='utf-8') as f:
            with open(backup_path, 'w', encoding='utf-8') as backup:
                backup.write(f.read())

    try:
        # Parse original project file
        try:
            tree = ET.parse(file_path)
            root = tree.getroot()

            # Extract existing properties
            properties = {}
            for prop_group in root.findall(".//{http://schemas.microsoft.com/developer/msbuild/2003}PropertyGroup"):
                for prop in prop_group:
                    if prop.text:
                        properties[prop.tag.split('}')[-1]] = prop.text
        except ET.ParseError as e:
            logger.warning(f"XML parsing error: {str(e)}. Continuing with default properties.")
            properties = {}

        # Get package references and map them to Core equivalents
        package_refs = extract_package_references(file_path)
        mapped_refs = []
        for ref in package_refs:
            mapped = map_package_to_core(ref["Include"], ref["Version"])
            if mapped:
                mapped_refs.append({"Include": mapped[0], "Version": mapped[1]})

        project_refs = []
        try:
            project_refs = extract_project_references(root)
        except:
            logger.warning("Failed to extract project references. Continuing without them.")

        # Create SDK-style content
        sdk_type = "Microsoft.NET.Sdk.Web" if "Web" in file_path else "Microsoft.NET.Sdk"
        sdk_content = f"""<Project Sdk="{sdk_type}">
  <PropertyGroup>
    <TargetFramework>net8.0</TargetFramework>
    <AssemblyName>{properties.get('AssemblyName', os.path.splitext(os.path.basename(file_path))[0])}</AssemblyName>
    <RootNamespace>{properties.get('RootNamespace', os.path.splitext(os.path.basename(file_path))[0])}</RootNamespace>
    <GenerateAssemblyInfo>false</GenerateAssemblyInfo>
    <OutputType>{properties.get('OutputType', 'Library')}</OutputType>
    <ImplicitUsings>enable</ImplicitUsings>
    <Nullable>enable</Nullable>
  </PropertyGroup>

  <ItemGroup>
    <FrameworkReference Include="Microsoft.AspNetCore.App" />
"""
        # Add mapped package references
        for ref in mapped_refs:
            sdk_content += f'    <PackageReference Include="{ref["Include"]}" Version="{ref["Version"]}" />\n'

        sdk_content += "  </ItemGroup>\n\n"

        # Add project references
        if project_refs:
            sdk_content += "  <ItemGroup>\n"
            for ref in project_refs:
                sdk_content += f'    <ProjectReference Include="{ref}" />\n'
            sdk_content += "  </ItemGroup>\n"

        sdk_content += "</Project>"

        with open(file_path, 'w', encoding='utf-8') as f:
            f.write(sdk_content)

        print(f"Converted {file_path} to SDK style")
        return True

    except Exception as e:
        logger.error(f"Error converting project: {str(e)}")
        traceback.print_exc()
        return False

def main():
    if len(sys.argv) != 2:
        print("Usage: python3 convert_project_v2.py <project_file>")
        sys.exit(1)

    file_path = sys.argv[1]
    print(f"Processing: {file_path}")

    if not os.path.exists(file_path):
        print(f"Error: File {file_path} does not exist")
        sys.exit(1)

    try:
        convert_to_sdk_style(file_path)
        print("Conversion completed successfully")
    except Exception as e:
        print(f"Error during conversion: {str(e)}")
        traceback.print_exc()
        sys.exit(1)

if __name__ == "__main__":
    main()
