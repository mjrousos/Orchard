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
    public abstract class ContentTypePartDefinitionBuilder {
        protected readonly SettingsDictionary _settings;
        protected ContentTypePartDefinitionBuilder(ContentTypePartDefinition part) {
            Name = part.PartDefinition.Name;
            TypeName = part.ContentTypeDefinition != null ? part.ContentTypeDefinition.Name : default(string);
            _settings = new SettingsDictionary(part.Settings.ToDictionary(kv => kv.Key, kv => kv.Value));
        }
        public string Name { get; private set; }
        public string TypeName { get; private set; }
        public ContentTypePartDefinitionBuilder WithSetting(string name, string value) {
            _settings[name] = value;
            return this;
        public abstract ContentTypePartDefinition Build();
    }
}
