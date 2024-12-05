using Orchard.ContentManagement;
using Orchard.Security;
using Orchard.UI.Admin;
using Orchard.DisplayManagement;
using Orchard.Localization;
using Orchard.Services;
using System.Web.Mvc;
using Orchard.Mvc.Filters;
﻿using System;
using System.Globalization;
using Orchard.ContentManagement.MetaData;
using Orchard.Data.Migration;

namespace Orchard.ContentTypes {
    public class Migrations : DataMigrationImpl {
        private readonly IContentDefinitionManager _contentDefinitionManager;
        public Migrations(IContentDefinitionManager contentDefinitionManager) {
            _contentDefinitionManager = contentDefinitionManager;
        }
        public int Create() {
            foreach (var typeDefinition in _contentDefinitionManager.ListTypeDefinitions()) {
                if (typeDefinition.Settings.ContainsKey("ContentTypeSettings.Creatable") && Convert.ToBoolean(typeDefinition.Settings["ContentTypeSettings.Creatable"], CultureInfo.InvariantCulture)) {
                    typeDefinition.Settings["ContentTypeSettings.Listable"] = "True";
                    _contentDefinitionManager.StoreTypeDefinition(typeDefinition);
                }
            }
            return 1;
        public int UpdateFrom1() {
                    typeDefinition.Settings["ContentTypeSettings.Securable"] = "True";
            return 2;
    }
}
