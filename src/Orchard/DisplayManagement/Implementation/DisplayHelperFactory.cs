using Orchard.ContentManagement;
using Orchard.Security;
using Orchard.UI.Admin;
using Orchard.DisplayManagement;
using Orchard.Localization;
using Orchard.Services;
using System.Web.Mvc;
using Orchard.Mvc.Filters;
﻿using System.Web.Mvc;

namespace Orchard.DisplayManagement.Implementation {
    public class DisplayHelperFactory : IDisplayHelperFactory {
        private readonly IDisplayManager _displayManager;
        private readonly IShapeFactory _shapeFactory;
        public DisplayHelperFactory(IDisplayManager displayManager, IShapeFactory shapeFactory) {
            _displayManager = displayManager;
            _shapeFactory = shapeFactory;
        }
        public dynamic CreateHelper(ViewContext viewContext, IViewDataContainer viewDataContainer) {
            return new DisplayHelper(
                _displayManager,
                _shapeFactory,
                viewContext,
                viewDataContainer);
    }
}
