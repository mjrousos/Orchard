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
using System.Reflection;
using System.Web.Routing;
using Orchard.ContentManagement.Records;
using Orchard.Data;
using Orchard.Projections.Models;
using Orchard.Projections.ViewModels;
using Orchard.UI.Navigation;
using Orchard.UI.Notify;

namespace Orchard.Projections.Controllers {
    [ValidateInput(false), Admin]
    public class BindingController : Controller {
        private readonly IRepository<MemberBindingRecord> _repository;
        private readonly ISessionFactoryHolder _sessionFactoryHolder;
        public BindingController(
            IRepository<MemberBindingRecord> repository,
            IOrchardServices services,
            IShapeFactory shapeFactory,
            ISessionFactoryHolder sessionFactoryHolder) {
            _repository = repository;
            _sessionFactoryHolder = sessionFactoryHolder;
            Shape = shapeFactory;
            Services = services;
            T = NullLocalizer.Instance;
        }
        dynamic Shape { get; set; }
        public IOrchardServices Services { get; set; }
        public Localizer T { get; set; }
        public ActionResult Index(BindingIndexOptions options, PagerParameters pagerParameters) {
            if (!Services.Authorizer.Authorize(StandardPermissions.SiteOwner, T("Not authorized to list bindings")))
                return new HttpUnauthorizedResult();
            var pager = new Pager(Services.WorkContext.CurrentSite, pagerParameters);
            // default options
            if (options == null)
                options = new BindingIndexOptions();
            var bindings = _repository.Table;
            switch (options.Filter) {
                case BindingsFilter.All:
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
            if (!String.IsNullOrWhiteSpace(options.Search)) {
                bindings = bindings.Where(r => r.DisplayName.Contains(options.Search));
            var pagerShape = Shape.Pager(pager).TotalItemCount(bindings.Count());
            switch (options.Order) {
                case BindingsOrder.Name:
                    bindings = bindings.OrderBy(u => u.DisplayName);
            var results = bindings
                .Skip(pager.GetStartIndex())
                .Take(pager.PageSize)
                .ToList();
            var model = new BindingIndexViewModel {
                Bindings = results.Select(x => new BindingEntry { Binding = x }).ToList(),
                Options = options,
                Pager = pagerShape
            };
            // maintain previous route data when generating page links
            var routeData = new RouteData();
            routeData.Values.Add("Options.Filter", options.Filter);
            routeData.Values.Add("Options.Search", options.Search);
            routeData.Values.Add("Options.Order", options.Order);
            pagerShape.RouteData(routeData);
            return View(model);
        public ActionResult Select() {
            var recordBluePrints = _sessionFactoryHolder.GetSessionFactoryParameters().RecordDescriptors;
            var model = new BindingSelectViewModel {
                Records = recordBluePrints.Where(r => IsContentPartRecord(r.Type)).Select(r => new RecordEntry {
                    FullName = r.Type.FullName,
                    Members = r.Type.GetProperties(BindingFlags.Public | BindingFlags.Instance)
                        .Where(x => IsValidPropertyType(x.PropertyType)).Select(
                        m => new MemberEntry {
                            Member = m.Name
                        }).ToList()
                }).ToList()
        public ActionResult Create(string fullName, string member) {
            var record = recordBluePrints.FirstOrDefault(r => r.Type.FullName.Equals(fullName, StringComparison.OrdinalIgnoreCase));
            if(record == null) {
                return HttpNotFound();
            var property = record.Type.GetProperty(member, BindingFlags.Instance | BindingFlags.Public);
            if (property == null) {
            var model = new BindingEditViewModel {
                Id = -1,
                FullName = record.Type.FullName,
                Member = property.Name
            return View("Edit", model);
        [HttpPost, ActionName("Create")]
        public ActionResult CreatePost(BindingEditViewModel model) {
        
            if(ModelState.IsValid) {
                _repository.Create(new MemberBindingRecord {
                    Type = model.FullName,
                    Member = model.Member,
                    DisplayName =  model.Display,
                    Description = model.Description
                });
                Services.Notifier.Success(T("Binding created successfully"));
                return RedirectToAction("Index");
        public ActionResult Edit(int id) {
            var binding = _repository.Get(id);
            if (binding == null) {
            var record = recordBluePrints.FirstOrDefault(r => String.Equals(r.Type.FullName, binding.Type, StringComparison.OrdinalIgnoreCase));
            if (record == null) {
                Services.Notifier.Warning(T("The record for this binding is no longer available, please remove it."));
            var property = record.Type.GetProperty(binding.Member, BindingFlags.Instance | BindingFlags.Public);
                Services.Notifier.Warning(T("The member for this binding is no longer available, please remove it."));
                Id = id,
                Member = property.Name,
                Display = binding.DisplayName,
                Description = binding.Description
        [HttpPost, ActionName("Edit")]
        public ActionResult Edit(BindingEditViewModel model) {
            if (ModelState.IsValid) {
                var binding = _repository.Get(model.Id);
                if (binding == null) {
                    return HttpNotFound();
                }
                binding.DisplayName = model.Display;
                binding.Description = model.Description;
                Services.Notifier.Success(T("Binding updated successfully"));
        [HttpPost]
        public ActionResult Delete(int id) {
            if (!Services.Authorizer.Authorize(StandardPermissions.SiteOwner, T("Not authorized to delete bindings")))
            
            _repository.Delete(binding);
            Services.Notifier.Success(T("Binding deleted"));
            return RedirectToAction("Index");
        private static bool IsContentPartRecord(Type type) {
            return typeof(ContentPartRecord).IsAssignableFrom(type) && typeof(ContentPartRecord) != type;
 
        private bool IsValidPropertyType(Type type) {
            return type.IsValueType
                   || type == typeof (string)
                   || (typeof (Nullable).IsAssignableFrom(type) && IsValidPropertyType(type.GetGenericArguments()[0]));
    }
}
