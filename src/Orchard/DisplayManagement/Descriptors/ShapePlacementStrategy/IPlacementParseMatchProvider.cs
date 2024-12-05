using Orchard.ContentManagement;
using Orchard.Security;
using Orchard.UI.Admin;
using Orchard.DisplayManagement;
using Orchard.Localization;
using Orchard.Services;
using System.Web.Mvc;
using Orchard.Mvc.Filters;
﻿namespace Orchard.DisplayManagement.Descriptors.ShapePlacementStrategy {
    public interface IPlacementParseMatchProvider : IDependency {
        string Key { get; }
        bool Match(ShapePlacementContext context, string expression);
    }
}
