using Orchard.ContentManagement;
using Orchard.Security;
using Orchard.UI.Admin;
using Orchard.DisplayManagement;
using Orchard.Localization;
using Orchard.Services;
using System.Web.Mvc;
using Orchard.Mvc.Filters;
﻿using System;
using Orchard.ContentManagement.MetaData;
using Orchard.Data.Migration;
using Orchard.Environment.Extensions;
using Orchard.MessageBus.Models;

namespace Orchard.MessageBus {
    [OrchardFeature("Orchard.MessageBus.SqlServerServiceBroker")]
    public class SqlServerBrokerMigrations : DataMigrationImpl {
        public int Create() {
            
            SchemaBuilder.CreateTable("MessageRecord",
                table => table
                    .Column<int>("Id", c => c.PrimaryKey().Identity())
                    .Column<string>("Publisher", c => c.WithLength(255))
                    .Column<string>("Channel", c => c.WithLength(255))
                    .Column<string>("Message", c => c.Unlimited())
                    .Column<DateTime>("CreatedUtc")
            );
            return 1;
        }
    }
}
