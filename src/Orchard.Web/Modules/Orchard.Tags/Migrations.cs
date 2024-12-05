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
using Orchard.Environment.Extensions;

namespace Orchard.Tags {
    public class TagsDataMigration : DataMigrationImpl {
        public int Create() {
            SchemaBuilder.CreateTable("TagsPartRecord",
                table => table
                    .ContentPartRecord()
                );
            SchemaBuilder.CreateTable("TagRecord",
                    .Column<int>("Id", column => column.PrimaryKey().Identity())
                    .Column<string>("TagName")
            SchemaBuilder.CreateTable("ContentTagRecord", 
                    .Column<int>("TagRecord_Id")
                    .Column<int>("TagsPartRecord_Id")
            ContentDefinitionManager.AlterPartDefinition("TagsPart", builder => builder.Attachable());
            return 1;
        }
        public int UpdateFrom1() {
            ContentDefinitionManager.AlterPartDefinition("TagsPart", builder => builder
                .WithDescription("Allows to describe your content using non-hierarchical keywords."));
            return 2;
        public int UpdateFrom2() {
            SchemaBuilder.AlterTable("ContentTagRecord", table => table
                .CreateIndex("IDX_TagsPartRecord_Id", "TagsPartRecord_Id")
            );
            return 3;
    }
    [OrchardFeature("Orchard.Tags.TagCloud")]
    public class TagCloudMigrations : DataMigrationImpl {
            ContentDefinitionManager.AlterTypeDefinition(
                "TagCloud",
                cfg => cfg
                           .WithPart("TagCloudPart")
                           .AsWidget()
}
