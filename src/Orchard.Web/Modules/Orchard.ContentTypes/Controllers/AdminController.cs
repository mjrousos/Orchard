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
using System.Linq;
using Orchard.ContentManagement.MetaData;
using Orchard.ContentManagement.MetaData.Models;
using Orchard.ContentTypes.Extensions;
using Orchard.ContentTypes.Services;
using Orchard.ContentTypes.Settings;
using Orchard.ContentTypes.ViewModels;
using Orchard.Core.Contents.Settings;
using Orchard.Environment.Configuration;
using Orchard.Logging;
using Orchard.Mvc;
using Orchard.UI;
using Orchard.UI.Notify;
using Orchard.Utility.Extensions;

namespace Orchard.ContentTypes.Controllers {
    [ValidateInput(false)]
    public class AdminController : Controller, IUpdateModel {
        private readonly IContentDefinitionService _contentDefinitionService;
        private readonly IContentDefinitionManager _contentDefinitionManager;
        private readonly IPlacementService _placementService;
        private readonly Lazy<IEnumerable<IShellSettingsManagerEventHandler>> _settingsManagerEventHandlers;
        private readonly ShellSettings _settings;
        public AdminController(
            IOrchardServices orchardServices,
            IContentDefinitionService contentDefinitionService,
            IContentDefinitionManager contentDefinitionManager,
            IPlacementService placementService,
            Lazy<IEnumerable<IShellSettingsManagerEventHandler>> settingsManagerEventHandlers,
            ShellSettings settings) {
            Services = orchardServices;
            _contentDefinitionService = contentDefinitionService;
            _contentDefinitionManager = contentDefinitionManager;
            _placementService = placementService;
            _settingsManagerEventHandlers = settingsManagerEventHandlers;
            _settings = settings;
            T = NullLocalizer.Instance;
        }
        public IOrchardServices Services { get; private set; }
        public Localizer T { get; set; }
        public ILogger Logger { get; set; }
        public ActionResult Index() { return List(); }
        #region Types
        public ActionResult List() {
            if (!Services.Authorizer.Authorize(Permissions.ViewContentTypes, T("Not allowed to view content types.")))
                return new HttpUnauthorizedResult();
            return View("List", new ListContentTypesViewModel {
                Types = _contentDefinitionService.GetTypes()
            });
        public ActionResult Create(string suggestion) {
            if (!Services.Authorizer.Authorize(Permissions.EditContentTypes, T("Not allowed to create a content type.")))
            return View(new CreateTypeViewModel { DisplayName = suggestion?.Trim(), Name = suggestion?.ToSafeName() });
        [HttpPost, ActionName("Create")]
        public ActionResult CreatePOST(CreateTypeViewModel viewModel) {
            ValidateDisplayName(viewModel.DisplayName);
            // Additional Display Name validation.
            if (!string.IsNullOrWhiteSpace(viewModel.DisplayName) &&
                _contentDefinitionService.GetTypes().Any(t => string.Equals(t.DisplayName.Trim(), viewModel.DisplayName.Trim(), StringComparison.OrdinalIgnoreCase))) {
                ModelState.AddModelError("DisplayName", T("A content type with this display name already exists.").Text);
            }
            ValidateTechnicalName(viewModel.Name);
            // Additional Technical Name validation.
            if (!string.IsNullOrWhiteSpace(viewModel.Name) &&
                _contentDefinitionService.GetTypes().Any(t => string.Equals(t.Name.ToSafeName(), viewModel.Name.ToSafeName(), StringComparison.OrdinalIgnoreCase))) {
                ModelState.AddModelError("Name", T("A content type with this technical name already exists.").Text);
            if (!ModelState.IsValid) {
                Services.TransactionManager.Cancel();
                return View(viewModel);
            var contentTypeDefinition = _contentDefinitionService.AddType(viewModel.Name, viewModel.DisplayName);
            // CommonPart is added by default to all Content Types.
            _contentDefinitionService.AddPartToType("CommonPart", viewModel.Name);
            var typeViewModel = new EditTypeViewModel(contentTypeDefinition);
            Services.Notifier.Success(T("The \"{0}\" content type has been created.", typeViewModel.DisplayName));
            return RedirectToAction("AddPartsTo", new { id = typeViewModel.Name });
        public ActionResult ContentTypeName(string displayName, int version) {
            return Json(new {
                result = _contentDefinitionService.GenerateContentTypeNameFromDisplayName(displayName),
                version
        public ActionResult FieldName(string partName, string displayName, int version) {
                result = _contentDefinitionService.GenerateFieldNameFromDisplayName(partName, displayName),
        public ActionResult Edit(string id) {
            if (!Services.Authorizer.Authorize(Permissions.EditContentTypes, T("Not allowed to edit a content type.")))
            var typeViewModel = _contentDefinitionService.GetType(id);
            if (typeViewModel == null) return HttpNotFound();
            return View(typeViewModel);
        public ActionResult EditPlacement(string id) {
            var contentTypeDefinition = _contentDefinitionManager.GetTypeDefinition(id);
            if (contentTypeDefinition == null) return HttpNotFound();
            //Grouping Tabs > Cards > Shapes
            var grouped = _placementService
                // Get a collection of objects that describe the placement for all shapes
                // in the editor view for a ContentItem of the given ContentType
                .GetEditorPlacement(id)
                // Order all those shapes based on their position
                .OrderBy(x => x.PlacementInfo.GetPosition(), new FlatPositionComparer())
                // Then alphabetically by their shape type
                .ThenBy(x => x.PlacementSettings.ShapeType)
                // only pick those shapes that live int the "Content" zone
                .Where(e => e.PlacementSettings.Zone == "Content")
                // Form groups whose key is a string like {tabName}%{cardName}. Items
                // in a group represent the shapes that will be in the card called {cardName}
                // in the tab called {tabName}.
                .GroupBy(g => g.PlacementInfo.GetTab() + "%" + g.PlacementInfo.GetCard())
                // Transform each of those groups in an object representing the single cards.
                // Each of these objects contains the name of the tab that contains it, as
                // well as the list of shape placements in that card
                .Select(x =>
                    new Card {
                        Name = x.Key.Split('%')[1],
                        TabName = x.Key.Split('%')[0],
                        Placements = x.ToList()
                    })
                // Group cards by tab
                .GroupBy(x => x.TabName)
                // Since each of those groups "represents" a card, we actually make it into one.
                    new Tab {
                        Name = x.Key,
                        Cards = x.ToList()
                // Make the collection into a List<Tab> because it's easy to interact with it
                // (see later in the code)
                .ToList();
            var listPlacements = grouped
                // By selecting all placements from the Tab objects we built earlier, we have
                // them ordered nicely
                .SelectMany(x => x.Cards.SelectMany(m => m.Placements))
            // We want to have an un-named "default" Tab for shapes, in case none was defined
            Tab content;
            if (grouped.Any(x => string.IsNullOrWhiteSpace(x.Name))) {
                // Because of the way the elements of the list have been ordered above,
                // if there is a Tab with empty name, it is the first in the list.
                content = grouped[0];
                grouped.Remove(content);
            } else {
                content = new Tab {
                    Name = "",
                    Cards = new List<Card> { new Card { Name = "", TabName = "", Placements = new List<DriverResultPlacement>() } }
                };
            // In each Tab, we want to have a "default" un-named Card. This will simplfy
            // UI interactions, because it ensures that each Tab has some place we can drop
            // shapes in.
            for (int i = 0; i < grouped.Count(); i++) {
                if (!grouped[i].Cards.Any(x => string.IsNullOrEmpty(x.Name))) {
                    grouped[i].Cards.Insert(0, new Card { Name = "", TabName = grouped[i].Name, Placements = new List<DriverResultPlacement>() });
                }
            var placementModel = new EditPlacementViewModel {
                Content = content,
                AllPlacements = listPlacements,
                Tabs = grouped,
                ContentTypeDefinition = contentTypeDefinition,
            };
            return View(placementModel);
        [HttpPost, ActionName("EditPlacement")]
        [FormValueRequired("submit.Save")]
        public ActionResult EditPlacementPost(string id, EditPlacementViewModel viewModel) {
            contentTypeDefinition.ResetPlacement(PlacementType.Editor);
            foreach (var placement in viewModel.AllPlacements) {
                var placementSetting = placement.PlacementSettings;
                contentTypeDefinition.Placement(
                    PlacementType.Editor,
                    placementSetting.ShapeType,
                    placementSetting.Differentiator,
                    placementSetting.Zone,
                    placementSetting.Position);
            // Persist placement changes.
            _contentDefinitionManager.StoreTypeDefinition(contentTypeDefinition);
            _settingsManagerEventHandlers.Value.Invoke(x => x.Saved(_settings), Logger);
            return RedirectToAction("EditPlacement", new { id });
        [FormValueRequired("submit.Restore")]
        public ActionResult EditPlacementRestorePost(string id, EditPlacementViewModel viewModel) {
            // Persist placement reset.
        [HttpPost, ActionName("Edit")]
        public ActionResult EditPOST(string id) {
            var edited = new EditTypeViewModel();
            TryUpdateModel(edited);
            ValidateDisplayName(edited.DisplayName);
            if (!string.IsNullOrWhiteSpace(edited.DisplayName) &&
                _contentDefinitionService.GetTypes().Any(t =>
                    !string.Equals(t.Name, edited.Name, StringComparison.OrdinalIgnoreCase) &&
                    string.Equals(t.DisplayName.Trim(), edited.DisplayName.Trim(), StringComparison.OrdinalIgnoreCase))) {
            if (!ModelState.IsValid) return View(typeViewModel);
            typeViewModel.DisplayName = edited.DisplayName;
            _contentDefinitionService.AlterType(typeViewModel, this);
                return View(typeViewModel);
            Services.Notifier.Success(T("\"{0}\" settings have been saved.", typeViewModel.DisplayName));
            return RedirectToAction("Edit", new { id });
        [FormValueRequired("submit.Delete")]
        public ActionResult Delete(string id) {
            if (!Services.Authorizer.Authorize(Permissions.EditContentTypes, T("Not allowed to delete a content type.")))
            _contentDefinitionService.RemoveType(id, true);
            Services.Notifier.Success(T("\"{0}\" has been removed.", typeViewModel.DisplayName));
            return RedirectToAction("List");
        public ActionResult AddPartsTo(string id) {
            var typePartNames = new HashSet<string>(typeViewModel.Parts.Select(tvm => tvm.PartDefinition.Name));
            var viewModel = new AddPartsViewModel {
                Type = typeViewModel,
                PartSelections = _contentDefinitionService.GetParts(metadataPartsOnly: false)
                    .Where(cpd => !typePartNames.Contains(cpd.Name) && cpd.Settings.GetModel<ContentPartSettings>().Attachable)
                    .Select(cpd => new PartSelectionViewModel { PartName = cpd.Name, PartDisplayName = cpd.DisplayName, PartDescription = cpd.Description })
                    .ToList()
            return View(viewModel);
        [HttpPost, ActionName("AddPartsTo")]
        public ActionResult AddPartsToPOST(string id) {
            var viewModel = new AddPartsViewModel();
            if (!TryUpdateModel(viewModel)) return AddPartsTo(id);
            var partsToAdd = viewModel.PartSelections.Where(ps => ps.IsSelected).Select(ps => ps.PartName);
            foreach (var partToAdd in partsToAdd) {
                _contentDefinitionService.AddPartToType(partToAdd, typeViewModel.Name);
                Services.Notifier.Success(T("The \"{0}\" part has been added.", partToAdd));
                return AddPartsTo(id);
        public ActionResult RemovePartFrom(string id) {
            var viewModel = new RemovePartViewModel();
            if (typeViewModel == null || !TryUpdateModel(viewModel) ||
                !typeViewModel.Parts.Any(p => p.PartDefinition.Name == viewModel.Name))
                return HttpNotFound();
            viewModel.Type = typeViewModel;
        [HttpPost, ActionName("RemovePartFrom")]
        public ActionResult RemovePartFromPOST(string id) {
            _contentDefinitionService.RemovePartFromType(viewModel.Name, typeViewModel.Name);
                viewModel.Type = typeViewModel;
            Services.Notifier.Success(T("The \"{0}\" part has been removed.", viewModel.Name));
        #endregion
        #region Parts
        public ActionResult ListParts() {
            return View(new ListContentPartsViewModel {
                // only user-defined parts (not code as they are not configurable)
                Parts = _contentDefinitionService.GetParts(metadataPartsOnly: true)
        public ActionResult CreatePart(string suggestion) {
            if (!Services.Authorizer.Authorize(Permissions.EditContentTypes, T("Not allowed to create a content part.")))
            return View(new CreatePartViewModel { Name = suggestion?.ToSafeName() });
        [HttpPost, ActionName("CreatePart")]
        public ActionResult CreatePartPOST(CreatePartViewModel viewModel) {
                _contentDefinitionManager.ListPartDefinitions().Any(t => string.Equals(t.Name.ToSafeName(), viewModel.Name.ToSafeName(), StringComparison.OrdinalIgnoreCase))) {
                ModelState.AddModelError("Name", T("A content part with this technical name already exists.").Text);
            if (!ModelState.IsValid) return View(viewModel);
            var partViewModel = _contentDefinitionService.AddPart(viewModel);
            if (partViewModel == null) {
                Services.Notifier.Error(T("The content part could not be created."));
            Services.Notifier.Success(T("The \"{0}\" content part has been created.", partViewModel.Name));
            return RedirectToAction("EditPart", new { id = partViewModel.Name });
        public ActionResult EditPart(string id) {
            if (!Services.Authorizer.Authorize(Permissions.EditContentTypes, T("Not allowed to edit a content part.")))
            var partViewModel = _contentDefinitionService.GetPart(id);
            if (partViewModel == null) return HttpNotFound();
            return View(partViewModel);
        [HttpPost, ActionName("EditPart")]
        public ActionResult EditPartPOST(string id) {
            if (!TryUpdateModel(partViewModel)) return View(partViewModel);
            _contentDefinitionService.AlterPart(partViewModel, this);
                return View(partViewModel);
            Services.Notifier.Success(T("\"{0}\" settings have been saved.", partViewModel.Name));
            return RedirectToAction("ListParts");
        public ActionResult DeletePart(string id) {
            if (!Services.Authorizer.Authorize(Permissions.EditContentTypes, T("Not allowed to delete a content part.")))
            _contentDefinitionService.RemovePart(id);
            Services.Notifier.Success(T("\"{0}\" has been removed.", partViewModel.DisplayName));
        public ActionResult AddFieldTo(string id) {
            // If the specified Part doesn't exist, try to find a matching Type,
            // where the implicit Part with the same name can be created to store Fields.
                var typeViewModel = _contentDefinitionService.GetType(id);
                if (typeViewModel == null) return HttpNotFound();
                else partViewModel = new EditPartViewModel(new ContentPartDefinition(id));
            var viewModel = new AddFieldViewModel {
                Part = partViewModel,
                Fields = _contentDefinitionService.GetFields().OrderBy(x => x.FieldTypeName)
        [HttpPost, ActionName("AddFieldTo")]
        public ActionResult AddFieldToPOST(AddFieldViewModel viewModel, string id) {
            if (partViewModel == null && typeViewModel == null) return HttpNotFound();
            if (partViewModel != null && !string.IsNullOrWhiteSpace(viewModel.DisplayName) &&
                partViewModel.Fields.Any(t => string.Equals(t.DisplayName.Trim(), viewModel.DisplayName.Trim(), StringComparison.OrdinalIgnoreCase))) {
                ModelState.AddModelError("DisplayName", T("A content field with this display name already exists.").Text);
            if (partViewModel != null && !string.IsNullOrWhiteSpace(viewModel.Name) &&
                partViewModel.Fields.Any(t => string.Equals(t.Name.ToSafeName(), viewModel.Name.ToSafeName(), StringComparison.OrdinalIgnoreCase))) {
                ModelState.AddModelError("Name", T("A content field with this technical name already exists.").Text);
                viewModel.Part = partViewModel ?? new EditPartViewModel { Name = typeViewModel.Name };
                viewModel.Fields = _contentDefinitionService.GetFields();
            // If the specified Part doesn't exist, create an implicit ,
                partViewModel = _contentDefinitionService.AddPart(new CreatePartViewModel { Name = typeViewModel.Name });
                _contentDefinitionService.AddPartToType(partViewModel.Name, typeViewModel.Name);
            try {
                _contentDefinitionService.AddFieldToPart(viewModel.Name, viewModel.DisplayName, viewModel.FieldTypeName, partViewModel.Name);
            catch (Exception ex) {
                Services.Notifier.Error(T("The \"{0}\" field was not added. {1}", viewModel.DisplayName, ex.Message));
                return AddFieldTo(id);
            Services.Notifier.Success(T("The \"{0}\" field has been added.", viewModel.DisplayName));
            return typeViewModel == null ? RedirectToAction("EditPart", new { id }) : RedirectToAction("Edit", new { id });
        public ActionResult EditField(string id, string name) {
            var fieldViewModel = partViewModel.Fields.FirstOrDefault(x => x.Name == name);
            if (fieldViewModel == null) return HttpNotFound();
            var viewModel = new EditFieldNameViewModel {
                Name = fieldViewModel.Name,
                DisplayName = fieldViewModel.DisplayName
        [HttpPost, ActionName("EditField")]
        public ActionResult EditFieldPOST(string id, EditFieldNameViewModel viewModel) {
            if (viewModel == null) return HttpNotFound();
            ValidateDisplayName(viewModel.Name);
                partViewModel.Fields.Any(f =>
                    !string.Equals(f.Name, viewModel.Name, StringComparison.OrdinalIgnoreCase) &&
                    string.Equals(f.DisplayName.Trim(), viewModel.DisplayName.Trim(), StringComparison.OrdinalIgnoreCase))) {
                ModelState.AddModelError("DisplayName", T("A content field with this display name already exists on this content part.").Text);
            var field = _contentDefinitionManager.GetPartDefinition(id).Fields.FirstOrDefault(x => x.Name == viewModel.Name);
            if (field == null) return HttpNotFound();
            _contentDefinitionService.AlterField(partViewModel, viewModel);
            Services.Notifier.Success(T("Display name changed to {0}.", viewModel.DisplayName));
            // Redirect to the type editor if a type exists with this name.
            return _contentDefinitionService.GetType(id) == null ?
                RedirectToAction("EditPart", new { id }) : RedirectToAction("Edit", new { id });
        public ActionResult RemoveFieldFrom(string id) {
            var viewModel = new RemoveFieldViewModel();
            if (partViewModel == null || !TryUpdateModel(viewModel) ||
                !partViewModel.Fields.Any(p => p.Name == viewModel.Name))
            viewModel.Part = partViewModel;
        [HttpPost, ActionName("RemoveFieldFrom")]
        public ActionResult RemoveFieldFromPOST(string id) {
            _contentDefinitionService.RemoveFieldFromPart(viewModel.Name, partViewModel.Name);
                viewModel.Part = partViewModel;
            Services.Notifier.Success(T("The \"{0}\" field has been removed.", viewModel.Name));
        private void ValidateDisplayName(string displayName) {
            if (string.IsNullOrWhiteSpace(displayName)) {
                ModelState.AddModelError("DisplayName", T("The display name name can't be empty.").Text);
            else if (!string.Equals(displayName, displayName.Trim(), StringComparison.OrdinalIgnoreCase)) {
                ModelState.AddModelError("DisplayName", T("The display name starts and/or ends with whitespace characters.").Text);
        private void ValidateTechnicalName(string technicalName) {
            if (string.IsNullOrWhiteSpace(technicalName)) {
                ModelState.AddModelError("Name", T("The technical name (Id) can't be empty.").Text);
            else {
                var safeTechnicalName = technicalName.ToSafeName();
                if (!string.Equals(technicalName, safeTechnicalName, StringComparison.OrdinalIgnoreCase)) {
                    ModelState.AddModelError("Name", T("The technical name contains invalid (non-alphanumeric) characters.").Text);
                if (!safeTechnicalName.FirstOrDefault().IsLetter()) {
                    ModelState.AddModelError("Name", T("The technical name must start with a letter.").Text);
        bool IUpdateModel.TryUpdateModel<TModel>(TModel model, string prefix, string[] includeProperties, string[] excludeProperties) {
            return TryUpdateModel(model, prefix, includeProperties, excludeProperties);
        void IUpdateModel.AddModelError(string key, LocalizedString errorMessage) {
            ModelState.AddModelError(key, errorMessage.ToString());
    }
}
