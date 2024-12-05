using Orchard.ContentManagement;
using Orchard.Security;
using Orchard.UI.Admin;
using Orchard.DisplayManagement;
using Orchard.Localization;
using Orchard.Services;
using System.Web.Mvc;
using Orchard.Mvc.Filters;
﻿using System.Collections.Generic;
using System.Linq;
using Orchard.Utility.Extensions;

namespace Orchard.ContentManagement.MetaData.Models {
    public class ContentPartDefinition {
        public ContentPartDefinition(string name, IEnumerable<ContentPartFieldDefinition> fields, SettingsDictionary settings) {
            Name = name;
            Fields = fields.ToReadOnlyCollection();
            Settings = settings;
        }
        public ContentPartDefinition(string name) {
            Fields = Enumerable.Empty<ContentPartFieldDefinition>();
            Settings = new SettingsDictionary();
        public string Name { get; private set; }
        public IEnumerable<ContentPartFieldDefinition> Fields { get; private set; }
        public SettingsDictionary Settings { get; private set; }
    }
}
