using Orchard.ContentManagement;
using Orchard.Security;
using Orchard.UI.Admin;
using Orchard.DisplayManagement;
using Orchard.Localization;
using Orchard.Services;
using System.Web.Mvc;
using Orchard.Mvc.Filters;
using System.Collections.Generic;
using Orchard.Tags.Models;

namespace Orchard.Tags.Services {
    public interface ITagService : IDependency {
        IEnumerable<TagRecord> GetTags();
        /// <summary>
        /// Returns tags whose name start with snippet
        /// </summary>
        /// <param name="snippet">The starting snippet</param>
        /// <param name="maxCount">Maximum number of tags returned</param>
        /// <returns>Tags found</returns>
        IEnumerable<TagRecord> GetTagsByNameSnippet(string snippet, int maxCount = 10);
        TagRecord GetTag(int tagId);
        TagRecord GetTagByName(string tagName);
        IEnumerable<IContent> GetTaggedContentItems(int tagId);
        IEnumerable<IContent> GetTaggedContentItems(int tagId, VersionOptions options);
        IEnumerable<IContent> GetTaggedContentItems(int tagId, int skip, int count);
        IEnumerable<IContent> GetTaggedContentItems(int tagId, int skip, int count, VersionOptions versionOptions);
        int GetTaggedContentItemCount(int tagId);
        int GetTaggedContentItemCount(int tagId, VersionOptions versionOptions);
        TagRecord CreateTag(string tagName);
        void DeleteTag(int tagId);
        void UpdateTag(int tagId, string tagName);
        void UpdateTagsForContentItem(ContentItem contentItem, IEnumerable<string> tagNamesForContentItem);
        void RemoveTagsForContentItem(ContentItem contentItem);
    }
}
