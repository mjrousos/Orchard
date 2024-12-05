using Orchard.ContentManagement;
using Orchard.Security;
using Orchard.UI.Admin;
using Orchard.DisplayManagement;
using Orchard.Localization;
using Orchard.Services;
using System.Web.Mvc;
using Orchard.Mvc.Filters;
﻿using System.Linq;
using System.Web;

namespace Orchard.OutputCache.Services {
    /// <summary>
    /// Represent the logic deciding if the result of an action can be cached
    /// </summary>
    public class DefaultCacheControlStrategy : ICacheControlStrategy {
        private static readonly string[] AuthorizedContentTypes = { "text/html", "text/xml", "text/json", "text/plain" };
        public bool IsCacheable(ActionResult result, HttpResponseBase response) {
            // only cache view results
            if (result is ViewResultBase) {
                return true;
            }
            if (result is FileResult) {
                return false;
            if (AuthorizedContentTypes.Contains(response.ContentType)) {
                return true;    
            return false;
        }
    }
}
