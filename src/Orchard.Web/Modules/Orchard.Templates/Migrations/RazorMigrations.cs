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
using Orchard.Data.Migration;
using Orchard.ContentManagement.MetaData;
using Orchard.Environment.Extensions;

namespace Orchard.Templates {
    [OrchardFeature("Orchard.Templates.Razor")]
    public class RazorMigrations : DataMigrationImpl {
        public int Create() {
            ContentDefinitionManager.AlterTypeDefinition("Template", type => type
                .WithPart("ShapePart", p => p
                    .WithSetting("ShapePartSettings.Processor", "Razor")));
            return 1;
        }
    }
}
