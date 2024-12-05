using Orchard.ContentManagement;
using Orchard.Security;
using Orchard.UI.Admin;
using Orchard.DisplayManagement;
using Orchard.Localization;
using Orchard.Services;
using System.Web.Mvc;
using Orchard.Mvc.Filters;
using System;
using System.Web;
using Orchard.Alias;
using Orchard.Environment.Configuration;
using Orchard.Environment.Extensions;
using Orchard.Localization.Services;

namespace Orchard.Localization.Selectors {
    [OrchardFeature("Orchard.Localization.CultureSelector")]
    public class ContentCultureSelector : ICultureSelector {
        private readonly IAliasService _aliasService;
        private readonly IContentManager _contentManager;
        private readonly Lazy<ILocalizationService> _localizationService;
        private readonly ShellSettings _shellSettings;
        public ContentCultureSelector(
            IAliasService aliasService,
            IContentManager contentManager,
            Lazy<ILocalizationService> localizationService,
            ShellSettings shellSettings) {
            _aliasService = aliasService;
            _contentManager = contentManager;
            _localizationService = localizationService;
            _shellSettings = shellSettings;
        }
        public CultureSelectorResult GetCulture(HttpContextBase context) {
            if (context == null || AdminFilter.IsApplied(context)) return null;
            // Attempt to determine culture by previous route if by POST
            string path;
            if (context.Request.HttpMethod.Equals(HttpVerbs.Post.ToString(), StringComparison.OrdinalIgnoreCase)) {
                if (context.Request.UrlReferrer != null)
                    path = context.Request.UrlReferrer.AbsolutePath;
                else
                    return null;
            }
            else {
                path = context.Request.Path;
            var appPath = context.Request.ApplicationPath ?? "/";
            var requestUrl = (path.StartsWith(appPath) ? path.Substring(appPath.Length) : path).TrimStart('/');
            var prefix = _shellSettings.RequestUrlPrefix;
            if (!string.IsNullOrEmpty(prefix)) {
                requestUrl = (requestUrl.StartsWith(prefix) ? requestUrl.Substring(prefix.Length) : requestUrl).TrimStart('/');
            var content = GetByPath(requestUrl);
            if (content != null) {
                return new CultureSelectorResult { Priority = -2, CultureName = _localizationService.Value.GetContentCulture(content) };
            return null;
        public IContent GetByPath(string aliasPath) {
            var contentRouting = _aliasService.Get(aliasPath);
            if (contentRouting == null)
                return null;
            object id;
            if (contentRouting.TryGetValue("id", out id)) {
                int contentId;
                if (int.TryParse(id as string, out contentId)) {
                    return _contentManager.Get(contentId);
                }
    }
}
