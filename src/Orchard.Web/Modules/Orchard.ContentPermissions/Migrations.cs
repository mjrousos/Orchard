using Orchard.ContentManagement;
using Orchard.Security;
using Orchard.UI.Admin;
using Orchard.DisplayManagement;
using Orchard.Localization;
using Orchard.Services;
using System.Web.Mvc;
using Orchard.Mvc.Filters;
﻿using Orchard.Core.Contents.Extensions;
using Orchard.Data.Migration;
using Orchard.ContentManagement.MetaData;

namespace Orchard.ContentPermissions {
    public class Migrations : DataMigrationImpl {
        public int Create() {
            ContentDefinitionManager.AlterPartDefinition("ContentPermissionsPart", p => p
                .Attachable()
                .WithDescription("Provides access control configuration on a per content item level."));
            return 3;
        }
        public int UpdateFrom1() {
            return 2;
        public int UpdateFrom2() {
            
            // auto-upgrade to 3 as UpdateFrom1 is incorrectly returning 2
    }
}
