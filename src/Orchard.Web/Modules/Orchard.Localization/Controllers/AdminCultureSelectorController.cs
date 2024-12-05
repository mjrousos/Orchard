using Orchard.ContentManagement;
using Orchard.Security;
using Orchard.UI.Admin;
using Orchard.DisplayManagement;
using Orchard.Localization;
using Orchard.Services;
using System.Web.Mvc;
using Orchard.Mvc.Filters;
using Orchard.Environment.Extensions;
using Orchard.Localization.Providers;
using Orchard.Mvc.Extensions;

namespace Orchard.Localization.Controllers {
    [OrchardFeature("Orchard.Localization.CultureSelector")]
    [Admin]
    public class AdminCultureSelectorController : Controller {
        private readonly ICultureStorageProvider _cultureStorageProvider;
        public AdminCultureSelectorController(ICultureStorageProvider cultureStorageProvider) {
            _cultureStorageProvider = cultureStorageProvider;
        }
        public ActionResult ChangeCulture(string culture, string returnUrl) {
            _cultureStorageProvider.SetCulture(culture);
            return this.RedirectLocal(returnUrl);
    }
}
