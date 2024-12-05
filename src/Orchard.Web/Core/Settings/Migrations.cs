using Orchard.ContentManagement;
using Orchard.Security;
using Orchard.UI.Admin;
using Orchard.DisplayManagement;
using Orchard.Localization;
using Orchard.Services;
using System.Web.Mvc;
using Orchard.Mvc.Filters;
﻿using Orchard.ContentManagement.MetaData;
using Orchard.Data.Migration;

namespace Orchard.Core.Settings {
    public class Migrations : DataMigrationImpl {
        public int Create() {
            SchemaBuilder.CreateTable("ContentFieldDefinitionRecord", 
                table => table
                    .Column<int>("Id", column => column.PrimaryKey().Identity())
                    .Column<string>("Name")
                );
            SchemaBuilder.CreateTable("ContentPartDefinitionRecord", 
                    .Column<bool>("Hidden")
                    .Column<string>("Settings", column => column.Unlimited())
            SchemaBuilder.CreateTable("ContentPartFieldDefinitionRecord", 
                    .Column<int>("ContentFieldDefinitionRecord_id")
                    .Column<int>("ContentPartDefinitionRecord_Id")
            SchemaBuilder.CreateTable("ContentTypeDefinitionRecord", 
                    .Column<string>("DisplayName")
            SchemaBuilder.CreateTable("ContentTypePartDefinitionRecord", 
                    .Column<int>("ContentPartDefinitionRecord_id")
                    .Column<int>("ContentTypeDefinitionRecord_Id")
            SchemaBuilder.CreateTable("ShellDescriptorRecord", 
                    .Column<int>("SerialNumber")
            SchemaBuilder.CreateTable("ShellFeatureRecord", 
                    .Column<int>("ShellDescriptorRecord_id"));
            SchemaBuilder.CreateTable("ShellFeatureStateRecord", 
                    .Column<string>("InstallState")
                    .Column<string>("EnableState")
                    .Column<int>("ShellStateRecord_Id")
            SchemaBuilder.CreateTable("ShellParameterRecord", 
                    .Column<string>("Component")
                    .Column<string>("Value")
                    .Column<int>("ShellDescriptorRecord_id")
            SchemaBuilder.CreateTable("ShellStateRecord", 
                    .Column<string>("Unused")
            // declare the Site content type to let users alter it
            ContentDefinitionManager.AlterTypeDefinition("Site", cfg => { });
            return 4;
        }
        public int UpdateFrom1() {
            SchemaBuilder.CreateTable("SiteSettings2PartRecord",
                    .ContentPartRecord()
                    .Column<string>("BaseUrl", c => c.Unlimited())
            return 2;
        public int UpdateFrom2() {
            SchemaBuilder.AlterTable("SiteSettingsPartRecord",
                    .AddColumn<string>("SiteTimeZone")
            return 3;
        public int UpdateFrom3() {
            return 4;            
        public int UpdateFrom4() {
            SchemaBuilder.AlterTable("ContentFieldDefinitionRecord",
                table => table.AddUniqueConstraint("UC_CFDR_Name", "Name"));
            SchemaBuilder.AlterTable("ContentPartDefinitionRecord",
                table => table.AddUniqueConstraint("UC_CPDR_Name", "Name"));
            SchemaBuilder.AlterTable("ContentPartFieldDefinitionRecord",
                table => table.AddUniqueConstraint("UC_CPFDR_CPDRId_Name", "ContentPartDefinitionRecord_Id", "Name"));
            SchemaBuilder.AlterTable("ContentTypeDefinitionRecord",
                table => table.AddUniqueConstraint("UC_CTDR_CPDRId", "Name"));
            SchemaBuilder.AlterTable("ContentTypePartDefinitionRecord",
                table => table.AddUniqueConstraint("UC_CTPDR_CPDRId_CTDRId", "ContentPartDefinitionRecord_id", "ContentTypeDefinitionRecord_Id"));
            // TODO: Orchard creates dupes in this table so no can do for now.
            //SchemaBuilder.AlterTable("ShellFeatureRecord",
            //    table => table.AddUniqueConstraint("UC_SFR_SDRId_Name", "ShellDescriptorRecord_id", "Name"));
            SchemaBuilder.AlterTable("ShellFeatureStateRecord",
                table => table.AddUniqueConstraint("UC_SFSR_SSRId_Name", "ShellStateRecord_Id", "Name"));
            SchemaBuilder.AlterTable("ShellParameterRecord",
                table => table.AddUniqueConstraint("UC_SPR_SDRId_Component_Name", "ShellDescriptorRecord_id", "Component", "Name"));
            return 5;
    }
}
