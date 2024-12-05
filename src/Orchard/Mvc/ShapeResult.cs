using Orchard.ContentManagement;
using Orchard.Security;
using Orchard.UI.Admin;
using Orchard.DisplayManagement;
using Orchard.Localization;
using Orchard.Services;
using System.Web.Mvc;
using Orchard.Mvc.Filters;
﻿using System.Web.Mvc;

namespace Orchard.Mvc {
    public class ShapeResult : ViewResult {
        public ShapeResult(ControllerBase controller, dynamic shape) {
            ViewData = controller.ViewData;
            TempData = controller.TempData;
            ViewData.Model = shape;
            ViewName = "ShapeResult/Display";
        }
    }
    public class ShapePartialResult : PartialViewResult {
        public ShapePartialResult(ControllerBase controller, dynamic shape) {
            ViewName = "ShapeResult/DisplayPartial";
}
