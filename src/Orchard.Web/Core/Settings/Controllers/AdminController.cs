using Orchard.ContentManagement;
using Orchard.Security;
using Orchard.UI.Admin;
using Orchard.DisplayManagement;
using Orchard.Localization;
using Orchard.Services;
using System.Web.Mvc;
using Orchard.Mvc.Filters;
﻿using System.Globalization;
using System.Linq;
using Orchard.Core.Settings.ViewModels;
using Orchard.Localization.Services;
using Orchard.Settings;
using Orchard.UI.Notify;

namespace Orchard.Core.Settings.Controllers {
    [ValidateInput(false)]
    public class AdminController : Controller, IUpdateModel {
        private readonly ISiteService _siteService;
        private readonly ICultureManager _cultureManager;
        public IOrchardServices Services { get; private set; }
        public AdminController(
            ISiteService siteService,
            IOrchardServices services,
            ICultureManager cultureManager) {
            _siteService = siteService;
            _cultureManager = cultureManager;
            Services = services;
            T = NullLocalizer.Instance;
        }
        public Localizer T { get; set; }
        public ActionResult Index(string groupInfoId) {
            if (!Services.Authorizer.Authorize(Permissions.ManageSettings, T("Not authorized to manage settings")))
                return new HttpUnauthorizedResult();
            dynamic model;
            var site = _siteService.GetSiteSettings();
            if (!string.IsNullOrWhiteSpace(groupInfoId)) {
                model = Services.ContentManager.BuildEditor(site, groupInfoId);
                if (model == null)
                    return HttpNotFound();
                var groupInfo = Services.ContentManager.GetEditorGroupInfo(site, groupInfoId);
                if (groupInfo == null)
                model.GroupInfo = groupInfo;
            }
            else {
                model = Services.ContentManager.BuildEditor(site);
            return View(model);
        [HttpPost, ActionName("Index")]
        public ActionResult IndexPOST(string groupInfoId) {
            var model = Services.ContentManager.UpdateEditor(site, this, groupInfoId);
            GroupInfo groupInfo = null;
                if (model == null) {
                    Services.TransactionManager.Cancel();
                }
                groupInfo = Services.ContentManager.GetEditorGroupInfo(site, groupInfoId);
                if (groupInfo == null) {
            if (!ModelState.IsValid) {
                Services.TransactionManager.Cancel();
                return View(model);
            Services.Notifier.Success(T("Settings updated"));
            return RedirectToAction("Index");
        public ActionResult Culture() {
            //todo: class and/or method attributes for our auth?
            var model = new SiteCulturesViewModel {
                CurrentCulture = _cultureManager.GetCurrentCulture(HttpContext),
                SiteCultures = _cultureManager.ListCultures(),
            };
            model.AvailableSystemCultures = CultureInfo.GetCultures(CultureTypes.SpecificCultures)
                .Select(ci => ci.Name)
                .Where(s => !model.SiteCultures.Contains(s));
        [HttpPost]
        public ActionResult AddCulture(string systemCultureName, string cultureName) {
            cultureName = string.IsNullOrWhiteSpace(cultureName) ? systemCultureName : cultureName;
            if (!string.IsNullOrWhiteSpace(cultureName)) {
                _cultureManager.AddCulture(cultureName);
            return RedirectToAction("Culture");
        public ActionResult DeleteCulture(string cultureName) {
            _cultureManager.DeleteCulture(cultureName);
        bool IUpdateModel.TryUpdateModel<TModel>(TModel model, string prefix, string[] includeProperties, string[] excludeProperties) {
            return TryUpdateModel(model, prefix, includeProperties, excludeProperties);
        void IUpdateModel.AddModelError(string key, LocalizedString errorMessage) {
            ModelState.AddModelError(key, errorMessage.ToString());
    }
}
