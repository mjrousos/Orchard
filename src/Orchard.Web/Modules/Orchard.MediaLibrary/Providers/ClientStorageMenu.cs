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
    public class ClientStorageMenu : INavigationProvider {
        public Localizer T { get; set; }
        public ClientStorageMenu() {
            T = NullLocalizer.Instance;
        }
        public string MenuName { get { return "mediaproviders"; } }
        public void GetNavigation(NavigationBuilder builder) {
            builder.AddImageSet("clientstorage")
                .Add(T("My Computer"), "5", 
                    menu => menu.Action("Index", "ClientStorage", new { area = "Orchard.MediaLibrary" })
                        .Permission(Permissions.ManageOwnMedia)
                        .Permission(Permissions.ImportMediaContent));
    }
}
