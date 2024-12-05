using Orchard.ContentManagement;
using Orchard.Security;
using Orchard.UI.Admin;
using Orchard.DisplayManagement;
using Orchard.Localization;
using Orchard.Services;
using System.Web.Mvc;
using Orchard.Mvc.Filters;
using System.Globalization;
using Orchard.ContentManagement.Aspects;

namespace Orchard.Localization {
    public static class LocalizationExtensions {
        public static CultureInfo CurrentCultureInfo(this WorkContext workContext) {
            return CultureInfo.GetCultureInfo(workContext.CurrentCulture);
        }
        public static string GetTextDirection(this WorkContext workContext) {
            return workContext.GetTextDirection(null);
        public static string GetTextDirection(this WorkContext workContext, IContent content) {
            var culture = workContext.CurrentSite.SiteCulture;
            if (content != null && content.Has<ILocalizableAspect>()) {
                culture = content.As<ILocalizableAspect>().Culture ?? culture;
            }
            return CultureInfo.GetCultureInfo(culture).TextInfo.IsRightToLeft ? "rtl" : "ltr"; ;
    }
}
