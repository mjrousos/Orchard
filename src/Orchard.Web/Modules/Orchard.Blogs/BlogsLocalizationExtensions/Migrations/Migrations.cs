using Orchard.ContentManagement;
using Orchard.Security;
using Orchard.UI.Admin;
using Orchard.DisplayManagement;
using Orchard.Localization;
using Orchard.Services;
using System.Web.Mvc;
using Orchard.Mvc.Filters;
﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Orchard.ContentManagement.MetaData;
using Orchard.Data.Migration;
using Orchard.Environment.Extensions;

namespace Orchard.Blogs.BlogsLocalizationExtensions.Migrations {
    [OrchardFeature("Orchard.Blogs.LocalizationExtensions")]
    public class Migrations : DataMigrationImpl {
        public int Create() {
            ContentDefinitionManager.AlterTypeDefinition("Blog",
        cfg => cfg
            .WithPart("LocalizationPart"));
            ContentDefinitionManager.AlterTypeDefinition("BlogPost",
            return 1;
        }
    }
}
