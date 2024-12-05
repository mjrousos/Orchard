using Orchard.ContentManagement;
using Orchard.Security;
using Orchard.UI.Admin;
using Orchard.DisplayManagement;
using Orchard.Localization;
using Orchard.Services;
using System.Web.Mvc;
using Orchard.Mvc.Filters;
﻿using System;
using System.Data;
using System.Linq;
using Orchard.ContentManagement.MetaData;
using Orchard.Core.Common.Models;
using Orchard.Core.Contents.Extensions;
using Orchard.Core.Title.Models;
using Orchard.Data;
using Orchard.Data.Migration;
using Orchard.Projections.Models;

namespace Orchard.Projections {
    public class Migrations : DataMigrationImpl {
        private readonly IRepository<MemberBindingRecord> _memberBindingRepository;
        private readonly IRepository<LayoutRecord> _layoutRepository;
        private readonly IRepository<PropertyRecord> _propertyRecordRepository;
        private readonly IRepository<FilterRecord> _filterRepository;
        /// <summary>
        /// When upgrading from "1.10.x" branch code committed after 1.10.3 to "dev" branch code or 1.11, merge
        /// conflicts between "1.10.x" and "dev" caused by running the same migration steps in a different order need to
        /// be resolved by instructing this migration to decide which steps need to be executed. If you're upgrading
        /// under these conditions and your pre-upgrade migration version is 6, use HostComponents.config to override
        /// this property to true.
        /// </summary>
        public bool IsUpgradingFromOrchard_1_10_x_Version_6 { get; set; }
        public Migrations(
            IRepository<MemberBindingRecord> memberBindingRepository,
            IRepository<LayoutRecord> layoutRepository,
            IRepository<PropertyRecord> propertyRecordRepository,
            IRepository<FilterRecord> filterRepository) {
            _memberBindingRepository = memberBindingRepository;
            _layoutRepository = layoutRepository;
            _propertyRecordRepository = propertyRecordRepository;
            _filterRepository = filterRepository;
            T = NullLocalizer.Instance;
        }
        public Localizer T { get; set; }
        public int Create() {
            // Properties index
            SchemaBuilder.CreateTable("StringFieldIndexRecord",
                table => table
                    .Column<int>("Id", c => c.PrimaryKey().Identity())
                    .Column<string>("PropertyName")
                    .Column<string>("Value", c => c.WithLength(4000))
                    .Column<string>("LatestValue", c => c.WithLength(4000))
                    .Column<int>("FieldIndexPartRecord_Id")
            );
            SchemaBuilder.CreateTable("IntegerFieldIndexRecord",
                    .Column<long>("Value")
                    .Column<long>("LatestValue")
            SchemaBuilder.CreateTable("DoubleFieldIndexRecord",
                    .Column<double>("Value")
                    .Column<double>("LatestValue")
            SchemaBuilder.CreateTable("DecimalFieldIndexRecord",
                    .Column<decimal>("Value")
                    .Column<decimal>("LatestValue")
            //Adds indexes for better performances in queries
            SchemaBuilder.AlterTable("StringFieldIndexRecord", table => {
                table.CreateIndex("IDX_Orchard_Projections_PropertyName", "PropertyName");
                table.CreateIndex("IDX_Orchard_Projections_StringFieldIndexRecord", "FieldIndexPartRecord_Id");
            });
            SchemaBuilder.AlterTable("IntegerFieldIndexRecord", table => {
                table.CreateIndex("IDX_Orchard_Projections_IntegerFieldIndexRecord", "FieldIndexPartRecord_Id");
            SchemaBuilder.AlterTable("DoubleFieldIndexRecord", table => {
                table.CreateIndex("IDX_Orchard_Projections_DoubleFieldIndexRecord", "FieldIndexPartRecord_Id");
            SchemaBuilder.AlterTable("DecimalFieldIndexRecord", table => {
                table.CreateIndex("IDX_Orchard_Projections_DecimalFieldIndexRecords", "FieldIndexPartRecord_Id");
            SchemaBuilder.CreateTable("FieldIndexPartRecord", table => table.ContentPartRecord());
            SchemaBuilder.AlterTable("StringFieldIndexRecord", table => table.CreateIndex("IX_PropertyName", new string[] { "PropertyName" }));
            SchemaBuilder.AlterTable("StringFieldIndexRecord", table => table.CreateIndex("IX_FieldIndexPartRecord_Id", new string[] { "FieldIndexPartRecord_Id" }));
            SchemaBuilder.AlterTable("IntegerFieldIndexRecord", table => table.CreateIndex("IX_PropertyName", new string[] { "PropertyName" }));
            SchemaBuilder.AlterTable("IntegerFieldIndexRecord", table => table.CreateIndex("IX_FieldIndexPartRecord_Id", new string[] { "FieldIndexPartRecord_Id" }));
            SchemaBuilder.AlterTable("DoubleFieldIndexRecord", table => table.CreateIndex("IX_PropertyName", new string[] { "PropertyName" }));
            SchemaBuilder.AlterTable("DoubleFieldIndexRecord", table => table.CreateIndex("IX_FieldIndexPartRecord_Id", new string[] { "FieldIndexPartRecord_Id" }));
            SchemaBuilder.AlterTable("DecimalFieldIndexRecord", table => table.CreateIndex("IX_PropertyName", new string[] { "PropertyName" }));
            SchemaBuilder.AlterTable("DecimalFieldIndexRecord", table => table.CreateIndex("IX_FieldIndexPartRecord_Id", new string[] { "FieldIndexPartRecord_Id" }));
            // Query
            ContentDefinitionManager.AlterTypeDefinition("Query",
                cfg => cfg
                    .WithPart("QueryPart")
                    .WithPart("TitlePart")
                    .WithIdentity()
                );
            SchemaBuilder.CreateTable("QueryPartRecord",
                    .ContentPartRecord()
                    .Column<string>("VersionScope", c => c.WithLength(15))
            SchemaBuilder.CreateTable("FilterGroupRecord",
                    .Column<int>("QueryPartRecord_id")
            SchemaBuilder.CreateTable("FilterRecord",
                    .Column<string>("Category", c => c.WithLength(64))
                    .Column<string>("Type", c => c.WithLength(64))
                    .Column<string>("Description", c => c.WithLength(255))
                    .Column<string>("State", c => c.Unlimited())
                    .Column<int>("Position")
                    .Column<int>("FilterGroupRecord_id")
            SchemaBuilder.CreateTable("SortCriterionRecord",
            SchemaBuilder.CreateTable("LayoutRecord",
                    .Column<string>("DisplayType", c => c.WithLength(64))
                    .Column<string>("GUIdentifier", column => column.WithLength(68))
                    .Column<int>("Display")
                    .Column<int>("GroupProperty_id")
            SchemaBuilder.CreateTable("PropertyRecord",
                    .Column<int>("LayoutRecord_id")
                    .Column<bool>("ExcludeFromDisplay")
                    .Column<bool>("CreateLabel")
                    .Column<string>("Label", c => c.WithLength(255))
                    .Column<bool>("LinkToContent")
                    .Column<bool>("CustomizePropertyHtml")
                    .Column<string>("CustomPropertyTag", c => c.WithLength(64))
                    .Column<string>("CustomPropertyCss", c => c.WithLength(64))
                    .Column<bool>("CustomizeLabelHtml")
                    .Column<string>("CustomLabelTag", c => c.WithLength(64))
                    .Column<string>("CustomLabelCss", c => c.WithLength(64))
                    .Column<bool>("CustomizeWrapperHtml")
                    .Column<string>("CustomWrapperTag", c => c.WithLength(64))
                    .Column<string>("CustomWrapperCss", c => c.WithLength(64))
                    .Column<string>("NoResultText", c => c.Unlimited())
                    .Column<bool>("ZeroIsEmpty")
                    .Column<bool>("HideEmpty")
                    .Column<bool>("RewriteOutput")
                    .Column<string>("RewriteOutputCondition", c => c.Unlimited())
                    .Column<string>("RewriteText", c => c.Unlimited())
                    .Column<bool>("StripHtmlTags")
                    .Column<bool>("TrimLength")
                    .Column<bool>("AddEllipsis")
                    .Column<int>("MaxLength")
                    .Column<bool>("TrimOnWordBoundary")
                    .Column<bool>("PreserveLines")
                    .Column<bool>("TrimWhiteSpace")
            SchemaBuilder.CreateTable("ProjectionPartRecord",
                    .Column<int>("Items")
                    .Column<int>("ItemsPerPage")
                    .Column<int>("Skip")
                    .Column<string>("PagerSuffix", c => c.WithLength(255))
                    .Column<int>("MaxItems")
                    .Column<bool>("DisplayPager")
                    .Column<int>("LayoutRecord_Id")
            SchemaBuilder.CreateTable("MemberBindingRecord",
                    .Column<string>("Type", c => c.WithLength(255))
                    .Column<string>("Member", c => c.WithLength(64))
                    .Column<string>("Description", c => c.WithLength(500))
                    .Column<string>("DisplayName", c => c.WithLength(64))
            ContentDefinitionManager.AlterTypeDefinition("ProjectionWidget",
                    .WithPart("WidgetPart")
                    .WithPart("CommonPart")
                    .WithPart("ProjectionPart")
                    .WithSetting("Stereotype", "Widget")
            ContentDefinitionManager.AlterTypeDefinition("ProjectionPage",
                     .WithPart("AutoroutePart", builder => builder
                        .WithSetting("AutorouteSettings.AllowCustomPattern", "True")
                        .WithSetting("AutorouteSettings.AutomaticAdjustmentOnEdit", "False")
                        .WithSetting("AutorouteSettings.PatternDefinitions", "[{\"Name\":\"Title\",\"Pattern\":\"{Content.Slug}\",\"Description\":\"my-projections\"}]"))
                    .WithPart("MenuPart")
                    .WithPart("AdminMenuPart", p => p.WithSetting("AdminMenuPartTypeSettings.DefaultPosition", "5"))
                    .Creatable()
                    .Listable()
                    .DisplayedAs("Projection")
            SchemaBuilder.CreateTable("NavigationQueryPartRecord",
                table => table.ContentPartRecord()
            ContentDefinitionManager.AlterTypeDefinition("NavigationQueryMenuItem",
                    .WithPart("NavigationQueryPart")
                    .DisplayedAs("Query Link")
                    .WithSetting("Description", "Injects menu items from a Query")
                    .WithSetting("Stereotype", "MenuItem")
            // Default Model Bindings - CommonPartRecord
            _memberBindingRepository.Create(new MemberBindingRecord {
                Type = typeof(CommonPartRecord).FullName,
                Member = "CreatedUtc",
                DisplayName = T("Creation date").Text,
                Description = T("When the content item was created").Text
                Member = "ModifiedUtc",
                DisplayName = T("Modification date").Text,
                Description = T("When the content item was modified").Text
                Member = "PublishedUtc",
                DisplayName = T("Publication date").Text,
                Description = T("When the content item was published").Text
            // Default Model Bindings - TitlePartRecord
                Type = typeof(TitlePartRecord).FullName,
                Member = "Title",
                DisplayName = T("Title Part Title").Text,
                Description = T("The title assigned using the Title part").Text
            // Default Model Bindings - BodyPartRecord
                Type = typeof(BodyPartRecord).FullName,
                Member = "Text",
                DisplayName = T("Body Part Text").Text,
                Description = T("The text from the Body part").Text
            return 7;
        public int UpdateFrom1() {
            ContentDefinitionManager.AlterTypeDefinition("ProjectionPage", cfg => cfg.Listable());
            return 2;
        public int UpdateFrom2() {
            SchemaBuilder.AlterTable("ProjectionPartRecord", table => table
                .AlterColumn("PagerSuffix", c => c.WithType(DbType.String).WithLength(255))
            return 3;
        public int UpdateFrom3() {
            return 4;
        public int UpdateFrom4() {
            SchemaBuilder.AlterTable("StringFieldIndexRecord", table => table
                .AddColumn<string>("LatestValue", c => c.WithLength(4000)));
            SchemaBuilder.AlterTable("IntegerFieldIndexRecord", table => table
                .AddColumn<long>("LatestValue"));
            SchemaBuilder.AlterTable("DoubleFieldIndexRecord", table => table
                .AddColumn<double>("LatestValue"));
            SchemaBuilder.AlterTable("DecimalFieldIndexRecord", table => table
                .AddColumn<decimal>("LatestValue"));
            SchemaBuilder.AlterTable("QueryPartRecord", table => table
                .AddColumn<string>("VersionScope", c => c.WithLength(15)));
            return 5;
        public int UpdateFrom5() {
            MigratePropertyRecordToRewriteOutputCondition();
            return 6;
        public int UpdateFrom6() {
            // This change was originally UpdateFrom6 on 1.10.x and UpdateFrom6 on dev: Casting a somewhat wide net, but
            // filters can't be queried by the form they are using and different types of filters can (and do) use
            // StringFilterForm. However, the "Operator" parameter's value being "ContainsAnyIfProvided" is very
            // specific.
            var formStateToReplace = "<Operator>ContainsAnyIfProvided</Operator>";
            var filterRecordsToUpdate = _filterRepository.Table.Where(f => f.State.Contains(formStateToReplace)).ToList();
            foreach (var filter in filterRecordsToUpdate) {
                filter.State = filter.State.Replace(
                    formStateToReplace,
                    "<Operator>ContainsAny</Operator><IgnoreFilterIfValueIsEmpty>true</IgnoreFilterIfValueIsEmpty>");
            }
            if (IsUpgradingFromOrchard_1_10_x_Version_6) {
                MigratePropertyRecordToRewriteOutputCondition();
            else {
                // This change was originally UpdateFrom5 on 1.10.x and UpdateFrom6 on dev.
                SchemaBuilder.AlterTable("LayoutRecord", table =>
                    table.AddColumn<string>("GUIdentifier", column => column.WithLength(68)));
                var layoutRecords = _layoutRepository.Table.Where(l => l.GUIdentifier == null || l.GUIdentifier == "").ToList();
                foreach (var layout in layoutRecords) {
                    layout.GUIdentifier = Guid.NewGuid().ToString();
                }
        // This change was originally in UpdateFrom5 on dev, but didn't exist on 1.10.x.
        private void MigratePropertyRecordToRewriteOutputCondition() {
            SchemaBuilder.AlterTable("PropertyRecord", table => table
                .AddColumn<string>("RewriteOutputCondition", c => c.Unlimited())
            foreach (var property in _propertyRecordRepository.Table)
#pragma warning disable CS0618 // Type or member is obsolete
                // Reading this obsolete property to migrate its data to a new one.
                if (property.RewriteOutput) property.RewriteOutputCondition = "true";
#pragma warning restore CS0618 // Type or member is obsolete
    }
}
