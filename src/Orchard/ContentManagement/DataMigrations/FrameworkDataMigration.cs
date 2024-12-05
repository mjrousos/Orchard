using Orchard.ContentManagement;
using Orchard.Security;
using Orchard.UI.Admin;
using Orchard.DisplayManagement;
using Orchard.Localization;
using Orchard.Services;
using System.Web.Mvc;
using Orchard.Mvc.Filters;
﻿using Orchard.Data.Migration;

namespace Orchard.ContentManagement.DataMigrations {
    public class FrameworkDataMigration : DataMigrationImpl {
        public int Create() {
            SchemaBuilder.CreateTable("ContentItemRecord", 
                table => table
                    .Column<int>("Id", column => column.PrimaryKey().Identity())
                    .Column<string>("Data", c => c.Unlimited())
                    .Column<int>("ContentType_id")
                );
            SchemaBuilder.CreateTable("ContentItemVersionRecord", 
                    .Column<int>("Number")
                    .Column<bool>("Published")
                    .Column<bool>("Latest")
                    .Column<int>("ContentItemRecord_id", c => c.NotNull())
            SchemaBuilder.CreateTable("ContentTypeRecord", 
                    .Column<string>("Name")
            SchemaBuilder.CreateTable("CultureRecord", 
                    .Column<string>("Culture")
            return 1;
        }
        public int UpdateFrom1() {
            SchemaBuilder.AlterTable("ContentItemRecord",
               table => table
                   .CreateIndex("IDX_ContentType_id", "ContentType_id")
               );
            SchemaBuilder.AlterTable("ContentItemVersionRecord",
                    .CreateIndex("IDX_ContentItemRecord_id", "ContentItemRecord_id")
            return 2;
        public int UpdateFrom2() {
            SchemaBuilder.AlterTable("ContentTypeRecord",
                   .CreateIndex("IDX_ContentType_Name", "Name")
                   .CreateIndex("IDX_ContentItemVersionRecord_Published_Latest", "Published", "Latest")
            return 3;
        public int UpdateFrom3() {
            SchemaBuilder
                .AlterTable("ContentTypeRecord", table =>
                    table.AddUniqueConstraint("UC_CTR_Name", "Name"))
                .AlterTable("ContentItemVersionRecord", table =>
                    table.AddUniqueConstraint("UC_CIVR_CIRId_Number", "ContentItemRecord_id", "Number"))
                .AlterTable("CultureRecord", table =>
                    table.AddUniqueConstraint("UC_CR_Name", "Culture"));
            return 4;
    }
}
