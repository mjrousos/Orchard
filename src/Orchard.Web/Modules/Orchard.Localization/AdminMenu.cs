using Orchard.ContentManagement;
using Orchard.Security;
using Orchard.UI.Admin;
using Orchard.DisplayManagement;
using Orchard.Localization;
using Orchard.Services;
using System.Web.Mvc;
using Orchard.Mvc.Filters;
using Orchard.Environment.Extensions;
using Orchard.UI.Navigation;

namespace Orchard.Localization {
    [OrchardFeature("Orchard.Localization.Transliteration")]
    public class AdminMenu : INavigationProvider {
        public Localizer T { get; set; }
        public string MenuName { get { return "admin"; } }
        public void GetNavigation(NavigationBuilder builder) {
            builder
                .Add(T("Settings"), menu => menu
                    .Add(T("Transliteration"), "10.0", subMenu => subMenu.Action("Index", "TransliterationAdmin", new { area = "Orchard.Localization" })
                        .Add(T("Settings"), "10.0", item => item.Action("Index", "TransliterationAdmin", new { area = "Orchard.Localization" }).LocalNav())
                    ));
        }
    }
}
