using Orchard.ContentManagement;
using Orchard.Security;
using Orchard.UI.Admin;
using Orchard.DisplayManagement;
using Orchard.Localization;
using Orchard.Services;
using System.Web.Mvc;
using Orchard.Mvc.Filters;
﻿using System;
using Orchard.MediaLibrary.WebSearch.Providers;

namespace Orchard.MediaLibrary.WebSearch {
    public static class WebSearchProviderExtensions {
        public static string GetApiKey(this IWebSearchProvider provider) => provider.Settings.ApiKey;
        public static bool IsValid(this IWebSearchProvider provider) => !String.IsNullOrEmpty(provider.GetApiKey());
    }
}
