using Orchard.ContentManagement;
using Orchard.Security;
using Orchard.UI.Admin;
using Orchard.DisplayManagement;
using Orchard.Localization;
using Orchard.Services;
using System.Web.Mvc;
using Orchard.Mvc.Filters;
﻿using Orchard.ContentManagement.MetaData;
using Orchard.Data.Migration;
using Orchard.Environment.Extensions;

namespace Orchard.Taxonomies {
    [OrchardFeature("Orchard.Taxonomies.LocalizationExtensions")]
    public class LocalizedTaxonomyMigration : DataMigrationImpl {
        public int Create() {
            ContentDefinitionManager.AlterTypeDefinition("Taxonomy", cfg => cfg
                  .WithPart("LocalizationPart")
                  );
            return 1;
        }
    }
}
