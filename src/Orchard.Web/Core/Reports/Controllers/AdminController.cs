using Orchard.ContentManagement;
using Orchard.Security;
using Orchard.UI.Admin;
using Orchard.DisplayManagement;
using Orchard.Localization;
using Orchard.Services;
using System.Web.Mvc;
using Orchard.Mvc.Filters;
﻿using System.Linq;
using Orchard.Core.Reports.ViewModels;
using Orchard.Reports.Services;

namespace Orchard.Core.Reports.Controllers {
    public class AdminController : Controller {
        private readonly IReportsManager _reportsManager;
        public AdminController(
            IOrchardServices services, 
            IReportsManager reportsManager) {
            Services = services;
            _reportsManager = reportsManager;
            T = NullLocalizer.Instance;
        }
        public IOrchardServices Services { get; set; }
        public Localizer T { get; set; }
        public ActionResult Index() {
            if (!Services.Authorizer.Authorize(StandardPermissions.SiteOwner, T("Not authorized to list reports")))
                return new HttpUnauthorizedResult();
            var model = new ReportsAdminIndexViewModel { Reports = _reportsManager.GetReports().ToList() };
            return View(model);
        public ActionResult Display(int id) {
            if (!Services.Authorizer.Authorize(StandardPermissions.SiteOwner, T("Not authorized to display report")))
            var model = new DisplayReportViewModel { Report = _reportsManager.Get(id) };
    }
}
