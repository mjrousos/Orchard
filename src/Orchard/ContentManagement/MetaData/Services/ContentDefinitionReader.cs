using Orchard.ContentManagement;
using Orchard.Security;
using Orchard.UI.Admin;
using Orchard.DisplayManagement;
using Orchard.Localization;
using Orchard.Services;
using System.Web.Mvc;
using Orchard.Mvc.Filters;
﻿using System.Linq;
using System.Xml;
using System.Xml.Linq;
using Orchard.ContentManagement.MetaData.Builders;
using Orchard.Validation;

namespace Orchard.ContentManagement.MetaData.Services {
    /// <summary>
    /// The content definition reader is used to import both content type and content part definitions from a XML format.
    /// </summary>
    public class ContentDefinitionReader : IContentDefinitionReader {
        /// <summary>
        /// The settings formatter to be used to convert the settings between a XML format and a dictionary.
        /// </summary>
        private readonly ISettingsFormatter _settingsFormatter;
        /// Initializes a new instance of the <see cref="ContentDefinitionReader"/> class.
        /// <param name="settingsFormatter">The settings formatter to be used to convert the settings between a dictionary and an XML format.</param>
        public ContentDefinitionReader(ISettingsFormatter settingsFormatter) {
            Argument.ThrowIfNull(settingsFormatter, "settingsFormatter");
            _settingsFormatter = settingsFormatter;
        }
        /// Merges a given content type definition provided in a XML format into a content type definition builder.
        /// <param name="element">The XML content type definition.</param>
        /// <param name="contentTypeDefinitionBuilder">The content type definition builder.</param>
        public void Merge(XElement element, ContentTypeDefinitionBuilder contentTypeDefinitionBuilder) {
            Argument.ThrowIfNull(element, "element");
            Argument.ThrowIfNull(contentTypeDefinitionBuilder, "contentTypeDefinitionBuilder");
            // Merge name
            contentTypeDefinitionBuilder.Named(XmlConvert.DecodeName(element.Name.LocalName));
            // Merge display name
            if (element.Attribute("DisplayName") != null) {
                contentTypeDefinitionBuilder.DisplayedAs(element.Attribute("DisplayName").Value);
            }
            // Merge settings
            foreach (var setting in _settingsFormatter.Map(element)) {
                contentTypeDefinitionBuilder.WithSetting(setting.Key, setting.Value);
            // Merge parts
            foreach (var iter in element.Elements()) {
                var partElement = iter;
                var partName = XmlConvert.DecodeName(partElement.Name.LocalName);
                if (partName == "remove") {
                    var nameAttribute = partElement.Attribute("name");
                    if (nameAttribute != null) {
                        contentTypeDefinitionBuilder.RemovePart(nameAttribute.Value);
                    }
                }
                else {
                    contentTypeDefinitionBuilder.WithPart(
                        partName,
                        partBuilder => {
                            foreach (var setting in _settingsFormatter.Map(partElement)) {
                                partBuilder.WithSetting(setting.Key, setting.Value);
                            }
                        });
        /// Merges a given content part definition provided in a XML format into a content part definition builder.
        /// <param name="contentPartDefinitionBuilder">The content part definition builder.</param>
        public void Merge(XElement element, ContentPartDefinitionBuilder contentPartDefinitionBuilder) {
            Argument.ThrowIfNull(contentPartDefinitionBuilder, "contentPartDefinitionBuilder");
            contentPartDefinitionBuilder.Named(XmlConvert.DecodeName(element.Name.LocalName));
                contentPartDefinitionBuilder.WithSetting(setting.Key, setting.Value);
            // Merge fields
                var fieldElement = iter;
                var fieldParameters = XmlConvert.DecodeName(fieldElement.Name.LocalName).Split(new[] { '.' }, 2);
                var fieldName = fieldParameters.FirstOrDefault();
                var fieldType = fieldParameters.Skip(1).FirstOrDefault();
                if (fieldName == "remove") {
                    var nameAttribute = fieldElement.Attribute("name");
                        contentPartDefinitionBuilder.RemoveField(nameAttribute.Value);
                    contentPartDefinitionBuilder.WithField(
                        fieldName,
                        fieldBuilder => {
                            fieldBuilder.OfType(fieldType);
                            foreach (var setting in _settingsFormatter.Map(fieldElement)) {
                                fieldBuilder.WithSetting(setting.Key, setting.Value);
    }
}
