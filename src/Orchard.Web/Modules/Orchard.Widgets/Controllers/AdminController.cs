using Orchard.ContentManagement;
using Orchard.Security;
using Orchard.UI.Admin;
using Orchard.DisplayManagement;
using Orchard.Localization;
using Orchard.Services;
using System.Web.Mvc;
using Orchard.Mvc.Filters;
﻿using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using Orchard.Environment.Extensions.Models;
using Orchard.FileSystems.VirtualPath;
using Orchard.Logging;
using Orchard.Mvc;
using Orchard.Mvc.Extensions;
using Orchard.Themes.Services;
using Orchard.UI.Notify;
using Orchard.Widgets.Models;
using Orchard.Widgets.Services;
using Orchard.ContentManagement.Aspects;
using Orchard.Core.Contents.Settings;
using Orchard.Localization.Services;

namespace Orchard.Widgets.Controllers {
    [ValidateInput(false), Admin]
    public class AdminController : Controller, IUpdateModel {
        private readonly IWidgetsService _widgetsService;
        private readonly ISiteThemeService _siteThemeService;
        private readonly IVirtualPathProvider _virtualPathProvider;
        private readonly ICultureManager _cultureManager;
        public AdminController(
            IOrchardServices services,
            IWidgetsService widgetsService,
            IShapeFactory shapeFactory,
            ISiteThemeService siteThemeService,
            IVirtualPathProvider virtualPathProvider,
            ICultureManager cultureManager) {
            Services = services;
            _widgetsService = widgetsService;
            _siteThemeService = siteThemeService;
            _virtualPathProvider = virtualPathProvider;
            _cultureManager = cultureManager;
            T = NullLocalizer.Instance;
            Logger = NullLogger.Instance;
            Shape = shapeFactory;
        }
        private IOrchardServices Services { get; set; }
        public Localizer T { get; set; }
        public ILogger Logger { get; set; }
        dynamic Shape { get; set; }
        public ActionResult Index(int? layerId, string culture) {
            ExtensionDescriptor currentTheme = _siteThemeService.GetSiteTheme();
            if (currentTheme == null) {
                Services.Notifier.Error(T("To manage widgets you must have a theme enabled."));
                return RedirectToAction("Index", "Admin", new { area = "Dashboard" });
            }
            IEnumerable<LayerPart> layers = _widgetsService.GetLayers().OrderBy(x => x.Name).ToList();
            if (!layers.Any()) {
                Services.Notifier.Error(T("There are no widget layers defined. A layer will need to be added in order to add widgets to any part of the site."));
                return RedirectToAction("AddLayer");
            LayerPart currentLayer = layerId == null
                // look for the "Default" layer, or take the first if it doesn't exist
                ? layers.FirstOrDefault(x => x.Name == "Default") ?? layers.FirstOrDefault()
                : layers.FirstOrDefault(layer => layer.Id == layerId);
            if (currentLayer == null && layerId != null) { // Incorrect layer id passed
                Services.Notifier.Error(T("Layer not found: {0}", layerId));
                return RedirectToAction("Index");
            IEnumerable<string> allZones = _widgetsService.GetZones();
            IEnumerable<string> currentThemesZones = _widgetsService.GetZones(currentTheme);
            string zonePreviewImagePath = string.Format("{0}/{1}/ThemeZonePreview.png", currentTheme.Location, currentTheme.Id);
            string zonePreviewImage = _virtualPathProvider.FileExists(zonePreviewImagePath) ? zonePreviewImagePath : null;
            var widgets = _widgetsService.GetWidgets();
            if (!String.IsNullOrWhiteSpace(culture)) {
                widgets = widgets.Where(x => {
                    if (x.Has<ILocalizableAspect>()) {
                        return String.Equals(x.As<ILocalizableAspect>().Culture, culture, StringComparison.InvariantCultureIgnoreCase);
                    }
                    return false;
                }).ToList();
            var viewModel = Shape.ViewModel()
                .CurrentTheme(currentTheme)
                .CurrentLayer(currentLayer)
                .CurrentCulture(culture)
                .Layers(layers)
                .Widgets(widgets)
                .Zones(currentThemesZones)
                .Cultures(_cultureManager.ListCultures())
                .OrphanZones(allZones.Except(currentThemesZones))
                .OrphanWidgets(_widgetsService.GetOrphanedWidgets())
                .ZonePreviewImage(zonePreviewImage);
            return View(viewModel);
        [HttpPost, ActionName("Index")]
        public ActionResult IndexWidgetPOST(int widgetId, string returnUrl, int? layerId, string moveUp, string moveDown, string moveHere, string moveOut) {
            if (!string.IsNullOrWhiteSpace(moveOut))
                return DeleteWidget(widgetId, returnUrl);
            if (!IsAuthorizedToManageWidgets())
                return new HttpUnauthorizedResult();
            if (!string.IsNullOrWhiteSpace(moveUp))
                _widgetsService.MoveWidgetUp(widgetId);
            else if (!string.IsNullOrWhiteSpace(moveDown))
                _widgetsService.MoveWidgetDown(widgetId);
            else if (!string.IsNullOrWhiteSpace(moveHere))
                _widgetsService.MoveWidgetToLayer(widgetId, layerId);
            return this.RedirectLocal(returnUrl, () => RedirectToAction("Index"));
        private bool IsAuthorizedToManageWidgets() {
            return Services.Authorizer.Authorize(Permissions.ManageWidgets, T("Not authorized to manage widgets."));
        public ActionResult ChooseWidget(int layerId, string zone, string returnUrl) {
            if (string.IsNullOrWhiteSpace(zone)) {
                Services.Notifier.Error(T("Need a zone specified for widget placement."));
            LayerPart currentLayer = layers.FirstOrDefault(layer => layer.Id == layerId);
            if (currentLayer == null) { // Incorrect layer id passed
                .Zone(zone)
                .WidgetTypes(_widgetsService.GetWidgetTypes())
                .ReturnUrl(returnUrl);
        public ActionResult AddWidget(int layerId, string widgetType, string zone, string returnUrl) {
            WidgetPart widgetPart = Services.ContentManager.New<WidgetPart>(widgetType);
            if (widgetPart == null)
                return HttpNotFound();
            try {
                int widgetPosition = _widgetsService.GetWidgets().Count(widget => widget.Zone == widgetPart.Zone) + 1;
                widgetPart.Position = widgetPosition.ToString(CultureInfo.InvariantCulture);
                widgetPart.Zone = zone;
                widgetPart.LayerPart = _widgetsService.GetLayer(layerId);
                var model = Services.ContentManager.BuildEditor(widgetPart);
                return View(model);
            catch (Exception exception) {
                Logger.Error(T("Creating widget failed: {0}", exception.Message).Text);
                Services.Notifier.Error(T("Creating widget failed: {0}", exception.Message));
                return this.RedirectLocal(returnUrl, () => RedirectToAction("Index"));
        [HttpPost, ActionName("AddWidget")]
        [FormValueRequired("submit.Save")]
        public ActionResult AddWidgetSavePOST([Bind(Prefix = "WidgetPart.LayerId")] int layerId, string widgetType, string returnUrl) {
            return AddWidgetPOST(layerId, widgetType, returnUrl, contentItem => {
                if (!contentItem.Has<IPublishingControlAspect>() && !contentItem.TypeDefinition.Settings.GetModel<ContentTypeSettings>().Draftable)
                    Services.ContentManager.Publish(contentItem);
            });
        [FormValueRequired("submit.Publish")]
        public ActionResult AddWidgetPublishPOST([Bind(Prefix = "WidgetPart.LayerId")] int layerId, string widgetType, string returnUrl) {
            return AddWidgetPOST(layerId, widgetType, returnUrl, contentItem => Services.ContentManager.Publish(contentItem));
        private ActionResult AddWidgetPOST([Bind(Prefix = "WidgetPart.LayerId")] int layerId, string widgetType, string returnUrl, Action<ContentItem> conditionallyPublish) {
            var widgetPart = _widgetsService.CreateWidget(layerId, widgetType, "", "", "");
            var model = Services.ContentManager.UpdateEditor(widgetPart, this);
                // override the CommonPart's persisting of the current container
                conditionallyPublish(widgetPart.ContentItem);
            if (!ModelState.IsValid) {
                Services.TransactionManager.Cancel();
            Services.Notifier.Success(T("Your {0} has been added.", widgetPart.TypeDefinition.DisplayName));
        public ActionResult AddLayer(string name, string description, string layerRule) { // <- hints for a new layer
            LayerPart layerPart = Services.ContentManager.New<LayerPart>("Layer");
            if (layerPart == null)
            var model = Services.ContentManager.BuildEditor(layerPart);
            // only messing with the hints if they're given
            if (!string.IsNullOrWhiteSpace(name))
                model.Name = name;
            if (!string.IsNullOrWhiteSpace(description))
                model.Description = description;
            if (!string.IsNullOrWhiteSpace(layerRule))
                model.LayerRule = layerRule;
            return View(model);
        [HttpPost, ActionName("AddLayer")]
        public ActionResult AddLayerPOST() {
            LayerPart layerPart = _widgetsService.CreateLayer("", "", "");
            var model = Services.ContentManager.UpdateEditor(layerPart, this);
            Services.Notifier.Success(T("Your {0} has been created.", layerPart.TypeDefinition.DisplayName));
            return RedirectToAction("Index", "Admin", new { layerId = layerPart.Id });
        public ActionResult EditLayer(int id) {
            LayerPart layerPart = _widgetsService.GetLayer(id);
        [HttpPost, ActionName("EditLayer")]
        public ActionResult EditLayerSavePOST(int id, string returnUrl) {
            Services.Notifier.Success(T("Your {0} has been saved.", layerPart.TypeDefinition.DisplayName));
        [FormValueRequired("submit.Delete")]
        public ActionResult EditLayerDeletePOST(int id) {
                _widgetsService.DeleteLayer(id);
                Services.Notifier.Success(T("Layer was successfully deleted"));
                Logger.Error(T("Removing Layer failed: {0}", exception.Message).Text);
                Services.Notifier.Error(T("Removing Layer failed: {0}", exception.Message));
            return RedirectToAction("Index", "Admin");
        public ActionResult EditWidget(int id) {
            WidgetPart widgetPart = null;
            widgetPart = _widgetsService.GetWidget(id);
            if (widgetPart == null) {
                Services.Notifier.Error(T("Widget not found: {0}", id));
                Logger.Error(T("Editing widget failed: {0}", exception.Message).Text);
                Services.Notifier.Error(T("Editing widget failed: {0}", exception.Message));
                if (widgetPart != null && widgetPart.LayerPart != null)
                    return RedirectToAction("Index", "Admin", new { layerId = widgetPart.LayerPart.Id });
        [HttpPost, ActionName("EditWidget")]
        public ActionResult EditWidgetSavePOST(int id, [Bind(Prefix = "WidgetPart.LayerId")] int layerId, string returnUrl) {
            return EditWidgetPOST(id, layerId, returnUrl, contentItem => {
        public ActionResult EditWidgetPublishPOST(int id, [Bind(Prefix = "WidgetPart.LayerId")] int layerId, string returnUrl) {
                Services.ContentManager.Publish(contentItem);
        private ActionResult EditWidgetPOST(int id, int layerId, string returnUrl, Action<ContentItem> conditionallyPublish) {
            widgetPart = Services.ContentManager.Get<WidgetPart>(id, VersionOptions.DraftRequired);
                var model = Services.ContentManager.UpdateEditor(widgetPart, this);
                if (!ModelState.IsValid) {
                    Services.TransactionManager.Cancel();
                    return View(model);
                }
                Services.Notifier.Success(T("Your {0} has been saved.", widgetPart.TypeDefinition.DisplayName));
        public ActionResult EditWidgetDeletePOST(int id, string returnUrl) {
            return DeleteWidget(id, returnUrl);
        private ActionResult DeleteWidget(int id, string returnUrl) {
                _widgetsService.DeleteWidget(widgetPart.Id);
                Services.Notifier.Success(T("Widget was successfully deleted"));
                Logger.Error(T("Removing Widget failed: {0}", exception.Message).Text);
                Services.Notifier.Error(T("Removing Widget failed: {0}", exception.Message));
        bool IUpdateModel.TryUpdateModel<TModel>(TModel model, string prefix, string[] includeProperties, string[] excludeProperties) {
            return base.TryUpdateModel(model, prefix, includeProperties, excludeProperties);
        void IUpdateModel.AddModelError(string key, LocalizedString errorMessage) {
            ModelState.AddModelError(key, errorMessage.ToString());
    }
}
