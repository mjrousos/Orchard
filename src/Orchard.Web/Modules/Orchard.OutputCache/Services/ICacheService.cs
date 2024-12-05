using Orchard.ContentManagement;
using Orchard.Security;
using Orchard.UI.Admin;
using Orchard.DisplayManagement;
using Orchard.Localization;
using Orchard.Services;
using System.Web.Mvc;
using Orchard.Mvc.Filters;
﻿using System.Collections.Generic;
using System.Web;
using System.Web.Routing;
using Orchard.OutputCache.ViewModels;
using Orchard;
using Orchard.OutputCache.Models;

namespace Orchard.OutputCache.Services {
    public interface ICacheService : IDependency {
        /// <summary>
        /// Returns the parameters for a specific route
        /// </summary>
        /// <param name="key">The key representing the route</param>
        /// <returns>A <see cref="CacheParameterRecord"/> instance for the specified key, or <c>null</c></returns>
        CacheParameterRecord GetCacheParameterByKey(string key);
        /// Removes all cache entries associated with a specific tag.
        /// <param name="tag">The tag value.</param>
        void RemoveByTag(string tag);
        /// Returns the key representing a specific route in the DB.
        string GetRouteDescriptorKey(HttpContextBase httpContext, RouteBase route);
        /// Saves a set of <see cref="CacheRouteConfig"/> to the database.
        /// <param name="routeConfigs"></param>
        void SaveRouteConfigs(IEnumerable<CacheRouteConfig> routeConfigs);
        /// Returns all defined configurations for specific routes.
        IEnumerable<CacheRouteConfig> GetRouteConfigs();
    }
}
