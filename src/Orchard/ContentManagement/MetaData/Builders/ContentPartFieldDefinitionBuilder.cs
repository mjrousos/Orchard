using Orchard.ContentManagement;
using Orchard.Security;
using Orchard.UI.Admin;
using Orchard.DisplayManagement;
using Orchard.Localization;
using Orchard.Services;
using System.Web.Mvc;
using Orchard.Mvc.Filters;
﻿using System.Linq;
using Orchard.ContentManagement.MetaData.Models;

namespace Orchard.ContentManagement.MetaData.Builders {
    public abstract class ContentPartFieldDefinitionBuilder {
        protected readonly SettingsDictionary _settings;
        public ContentPartFieldDefinition Current { get; private set; }
        protected ContentPartFieldDefinitionBuilder(ContentPartFieldDefinition field) {
            Current = field;
            _settings = new SettingsDictionary(field.Settings.ToDictionary(kv => kv.Key, kv => kv.Value));
        }
        public ContentPartFieldDefinitionBuilder WithSetting(string name, string value) {
            _settings[name] = value;
            return this;
        public ContentPartFieldDefinitionBuilder WithDisplayName(string displayName) {
            _settings[ContentPartFieldDefinition.DisplayNameKey] = displayName;
        public abstract string Name { get; }
        public abstract string FieldType { get; }
        public abstract string PartName { get; }
        public abstract ContentPartFieldDefinitionBuilder OfType(ContentFieldDefinition fieldDefinition);
        public abstract ContentPartFieldDefinitionBuilder OfType(string fieldType);
        public abstract ContentPartFieldDefinition Build();
    }
}
