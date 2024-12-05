using Orchard.ContentManagement;
using Orchard.Security;
using Orchard.UI.Admin;
using Orchard.DisplayManagement;
using Orchard.Localization;
using Orchard.Services;
using System.Web.Mvc;
using Orchard.Mvc.Filters;
﻿using Orchard.Data.Migration;

namespace Orchard.Packaging {
    public class Migrations: DataMigrationImpl {
        public int Create() {
            SchemaBuilder.CreateTable("PackagingSource", 
                table => table
                    .Column<int>("Id", column => column.PrimaryKey().Identity())
                    .Column<string>("FeedTitle", c => c.WithLength(255))
                    .Column<string>("FeedUrl", c => c.WithLength(2048))
                );
            return 1;
        }
    }
}
