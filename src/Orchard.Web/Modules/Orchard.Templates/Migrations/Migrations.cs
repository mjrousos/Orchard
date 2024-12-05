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

namespace Orchard.Templates {
    public class Migrations : DataMigrationImpl {
        public int Create() {
            ContentDefinitionManager.AlterPartDefinition("ShapePart", part => part
                .Attachable()
                .WithDescription("Turns a type into a shape provider."));
            ContentDefinitionManager.AlterTypeDefinition("Template", type => type
                .WithPart("CommonPart")
                .WithIdentity()
                .WithPart("TitlePart")
                .WithPart("ShapePart")
                .Draftable());
            return 1;
        }
    }
}
