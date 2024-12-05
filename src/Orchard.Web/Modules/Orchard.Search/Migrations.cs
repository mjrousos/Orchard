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
using Orchard.Environment.Extensions;
using Orchard.Indexing;

namespace Orchard.Search {
    public class SearchDataMigration : DataMigrationImpl {
        public int Create() {
            ContentDefinitionManager.AlterTypeDefinition("SearchForm",
                cfg => cfg
                    .WithPart("SearchFormPart")
                    .AsWidgetWithIdentity()
                );
            return 3;
        }
        public int UpdateFrom1() {
            SchemaBuilder.AlterTable("SearchSettingsPartRecord", table => table
                .AddColumn<string>("SearchIndex", c => c.WithDefault("Search"))
            );
            return 2;
        public int UpdateFrom2() {
                cfg => cfg.WithIdentity());
           
    }
    [OrchardFeature("Orchard.Search.MediaLibrary")]
    public class MediaMigration : DataMigrationImpl {
        private readonly IIndexManager _indexManager;
        public MediaMigration(IIndexManager indexManager) {
            _indexManager = indexManager;
            _indexManager.GetSearchIndexProvider().CreateIndex("Media");
            ContentDefinitionManager.AlterTypeDefinition("Image", cfg => cfg.WithSetting("TypeIndexing.Indexes", "Media"));
            ContentDefinitionManager.AlterTypeDefinition("Video", cfg => cfg.WithSetting("TypeIndexing.Indexes", "Media"));
            ContentDefinitionManager.AlterTypeDefinition("Document", cfg => cfg.WithSetting("TypeIndexing.Indexes", "Media"));
            ContentDefinitionManager.AlterTypeDefinition("Audio", cfg => cfg.WithSetting("TypeIndexing.Indexes", "Media"));
            ContentDefinitionManager.AlterTypeDefinition("OEmbed", cfg => cfg.WithSetting("TypeIndexing.Indexes", "Media"));
            return 1;
    [OrchardFeature("Orchard.Search.Content")]
    public class AdminSearchMigration : DataMigrationImpl {
        public AdminSearchMigration(IIndexManager indexManager) {
            
    [OrchardFeature("Orchard.Search.Blogs")]
    public class BlogsMigration : DataMigrationImpl {
        public BlogsMigration(IIndexManager indexManager) {
            _indexManager.GetSearchIndexProvider().CreateIndex(BlogSearchConstants.ADMIN_BLOGPOSTS_INDEX);
            ContentDefinitionManager.AlterTypeDefinition("BlogPost", cfg => cfg.WithSetting("TypeIndexing.Indexes", BlogSearchConstants.ADMIN_BLOGPOSTS_INDEX + ":latest"));
}
