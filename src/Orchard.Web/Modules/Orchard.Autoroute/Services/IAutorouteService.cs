using Orchard.ContentManagement;
using Orchard.Security;
using Orchard.UI.Admin;
using Orchard.DisplayManagement;
using Orchard.Localization;
using Orchard.Services;
using System.Web.Mvc;
using Orchard.Mvc.Filters;
﻿using System.Collections.Generic;
using Orchard.Autoroute.Models;
using Orchard.Autoroute.Settings;

namespace Orchard.Autoroute.Services {
    /// <summary>
    /// Provides main services for Autoroute module
    /// </summary>
    public interface IAutorouteService : IDependency {
        string GenerateAlias(AutoroutePart part);
        void PublishAlias(AutoroutePart part);
        void RemoveAliases(AutoroutePart part);
        void CreatePattern(string contentType, string name, string pattern, string description, bool makeDefault);
        RoutePattern GetDefaultPattern(string contentType, string culture);
        IEnumerable<RoutePattern> GetPatterns(string contentType);
        bool ProcessPath(AutoroutePart part);
        bool IsPathValid(string slug);
    }
}
