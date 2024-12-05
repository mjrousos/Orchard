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
using Orchard.Core.Title.Settings;

namespace Orchard.Core.Title {
    public class Migrations : DataMigrationImpl {
        public int Create() {
            SchemaBuilder.CreateTable("TitlePartRecord", 
                table => table
                    .ContentPartVersionRecord()
                    .Column<string>("Title", column => column.WithLength(TitlePartSettings.MaxTitleLength))
                );
            ContentDefinitionManager.AlterPartDefinition("TitlePart", builder => builder
                .Attachable()
                .WithDescription("Provides a Title for your content item."));
            return 2;
        }
        public int UpdateFrom1() {
    }
}
