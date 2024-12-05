using Orchard.ContentManagement;
using Orchard.Security;
using Orchard.UI.Admin;
using Orchard.DisplayManagement;
using Orchard.Localization;
using Orchard.Services;
using System.Web.Mvc;
using Orchard.Mvc.Filters;
using System.Collections.Generic;
using System.Xml.Linq;
using Orchard.ContentManagement.Handlers;
using Orchard.ContentManagement.MetaData.Models;
using Orchard.Indexing;

namespace Orchard.ContentManagement {
    /// <summary>
    /// Content management functionality to deal with Orchard content items and their parts
    /// </summary>
    public interface IContentManager : IDependency {
        IEnumerable<ContentTypeDefinition> GetContentTypeDefinitions();
        /// <summary>
        /// Instantiates a new content item with the specified type
        /// </summary>
        /// <remarks>
        /// The content item is not yet persisted!
        /// </remarks>
        /// <param name="contentType">The name of the content type</param>
        ContentItem New(string contentType);
        
        /// Creates (persists) a new content item
        /// <param name="contentItem">The content instance filled with all necessary data</param>
        void Create(ContentItem contentItem);
        /// Creates (persists) a new content item with the specified version
        /// <param name="options">The version to create the item with</param>
        void Create(ContentItem contentItem, VersionOptions options);
        /// Makes a clone of the content item
        /// <param name="contentItem">The content item to clone</param>
        /// <returns>Clone of the item</returns>
        ContentItem Clone(ContentItem contentItem);
        /// Rolls back the specified content item by creating a new version based on the specified version.
        /// <param name="contentItem">The content item to roll back.</param>
        /// <param name="options">The version to roll back to. Either specify the version record id, version number, and IsPublished to publish the new version.</param>
        /// <returns>Returns the latest version of the content item, which is based on the specified version.</returns>
        ContentItem Restore(ContentItem contentItem, VersionOptions options);
        /// Gets the content item with the specified id
        /// <param name="id">Numeric id of the content item</param>
        ContentItem Get(int id);
        /// Gets the content item with the specified id and version
        /// <param name="options">The version option</param>
        ContentItem Get(int id, VersionOptions options);
        /// Gets the content item with the specified id, version and query hints
        /// <param name="hints">The query hints</param>
        ContentItem Get(int id, VersionOptions options, QueryHints hints);
        /// Gets all versions of the content item specified with its id
        IEnumerable<ContentItem> GetAllVersions(int id);
        IEnumerable<T> GetMany<T>(IEnumerable<int> ids, VersionOptions options, QueryHints hints) where T : class, IContent;
        IEnumerable<T> GetManyByVersionId<T>(IEnumerable<int> versionRecordIds, QueryHints hints) where T : class, IContent;
        IEnumerable<ContentItem> GetManyByVersionId(IEnumerable<int> versionRecordIds, QueryHints hints);
        void Publish(ContentItem contentItem);
        void Unpublish(ContentItem contentItem);
        void Remove(ContentItem contentItem);
        /// Deletes the draft version of the content item permanently.
        /// <param name="contentItem">The content item of which the draft version will be deleted.</param>
        void DiscardDraft(ContentItem contentItem);
        /// Permanently deletes the specified content item, including all of its content part records.
        void Destroy(ContentItem contentItem);
        void Index(ContentItem contentItem, IDocumentIndex documentIndex);
        XElement Export(ContentItem contentItem);
        void Import(XElement element, ImportContentSession importContentSession);
        void CompleteImport(XElement element, ImportContentSession importContentSession);
        /// Clears the current referenced content items
        void Clear();
        /// Query for arbitrary content items
        IContentQuery<ContentItem> Query();
        IHqlQuery HqlQuery();
        ContentItemMetadata GetItemMetadata(IContent contentItem);
        IEnumerable<GroupInfo> GetEditorGroupInfos(IContent contentItem);
        IEnumerable<GroupInfo> GetDisplayGroupInfos(IContent contentItem);
        GroupInfo GetEditorGroupInfo(IContent contentItem, string groupInfoId);
        GroupInfo GetDisplayGroupInfo(IContent contentItem, string groupInfoId);
        ContentItem ResolveIdentity(ContentIdentity contentIdentity);
        /// Builds the display shape of the specified content item
        /// <param name="content">The content item to use</param>
        /// <param name="displayType">The display type (e.g. Summary, Detail) to use</param>
        /// <param name="groupId">Id of the display group (stored in the content item's metadata)</param>
        /// <returns>The display shape</returns>
        dynamic BuildDisplay(IContent content, string displayType = "", string groupId = "");
        /// Builds the editor shape of the specified content item
        /// <param name="groupId">Id of the editor group (stored in the content item's metadata)</param>
        /// <returns>The editor shape</returns>
        dynamic BuildEditor(IContent content, string groupId = "");
        /// Updates the content item and its editor shape with new data through an IUpdateModel
        /// <param name="content">The content item to update</param>
        /// <param name="updater">The updater to use for updating</param>
        /// <returns>The updated editor shape</returns>
        dynamic UpdateEditor(IContent content, IUpdateModel updater, string groupId = "");
    }
    public interface IContentDisplay : IDependency {
    public class VersionOptions {
        /// Gets the latest version.
        public static VersionOptions Latest { get { return new VersionOptions { IsLatest = true }; } }
        /// Gets the latest published version.
        public static VersionOptions Published { get { return new VersionOptions { IsPublished = true }; } }
        /// Gets the latest draft version.
        public static VersionOptions Draft { get { return new VersionOptions { IsDraft = true }; } }
        /// Gets the latest version and creates a new version draft based on it.
        public static VersionOptions DraftRequired { get { return new VersionOptions { IsDraft = true, IsDraftRequired = true }; } }
        /// Gets all versions.
        public static VersionOptions AllVersions { get { return new VersionOptions { IsAllVersions = true }; } }
        /// Gets a specific version based on its number.
        public static VersionOptions Number(int version) { return new VersionOptions { VersionNumber = version }; }
        /// Gets a specific version based on the version record identifier.
        public static VersionOptions VersionRecord(int id) { return new VersionOptions { VersionRecordId = id }; }
        /// Creates a new version based on the specified version number.
        public static VersionOptions Restore(int version, bool publish = false) { return new VersionOptions { VersionNumber = version, IsPublished = publish}; }
        public bool IsLatest { get; private set; }
        public bool IsPublished { get; private set; }
        public bool IsDraft { get; private set; }
        public bool IsDraftRequired { get; private set; }
        public bool IsAllVersions { get; private set; }
        public int VersionNumber { get; private set; }
        public int VersionRecordId { get; private set; }
}
