using Orchard.ContentManagement;
using Orchard.Security;
using Orchard.UI.Admin;
using Orchard.DisplayManagement;
using Orchard.Localization;
using Orchard.Services;
using System.Web.Mvc;
using Orchard.Mvc.Filters;
﻿using System;
using System.Linq;
using Orchard.Indexing.Services;
using Orchard.Logging;
using Orchard.Indexing.ViewModels;
using Orchard.UI.Notify;
using Orchard.Utility.Extensions;

namespace Orchard.Indexing.Controllers {
    public class AdminController : Controller {
        private readonly IIndexingService _indexingService;
        private readonly IIndexManager _indexManager;
        public AdminController(
            IIndexingService indexingService, 
            IOrchardServices services,
            IIndexManager indexManager) {
            _indexingService = indexingService;
            _indexManager = indexManager;
            Services = services;
            T = NullLocalizer.Instance;
            Logger = NullLogger.Instance;
        }
        public IOrchardServices Services { get; private set; }
        public Localizer T { get; set; }
        public ILogger Logger { get; set; }
        public ActionResult Index() {
            var viewModel = new IndexViewModel {
                IndexEntries = Enumerable.Empty<IndexEntry>(),
                IndexProvider = _indexManager.GetSearchIndexProvider()
            };
            
            if (_indexManager.HasIndexProvider()) {
                viewModel.IndexEntries = _indexManager.GetSearchIndexProvider().List().Select(x => {
                    try {
                        return _indexingService.GetIndexEntry(x);
                    }
                    catch(Exception e) {
                        Logger.Error(e, "Index couldn't be read: " + x);
                        return new IndexEntry { 
                            IndexName = x,
                            IndexingStatus = IndexingStatus.Unavailable
                        };
                });
            }
            // Services.Notifier.Information(T("The index might be corrupted. If you can't recover click on Rebuild."));
            return View(viewModel);
        public ActionResult Create() {
            if (!Services.Authorizer.Authorize(StandardPermissions.SiteOwner, T("Not allowed to manage the search index.")))
                return new HttpUnauthorizedResult();
            return View("Create", String.Empty);
        [HttpPost, ActionName("Create")]
        public ActionResult CreatePOST(string id) {
            var provider = _indexManager.GetSearchIndexProvider();
            if (String.IsNullOrWhiteSpace(id) || id.ToSafeName() != id) {
                Services.Notifier.Error(T("Invalid index name."));
                return View("Create", id);
            if (provider.Exists(id)) {
                Services.Notifier.Error(T("An index with the same name already exists: {0}", id));
            try {
                provider.CreateIndex(id);
                Services.Notifier.Success(T("Index named {0} created successfully", id));
            catch(Exception e) {
                Services.Notifier.Error(T("An error occurred while creating the index: {0}", id));
                Logger.Error("An error occurred while creatign the index " + id, e);
            return RedirectToAction("Index");
        [HttpPost]
        public ActionResult Update(string id) {
            _indexingService.UpdateIndex(id);
        public ActionResult Rebuild(string id) {
            _indexingService.RebuildIndex(id);
        public ActionResult Delete(string id) {
            _indexingService.DeleteIndex(id);
    }
}
