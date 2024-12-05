using Orchard.ContentManagement;
using Orchard.Security;
using Orchard.UI.Admin;
using Orchard.DisplayManagement;
using Orchard.Localization;
using Orchard.Services;
using System.Web.Mvc;
using Orchard.Mvc.Filters;
using System.Collections.Generic;
using System.Linq;
using System.Web.Routing;
using Orchard.Core.Common.Models;
using Orchard.CustomForms.Models;
using Orchard.CustomForms.ViewModels;
using Orchard.Mvc;
using Orchard.Settings;
using Orchard.UI.Navigation;

namespace Orchard.CustomForms.Controllers {
    [ValidateInput(false)]
    public class AdminController : Controller {
        private readonly ISiteService _siteService;
        public AdminController(
            IOrchardServices services,
            IShapeFactory shapeFactory,
            ISiteService siteService) {
            _siteService = siteService;
            Services = services;
            T = NullLocalizer.Instance;
            Shape = shapeFactory;
        }
        dynamic Shape { get; set; }
        public IOrchardServices Services { get; set; }
        public Localizer T { get; set; }
        public ActionResult Index(CustomFormIndexOptions options, PagerParameters pagerParameters) {
            if (!Services.Authorizer.Authorize(Permissions.ManageForms, T("Not authorized to list custom forms")))
                return new HttpUnauthorizedResult();
            var pager = new Pager(_siteService.GetSiteSettings(), pagerParameters);
            // default options
            if (options == null)
                options = new CustomFormIndexOptions();
            var query = Services.ContentManager.Query().ForType("CustomForm", "CustomFormWidget").ForVersion(VersionOptions.Latest);
            switch (options.Filter) {
                case CustomFormFilter.All:
                    break;
            }
            var pagerShape = Shape.Pager(pager).TotalItemCount(query.Count());
            switch (options.Order) {
                case CustomFormOrder.Creation:
                    query = query.Join<CommonPartRecord>().OrderByDescending(u => u.CreatedUtc);
            var results = query
                .Slice(pager.GetStartIndex(), pager.PageSize);
            var model = new CustomFormIndexViewModel {
                CustomForms = results.Select(x => new CustomFormEntry { CustomForm = x.As<CustomFormPart>() }).ToList(),
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
        [HttpPost]
        [FormValueRequired("submit.BulkEdit")]
        public ActionResult Index(FormCollection input) {
            if (!Services.Authorizer.Authorize(Permissions.ManageForms, T("Not authorized to manage customForm")))
            var viewModel = new CustomFormIndexViewModel { CustomForms = new List<CustomFormEntry>(), Options = new CustomFormIndexOptions() };
            UpdateModel(viewModel);
            var checkedEntries = viewModel.CustomForms.Where(c => c.IsChecked);
            switch (viewModel.Options.BulkAction) {
                case CustomFormBulkAction.None:
                case CustomFormBulkAction.Publish:
                    foreach (var entry in checkedEntries) {
                        Services.ContentManager.Publish(Services.ContentManager.Get(entry.CustomForm.Id));
                    }
                case CustomFormBulkAction.Unpublish:
                        Services.ContentManager.Unpublish(Services.ContentManager.Get(entry.CustomForm.Id));
                case CustomFormBulkAction.Delete:
                        Services.ContentManager.Remove(Services.ContentManager.Get(entry.CustomForm.Id));
            return Index(viewModel.Options, new PagerParameters());
        public ActionResult Item(int id, PagerParameters pagerParameters) {
            Pager pager = new Pager(_siteService.GetSiteSettings(), pagerParameters);
            var formPart = Services.ContentManager.Get(id, VersionOptions.Published).As<CustomFormPart>();
            if (formPart == null)
                return HttpNotFound();
            var submissions = Services.ContentManager
                    .Query<CommonPart, CommonPartRecord>()
                    .ForVersion(VersionOptions.Latest)
                    .Where(x => x.Container.Id == id)
                    .OrderByDescending(x => x.CreatedUtc)
                    .Slice(pager.GetStartIndex(), pager.PageSize)
                .Select(b => Services.ContentManager.BuildDisplay(b, "SummaryAdmin"));
            var shape = Services.New.CustomFormList();
            
            var list = Shape.List();
            list.AddRange(submissions);
            var totalItemCount = Services.ContentManager
                    .Count();
            shape.Pager(Services.New.Pager(pager).TotalItemCount(totalItemCount));
            shape.List(list);
            return View(shape);
    }
}
