using Orchard.ContentManagement;
using Orchard.Security;
using Orchard.UI.Admin;
using Orchard.DisplayManagement;
using Orchard.Localization;
using Orchard.Services;
using System.Web.Mvc;
using Orchard.Mvc.Filters;
﻿using Orchard.ContentManagement.MetaData.Models;

namespace Orchard.DynamicForms.Helpers {
    public static class ContentTypeDefinitionExtensions {
        public static string Stereotype(this ContentTypeDefinition contentTypeDefinition) {
            return contentTypeDefinition.Settings.ContainsKey("Stereotype") ? contentTypeDefinition.Settings["Stereotype"] : null;
        }
    }
}
