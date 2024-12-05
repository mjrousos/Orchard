using Orchard.ContentManagement;
using Orchard.Security;
using Orchard.UI.Admin;
using Orchard.DisplayManagement;
using Orchard.Localization;
using Orchard.Services;
using System.Web.Mvc;
using Orchard.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Routing;
using Orchard.AntiSpam.Models;
using Orchard.AntiSpam.Services;
using Orchard.AntiSpam.ViewModels;
using Orchard.Core.Common.Models;
using Orchard.Mvc;
using Orchard.Settings;
using Orchard.UI.Navigation;
using Orchard.Mvc.Extensions;

namespace Orchard.AntiSpam.Controllers {
    [ValidateInput(false)]
    public class AdminController : Controller {
        private readonly ISiteService _siteService;
        private readonly ISpamService _spamService;
        public AdminController(
            IOrchardServices services,
            IShapeFactory shapeFactory,
            ISiteService siteService,
            ISpamService spamService) {
            _siteService = siteService;
            _spamService = spamService;
            Services = services;
            T = NullLocalizer.Instance;
            Shape = shapeFactory;
        }
        dynamic Shape { get; set; }
        public IOrchardServices Services { get; set; }
        public Localizer T { get; set; }
        public ActionResult Index(SpamIndexOptions options, PagerParameters pagerParameters) {
            if (!Services.Authorizer.Authorize(Permissions.ManageAntiSpam, T("Not authorized to manage spam")))
                return new HttpUnauthorizedResult();
            var pager = new Pager(_siteService.GetSiteSettings(), pagerParameters);
            // default options
            if (options == null)
                options = new SpamIndexOptions();
            var query = Services.ContentManager.Query().ForPart<SpamFilterPart>().ForVersion(VersionOptions.Latest);
            
            switch(options.Filter) {
                case SpamFilter.Spam:
                    query = query.Where<SpamFilterPartRecord>(x => x.Status == SpamStatus.Spam);
                    break;
                case SpamFilter.Ham:
                    query = query.Where<SpamFilterPartRecord>(x => x.Status == SpamStatus.Ham);
                case SpamFilter.All:
                default:
                    throw new ArgumentOutOfRangeException();
            }
            var pagerShape = Shape.Pager(pager).TotalItemCount(query.Count());
            switch (options.Order) {
                case SpamOrder.Creation:
                    query = query.Join<CommonPartRecord>().OrderByDescending(u => u.CreatedUtc);
            var results = query
                .Slice(pager.GetStartIndex(), pager.PageSize);
            var model = new SpamIndexViewModel {
                Spams = results.Select(x => new SpamEntry {
                    Spam = x.As<SpamFilterPart>(),
                    Shape = Services.ContentManager.BuildDisplay(x, "SummaryAdmin")
                }).ToList(),
                
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
        public ActionResult Index(SpamIndexOptions options, IEnumerable<int> itemIds) {
            switch (options.BulkAction) {
                case SpamBulkAction.None:
                case SpamBulkAction.Spam:
                    foreach (var checkedId in itemIds) {
                        var spam = Services.ContentManager.Get(checkedId, VersionOptions.Latest);
                        if(spam != null) {
                            spam.As<SpamFilterPart>().Status = SpamStatus.Spam;
                            _spamService.ReportSpam(spam.As<SpamFilterPart>());
                            Services.ContentManager.Publish(spam);
                        }
                    }
                case SpamBulkAction.Ham:
                        var ham = Services.ContentManager.Get(checkedId, VersionOptions.Latest);
                        if (ham != null) {
                            ham.As<SpamFilterPart>().Status = SpamStatus.Ham;
                            _spamService.ReportHam(ham.As<SpamFilterPart>());
                            Services.ContentManager.Publish(ham);
                case SpamBulkAction.Delete:
                        Services.ContentManager.Remove(Services.ContentManager.Get(checkedId, VersionOptions.Latest));
            return Index(options, new PagerParameters());
        public ActionResult ReportSpam(int id, string returnUrl) {
            var spam = Services.ContentManager.Get(id, VersionOptions.Latest);
            if (spam != null) {
                spam.As<SpamFilterPart>().Status = SpamStatus.Spam;
                _spamService.ReportSpam(spam.As<SpamFilterPart>());
                Services.ContentManager.Unpublish(spam);
            return this.RedirectLocal(returnUrl, "~/");
        public ActionResult ReportHam(int id, string returnUrl) {
                spam.As<SpamFilterPart>().Status = SpamStatus.Ham;
                _spamService.ReportHam(spam.As<SpamFilterPart>());
                Services.ContentManager.Publish(spam);
    }
}
