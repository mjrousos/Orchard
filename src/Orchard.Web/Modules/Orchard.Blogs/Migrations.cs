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

namespace Orchard.Blogs {
    public class Migrations : DataMigrationImpl {
        public int Create() {
            SchemaBuilder.CreateTable("BlogPartArchiveRecord",
                table => table
                    .Column<int>("Id", column => column.PrimaryKey().Identity())
                    .Column<int>("Year")
                    .Column<int>("Month")
                    .Column<int>("PostCount")
                    .Column<int>("BlogPart_id")
                );
            SchemaBuilder.CreateTable("RecentBlogPostsPartRecord",
                    .ContentPartRecord()
                    .Column<int>("BlogId")
                    .Column<int>("Count")
            SchemaBuilder.CreateTable("BlogArchivesPartRecord",
            ContentDefinitionManager.AlterPartDefinition("BlogPart", builder => builder
                .WithDescription("Turns content types into a Blog."));
            ContentDefinitionManager.AlterTypeDefinition("Blog",
                cfg => cfg
                    .WithPart("BlogPart")
                    .WithPart("CommonPart")
                    .WithPart("TitlePart")
                    .WithPart("AutoroutePart", builder => builder
                        .WithSetting("AutorouteSettings.AllowCustomPattern", "True")
                        .WithSetting("AutorouteSettings.AutomaticAdjustmentOnEdit", "False")
                        .WithSetting("AutorouteSettings.PatternDefinitions", "[{\"Name\":\"Title\",\"Pattern\":\"{Content.Slug}\",\"Description\":\"my-blog\"}]"))
                    .WithPart("MenuPart")
                    .WithPart("AdminMenuPart", p => p.WithSetting("AdminMenuPartTypeSettings.DefaultPosition", "2"))
            ContentDefinitionManager.AlterPartDefinition("BlogPostPart", builder => builder
                .WithDescription("Turns content types into a BlogPost."));
            ContentDefinitionManager.AlterTypeDefinition("BlogPost",
                    .WithPart("BlogPostPart")
                    .WithPart("CommonPart", p => p
                        .WithSetting("DateEditorSettings.ShowDateEditor", "True"))
                    .WithPart("PublishLaterPart")
                        .WithSetting("AutorouteSettings.PatternDefinitions", "[{\"Name\":\"Blog and Title\",\"Pattern\":\"{Content.Container.Path}/{Content.Slug}\",\"Description\":\"my-blog/my-post\"}]"))
                    .WithPart("BodyPart")
                    .Draftable()
            ContentDefinitionManager.AlterPartDefinition("RecentBlogPostsPart", part => part
                .WithDescription("Renders a list of recent blog posts."));
            ContentDefinitionManager.AlterTypeDefinition("RecentBlogPosts",
                    .WithPart("RecentBlogPostsPart")
                    .AsWidgetWithIdentity()
            ContentDefinitionManager.AlterPartDefinition("BlogArchivesPart", part => part
                .WithDescription("Renders an archive of posts for a blog."));
            ContentDefinitionManager.AlterTypeDefinition("BlogArchives",
                    .WithPart("BlogArchivesPart")
                    .WithPart("WidgetPart")
                    .WithSetting("Stereotype", "Widget")
                    .WithIdentity()
            return 7;
        }
        public int UpdateFrom1() {
            ContentDefinitionManager.AlterTypeDefinition("Blog", cfg => cfg.WithPart("AdminMenuPart", p => p.WithSetting("AdminMenuPartTypeSettings.DefaultPosition", "2")));
            return 3;
        public int UpdateFrom2() {
        public int UpdateFrom3() {
            ContentDefinitionManager.AlterTypeDefinition("BlogPost", cfg => cfg.WithPart("CommonPart", p => p.WithSetting("DateEditorSettings.ShowDateEditor", "true")));
            return 4;
        public int UpdateFrom4() {
            // adding the new fields required as Routable was removed
            // the user still needs to execute the corresponding migration
            // steps from the migration module
            SchemaBuilder.AlterTable("RecentBlogPostsPartRecord", table => table
                   .AddColumn<int>("BlogId"));
            SchemaBuilder.AlterTable("BlogArchivesPartRecord", table => table
                    .AddColumn<int>("BlogId"));
            return 5;
        public int UpdateFrom5() {
                .WithDescription("Turns a content type into a Blog."));
                .WithDescription("Turns a content type into a BlogPost."));
            return 6;
        public int UpdateFrom6() {
           return 7;
       }
    }
}
