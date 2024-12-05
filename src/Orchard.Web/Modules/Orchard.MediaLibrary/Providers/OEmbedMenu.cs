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

namespace Orchard.MediaLibrary.Providers {
    public class OEmbedMenu : INavigationProvider {
        public Localizer T { get; set; }
        public OEmbedMenu() {
            T = NullLocalizer.Instance;
        }
        public string MenuName { get { return "mediaproviders"; } }
        public void GetNavigation(NavigationBuilder builder) {
            builder.AddImageSet("oembed")
                .Add(T("Media Url"), "10", 
                    menu => menu.Action("Index", "OEmbed", new { area = "Orchard.MediaLibrary" })
                        .Permission(Permissions.ManageOwnMedia)
                        .Permission(Permissions.ImportMediaContent));
    }
}
