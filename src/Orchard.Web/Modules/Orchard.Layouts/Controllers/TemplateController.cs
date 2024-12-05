using Orchard.ContentManagement;
using Orchard.Security;
using Orchard.UI.Admin;
using Orchard.DisplayManagement;
using Orchard.Localization;
using Orchard.Services;
using System.Web.Mvc;
using Orchard.Mvc.Filters;
﻿using System;
using Orchard.Caching;

namespace Orchard.Layouts.Controllers {
    [Admin]
    public class TemplateController : Controller {
        private readonly ICacheManager _cacheManager;
        private readonly Lazy<IShapeFactory> _shapeFactory;
        private readonly IShapeDisplay _shapeDisplay;
        public TemplateController(ICacheManager cacheManager, Lazy<IShapeFactory> shapeFactory, IShapeDisplay shapeDisplay) {
            _cacheManager = cacheManager;
            _shapeFactory = shapeFactory;
            _shapeDisplay = shapeDisplay;
        }
        public ContentResult Get(string id) {
            var shapeType = String.Format("LayoutEditor_Template_{0}", id);
            var content = _cacheManager.Get(shapeType, context => {
                var shape = _shapeFactory.Value.Create(shapeType);
                return _shapeDisplay.Display(shape);
            });
            return Content(content, "text/html");
    }
}
