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
using Orchard.Layouts.Helpers;

namespace Orchard.Layouts {
    public class Migrations : DataMigrationImpl {
        public int Create() {
            SchemaBuilder.CreateTable("ElementBlueprint", table => table
                .Column<int>("Id", c => c.PrimaryKey().Identity())
                .Column<string>("BaseElementTypeName", c => c.WithLength(256))
                .Column<string>("ElementTypeName", c => c.WithLength(256))
                .Column<string>("ElementDisplayName", c => c.WithLength(256))
                .Column<string>("ElementDescription", c => c.WithLength(2048))
                .Column<string>("ElementCategory", c => c.WithLength(256))
                .Column<string>("BaseElementState", c => c.Unlimited()));
            SchemaBuilder.CreateTable("LayoutPartRecord", table => table
                .ContentPartVersionRecord()
                .Column<int>("TemplateId"));
            ContentDefinitionManager.AlterPartDefinition("LayoutPart", part => part
                .Attachable()
                .WithDescription("Adds a layout designer to your content type."));
            ContentDefinitionManager.AlterTypeDefinition("Layout", type => type
                .WithPart("CommonPart", p => p
                    .WithSetting("OwnerEditorSettings.ShowOwnerEditor", "false")
                    .WithSetting("DateEditorSettings.ShowDateEditor", "false"))
                .WithPart("TitlePart")
                .WithIdentity()
                .WithPart("LayoutPart", p => p
                    .WithSetting("LayoutTypePartSettings.IsTemplate", "True"))
                .DisplayedAs("Layout")
                .Draftable());
            ContentDefinitionManager.AlterTypeDefinition("LayoutWidget", type => type
                .WithPart("WidgetPart")
                .WithPart("LayoutPart")
                .WithSetting("Stereotype", "Widget")
                .DisplayedAs("Layout Widget"));
            ContentDefinitionManager.AlterPartDefinition("BodyPart", part => part.Placeable());
            ContentDefinitionManager.AlterPartDefinition("TitlePart", part => part.Placeable());
            ContentDefinitionManager.AlterPartDefinition("CommonPart", part => part.Placeable());
            ContentDefinitionManager.AlterPartDefinition("TagsPart", part => part.Placeable());
            ContentDefinitionManager.AlterPartDefinition("ElementWrapperPart", part => part
                .WithDescription("Turns elements into content items."));
            DefineElementWidget("TextWidget", "Text Widget", "Orchard.Layouts.Elements.Text");
            DefineElementWidget("MediaWidget", "Media Widget", "Orchard.Layouts.Elements.MediaItem");
            DefineElementWidget("ContentWidget", "Content Widget", "Orchard.Layouts.Elements.ContentItem");
            ContentDefinitionManager.AlterTypeDefinition("Page", type => type
                    .WithSetting("LayoutTypePartSettings.IsTemplate", "False")));
            return 3;
        }
        public int UpdateFrom1() {
            SchemaBuilder.AlterTable("ElementBlueprint", table => table.AddColumn<string>("ElementDescription", c => c.WithLength(2048)));
            return 2;
        public int UpdateFrom2() {
                .WithIdentity());
        private void DefineElementWidget(string widgetTypeName, string widgetDisplayedAs, string elementTypeName) {
            ContentDefinitionManager.AlterTypeDefinition(widgetTypeName, type => type
                .WithPart("ElementWrapperPart", p => p
                    .WithSetting("ElementWrapperPartSettings.ElementTypeName", elementTypeName))
                .DisplayedAs(widgetDisplayedAs));
    }
}
