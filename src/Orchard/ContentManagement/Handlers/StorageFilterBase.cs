using Orchard.ContentManagement;
using Orchard.Security;
using Orchard.UI.Admin;
using Orchard.DisplayManagement;
using Orchard.Localization;
using Orchard.Services;
using System.Web.Mvc;
using Orchard.Mvc.Filters;
namespace Orchard.ContentManagement.Handlers {
    public abstract class StorageFilterBase<TPart> : IContentStorageFilter where TPart : class, IContent {

        protected virtual void Activated(ActivatedContentContext context, TPart instance) { }
        protected virtual void Activating(ActivatingContentContext context, TPart instance) { }
        protected virtual void Initializing(InitializingContentContext context, TPart instance) { }
        protected virtual void Initialized(InitializingContentContext context, TPart instance) { }
        protected virtual void Creating(CreateContentContext context, TPart instance) { }
        protected virtual void Created(CreateContentContext context, TPart instance) { }
        protected virtual void Loading(LoadContentContext context, TPart instance) { }
        protected virtual void Loaded(LoadContentContext context, TPart instance) { }
        protected virtual void Updating(UpdateContentContext context, TPart instance) { }
        protected virtual void Updated(UpdateContentContext context, TPart instance) { }
        protected virtual void Versioning(VersionContentContext context, TPart existing, TPart building) { }
        protected virtual void Versioned(VersionContentContext context, TPart existing, TPart building) { }
        protected virtual void Publishing(PublishContentContext context, TPart instance) { }
        protected virtual void Published(PublishContentContext context, TPart instance) { }
        protected virtual void Unpublishing(PublishContentContext context, TPart instance) { }
        protected virtual void Unpublished(PublishContentContext context, TPart instance) { }
        protected virtual void Removing(RemoveContentContext context, TPart instance) { }
        protected virtual void Removed(RemoveContentContext context, TPart instance) { }
        protected virtual void Indexing(IndexContentContext context, TPart instance) { }
        protected virtual void Indexed(IndexContentContext context, TPart instance) { }
        protected virtual void Cloning(CloneContentContext context, TPart instance) { }
        protected virtual void Cloned(CloneContentContext context, TPart instance) { }
        protected virtual void Importing(ImportContentContext context, TPart instance) { }
        protected virtual void Imported(ImportContentContext context, TPart instance) { }
        protected virtual void ImportCompleted(ImportContentContext context, TPart instance) { }
        protected virtual void Exporting(ExportContentContext context, TPart instance) { }
        protected virtual void Exported(ExportContentContext context, TPart instance) { }
        protected virtual void Restoring(RestoreContentContext context, TPart instance) { }
        protected virtual void Restored(RestoreContentContext context, TPart instance) { }
        protected virtual void Destroying(DestroyContentContext context, TPart instance) { }
        protected virtual void Destroyed(DestroyContentContext context, TPart instance) { }
        void IContentStorageFilter.Activated(ActivatedContentContext context) {
            if (context.ContentItem.Is<TPart>())
                Activated(context, context.ContentItem.As<TPart>());
        }
        void IContentStorageFilter.Initializing(InitializingContentContext context) {
                Initializing(context, context.ContentItem.As<TPart>());
        void IContentStorageFilter.Initialized(InitializingContentContext context) {
                Initialized(context, context.ContentItem.As<TPart>());
        void IContentStorageFilter.Creating(CreateContentContext context) {
                Creating(context, context.ContentItem.As<TPart>());
        void IContentStorageFilter.Created(CreateContentContext context) {
                Created(context, context.ContentItem.As<TPart>());
        void IContentStorageFilter.Loading(LoadContentContext context) {
                Loading(context, context.ContentItem.As<TPart>());
        void IContentStorageFilter.Loaded(LoadContentContext context) {
                Loaded(context, context.ContentItem.As<TPart>());
        void IContentStorageFilter.Updating(UpdateContentContext context) {
                Updating(context, context.ContentItem.As<TPart>());
        void IContentStorageFilter.Updated(UpdateContentContext context) {
                Updated(context, context.ContentItem.As<TPart>());
        void IContentStorageFilter.Versioning(VersionContentContext context) {
            if (context.ExistingContentItem.Is<TPart>() || context.BuildingContentItem.Is<TPart>())
                Versioning(context, context.ExistingContentItem.As<TPart>(), context.BuildingContentItem.As<TPart>());
        void IContentStorageFilter.Versioned(VersionContentContext context) {
                Versioned(context, context.ExistingContentItem.As<TPart>(), context.BuildingContentItem.As<TPart>());
        void IContentStorageFilter.Publishing(PublishContentContext context) {
                Publishing(context, context.ContentItem.As<TPart>());
        void IContentStorageFilter.Published(PublishContentContext context) {
                Published(context, context.ContentItem.As<TPart>());
        void IContentStorageFilter.Unpublishing(PublishContentContext context) {
                Unpublishing(context, context.ContentItem.As<TPart>());
        void IContentStorageFilter.Unpublished(PublishContentContext context) {
                Unpublished(context, context.ContentItem.As<TPart>());
        void IContentStorageFilter.Removing(RemoveContentContext context) {
                Removing(context, context.ContentItem.As<TPart>());
        void IContentStorageFilter.Removed(RemoveContentContext context) {
                Removed(context, context.ContentItem.As<TPart>());
        void IContentStorageFilter.Indexing(IndexContentContext context) {
            if ( context.ContentItem.Is<TPart>() )
                Indexing(context, context.ContentItem.As<TPart>());
        void IContentStorageFilter.Indexed(IndexContentContext context) {
                Indexed(context, context.ContentItem.As<TPart>());
        void IContentStorageFilter.Cloning(CloneContentContext context) {
                Cloning(context, context.ContentItem.As<TPart>());
        void IContentStorageFilter.Cloned(CloneContentContext context) {
                Cloned(context, context.ContentItem.As<TPart>());
        void IContentStorageFilter.Importing(ImportContentContext context) {
                Importing(context, context.ContentItem.As<TPart>());
        void IContentStorageFilter.Imported(ImportContentContext context) {
                Imported(context, context.ContentItem.As<TPart>());
        void IContentStorageFilter.ImportCompleted(ImportContentContext context) {
                ImportCompleted(context, context.ContentItem.As<TPart>());
        void IContentStorageFilter.Exporting(ExportContentContext context) {
                Exporting(context, context.ContentItem.As<TPart>());
        void IContentStorageFilter.Exported(ExportContentContext context) {
                Exported(context, context.ContentItem.As<TPart>());
        void IContentStorageFilter.Restoring(RestoreContentContext context) {
                Restoring(context, context.ContentItem.As<TPart>());
        void IContentStorageFilter.Restored(RestoreContentContext context) {
                Restored(context, context.ContentItem.As<TPart>());
        void IContentStorageFilter.Destroying(DestroyContentContext context) {
                Destroying(context, context.ContentItem.As<TPart>());
        void IContentStorageFilter.Destroyed(DestroyContentContext context) {
                Destroyed(context, context.ContentItem.As<TPart>());
    }
}
