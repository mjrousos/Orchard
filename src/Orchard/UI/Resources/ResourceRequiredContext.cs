using Orchard.ContentManagement;
using Orchard.Security;
using Orchard.UI.Admin;
using Orchard.DisplayManagement;
using Orchard.Localization;
using Orchard.Services;
using System.Web.Mvc;
using Orchard.Mvc.Filters;

namespace Orchard.UI.Resources {
    public class ResourceRequiredContext {
        public ResourceDefinition Resource { get; set; }
        public RequireSettings Settings { get; set; }
        public string GetResourceUrl(RequireSettings baseSettings, string appPath, IResourceFileHashProvider resourceFileHashProvider) {
            return Resource.ResolveUrl(baseSettings == null ? Settings : baseSettings.Combine(Settings), appPath, resourceFileHashProvider);
        }
        public TagBuilder GetTagBuilder(RequireSettings baseSettings, string appPath, IResourceFileHashProvider resourceFileHashProvider) {
            var tagBuilder = new TagBuilder(Resource.TagName);
            tagBuilder.MergeAttributes(Resource.TagBuilder.Attributes);
            if (!string.IsNullOrEmpty(Resource.FilePathAttributeName)) {
                var resolvedUrl = GetResourceUrl(baseSettings, appPath, resourceFileHashProvider);
                if (!string.IsNullOrEmpty(resolvedUrl)) {
                    tagBuilder.MergeAttribute(Resource.FilePathAttributeName, resolvedUrl, true);
                }
            }
            return tagBuilder;
    }
}
