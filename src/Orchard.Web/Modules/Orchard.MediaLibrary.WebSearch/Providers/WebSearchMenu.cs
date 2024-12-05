using Orchard.ContentManagement;
using Orchard.Security;
using Orchard.UI.Admin;
using Orchard.DisplayManagement;
using Orchard.Localization;
using Orchard.Services;
using System.Web.Mvc;
using Orchard.Mvc.Filters;
﻿using Orchard.Localization;
using Orchard.UI.Navigation;

namespace Orchard.MediaLibrary.WebSearch.Providers {
    public class WebSearchMenu : INavigationProvider {
        public Localizer T { get; set; }
        public WebSearchMenu() {
            T = NullLocalizer.Instance;
        }
        public string MenuName { get { return "mediaproviders"; } }
        public void GetNavigation(NavigationBuilder builder) {
            builder.AddImageSet("websearch")
                .Add(T("Web Search"), "7",
                    menu => menu.Action("Index", "WebSearch", new { area = "Orchard.MediaLibrary.WebSearch" })
                        .Permission(Permissions.AccessMediaWebSearch));
    }
}
