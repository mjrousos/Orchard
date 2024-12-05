using Orchard.ContentManagement;
using Orchard.Security;
using Orchard.UI.Admin;
using Orchard.DisplayManagement;
using Orchard.Localization;
using Orchard.Services;
using System.Web.Mvc;
using Orchard.Mvc.Filters;
﻿namespace Orchard.ContentManagement.MetaData.Models {
    public class ContentFieldDefinition {
        public ContentFieldDefinition(string name) {
            Name = name;
        }

        public string Name { get; private set; }
    }
}
