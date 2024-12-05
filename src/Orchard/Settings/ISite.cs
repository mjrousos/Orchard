using Orchard.ContentManagement;
using Orchard.Security;
using Orchard.UI.Admin;
using Orchard.DisplayManagement;
using Orchard.Localization;
using Orchard.Services;
using System.Web.Mvc;
using Orchard.Mvc.Filters;
﻿using Orchard.ContentManagement;

namespace Orchard.Settings {
    /// <summary>
    /// Interface provided by the "settings" model.
    /// </summary>
    public interface ISite : IContent {
        string PageTitleSeparator { get; }
        string SiteName { get; }
        string SiteSalt { get; }
        string SuperUser { get; }
        string HomePage { get; set; }
        string SiteCulture { get; set; }
        string SiteCalendar { get; set; }
        ResourceDebugMode ResourceDebugMode { get; set; }
        bool UseCdn { get; set; }
        bool UseFileHash { get; set; }
        int PageSize { get; set; }
        int MaxPageSize { get; set; }
        int MaxPagedCount { get; set; }
        string BaseUrl { get; }
        string SiteTimeZone { get; }
    }
}
