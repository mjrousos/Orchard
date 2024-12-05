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

namespace Orchard.ArchiveLater {
    public class Migrations : DataMigrationImpl {
        public int Create() {
            ContentDefinitionManager.AlterPartDefinition("ArchiveLaterPart", builder => builder
                .Attachable()
                .WithDescription("Adds the ability to delay the unpublishing of a content item to a later date and time."));
            return 2;
        }
        public int UpdateFrom1() {
                .WithDescription("Adds the ability to delay the unpublising of a content item to a later date and time."));
    }
}
