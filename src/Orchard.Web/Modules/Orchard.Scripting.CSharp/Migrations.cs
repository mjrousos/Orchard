using Orchard.ContentManagement;
using Orchard.Security;
using Orchard.UI.Admin;
using Orchard.DisplayManagement;
using Orchard.Localization;
using Orchard.Services;
using System.Web.Mvc;
using Orchard.Mvc.Filters;
﻿using Orchard.ContentManagement.MetaData;
using Orchard.Core.Contents.Extensions;
using Orchard.Data.Migration;
using Orchard.Environment.Extensions;

namespace Orchard.Scripting.CSharp {
    [OrchardFeature("Orchard.Scripting.CSharp.Validation")]
    public class Migrations : DataMigrationImpl {
        public int Create() {
            
            ContentDefinitionManager.AlterPartDefinition("ScriptValidationPart", cfg => cfg
                .Attachable()
                .WithDescription("Provides a way to validate content items using C#.")
                );
            return 1;
        }
    }
}
