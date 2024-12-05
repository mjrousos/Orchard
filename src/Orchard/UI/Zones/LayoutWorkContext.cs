using Orchard.ContentManagement;
using Orchard.Security;
using Orchard.UI.Admin;
using Orchard.DisplayManagement;
using Orchard.Localization;
using Orchard.Services;
using System.Web.Mvc;
using Orchard.Mvc.Filters;
﻿using System;

namespace Orchard.UI.Zones {
    public class LayoutWorkContext : IWorkContextStateProvider {
        private readonly IShapeFactory _shapeFactory;
        public LayoutWorkContext(IShapeFactory shapeFactory) {
            _shapeFactory = shapeFactory;
        }
        public Func<WorkContext, T> Get<T>(string name) {
            if (name == "Layout") {
                var layout = _shapeFactory.Create("Layout", Arguments.Empty());
                return ctx => (T)layout;
            }
            return null;
    }
}
