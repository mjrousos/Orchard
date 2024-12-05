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

namespace Orchard.Themes {
    public class ThemesDataMigration : DataMigrationImpl {
        public int Create() {
            return 1;
        }
        public int UpdateFrom1() {
            ContentDefinitionManager.AlterPartDefinition("DisableThemePart", builder => builder
                .Attachable()
                .WithDescription("When attached to a content type, disables the theme when a content item of this type is displayed."));
            return 2;
    }
}
