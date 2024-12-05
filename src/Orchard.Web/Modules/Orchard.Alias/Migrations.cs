using Orchard.ContentManagement;
using Orchard.Security;
using Orchard.UI.Admin;
using Orchard.DisplayManagement;
using Orchard.Localization;
using Orchard.Services;
using System.Web.Mvc;
using Orchard.Mvc.Filters;
﻿using Orchard.Data.Migration;

namespace Orchard.Alias {
    public class Migrations : DataMigrationImpl {
        public int Create() {
            SchemaBuilder
                .CreateTable("AliasRecord",
                             table => table
                                          .Column<int>("Id", column => column.PrimaryKey().Identity())
                                          .Column<string>("Path", c => c.WithLength(2048))
                                          .Column<int>("Action_id")
                                          .Column<string>("RouteValues", c => c.Unlimited())
                                          .Column<string>("Source", c => c.WithLength(256)))
                .CreateTable("ActionRecord",
                                          .Column<string>("Area")
                                          .Column<string>("Controller")
                                          .Column<string>("Action"));
            return 1;
        }
        public int UpdateFrom1() {
            SchemaBuilder.AlterTable("AliasRecord",
                    table => table
                        .AddColumn<bool>("IsManaged", column => column.WithDefault(false))
                );
            return 2;
    }
}
