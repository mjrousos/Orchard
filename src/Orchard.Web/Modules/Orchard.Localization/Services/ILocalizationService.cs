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
using Orchard.Localization.Models;

namespace Orchard.Localization.Services {
    public interface ILocalizationService : IDependency {
        LocalizationPart GetLocalizedContentItem(IContent content, string culture);
        LocalizationPart GetLocalizedContentItem(IContent content, string culture, VersionOptions versionOptions);
        string GetContentCulture(IContent content);
        void SetContentCulture(IContent content, string culture);
        IEnumerable<LocalizationPart> GetLocalizations(IContent content);
        IEnumerable<LocalizationPart> GetLocalizations(IContent content, VersionOptions versionOptions);
        bool TryFindLocalizedRoute(ContentItem routableContent, string cultureName, out AutoroutePart localizedRoute);
        bool TryGetRouteForUrl(string url, out AutoroutePart route);
    }
}
