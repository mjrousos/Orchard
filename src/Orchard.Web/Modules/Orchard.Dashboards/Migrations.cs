using Orchard.ContentManagement;
using Orchard.Security;
using Orchard.UI.Admin;
using Orchard.DisplayManagement;
using Orchard.Localization;
using Orchard.Services;
using System.Web.Mvc;
using Orchard.Mvc.Filters;
﻿using Orchard.ContentManagement.MetaData;
using Orchard.Dashboards.Services;
using Orchard.Data.Migration;

namespace Orchard.Dashboards {
    public class Migrations : DataMigrationImpl {
        public int Create() {
            ContentDefinitionManager.AlterTypeDefinition("Dashboard", type => type
                .WithPart("CommonPart")
                .WithIdentity()
                .WithPart("TitlePart")
                .WithPart("LayoutPart", p => p
                    .WithSetting("LayoutTypePartSettings.DefaultLayoutData", DefaultDashboardSelector.DefaultLayout)));
            return 1;
        } 
    }
}
