using Orchard.ContentManagement;
using Orchard.Security;
using Orchard.UI.Admin;
using Orchard.DisplayManagement;
using Orchard.Localization;
using Orchard.Services;
using System.Web.Mvc;
using Orchard.Mvc.Filters;
﻿using Orchard.Data.Migration;

namespace Orchard.Rules {
    public class Migrations : DataMigrationImpl {
        public int Create() {
            SchemaBuilder.CreateTable("RuleRecord",
                table => table
                    .Column<int>("Id", c => c.PrimaryKey().Identity())
                    .Column<bool>("Enabled")
                    .Column<string>("Name", c => c.WithLength(1024))
                );
            SchemaBuilder.CreateTable("EventRecord",
                    .Column<string>("Category", c => c.WithLength(64))
                    .Column<string>("Type", c => c.WithLength(64))
                    .Column<string>("Parameters", c => c.Unlimited())
                    .Column<int>("RuleRecord_id")
            SchemaBuilder.CreateTable("ActionRecord",
                    .Column<int>("Position")
            SchemaBuilder.CreateTable("ScheduledActionTaskRecord",
                    .ContentPartVersionRecord()
            SchemaBuilder.CreateTable("ScheduledActionRecord",
                    .Column<int>("ActionRecord_id")
                    .Column<int>("ScheduledActionTaskRecord_id")
            return 1;
        }
    }
}
