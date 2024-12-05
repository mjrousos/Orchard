using Orchard.ContentManagement;
using Orchard.Security;
using Orchard.UI.Admin;
using Orchard.DisplayManagement;
using Orchard.Localization;
using Orchard.Services;
using System.Web.Mvc;
using Orchard.Mvc.Filters;
﻿using Orchard.Environment.Extensions;
using Orchard.UI.Navigation;
using Orchard.Environment.Configuration;

namespace Orchard.Packaging {
    [OrchardFeature("Gallery")]
    public class AdminMenu : INavigationProvider {
        public Localizer T { get; set; }
        public string MenuName {
            get { return "admin"; }
        }
        private readonly ShellSettings _shellSettings;
        public AdminMenu(ShellSettings shellSettings) {
            _shellSettings = shellSettings;
        public void GetNavigation(NavigationBuilder builder) {
            if (_shellSettings.Name.ToLower() == "default") {
                builder
                    .Add(T("Modules"), menu => menu
                        .Add(T("Gallery"), "3", item => Describe(item, "Modules", "Gallery", true)))
                    .Add(T("Themes"), menu => menu
                        .Add(T("Gallery"), "3", item => Describe(item, "Themes", "Gallery", true)))
                    .Add(T("Settings"), menu => menu
                        .Add(T("Gallery"), "1", item => Describe(item, "Sources", "Gallery", false)));
            }
        static NavigationItemBuilder Describe(NavigationItemBuilder item, string actionName, string controllerName, bool localNav) {
            item = item.Action(actionName, controllerName, new { area = "Orchard.Packaging" }).Permission(StandardPermissions.SiteOwner);
            if (localNav)
                item = item.LocalNav();
            return item;
    }
}
