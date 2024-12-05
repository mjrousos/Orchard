using Orchard.ContentManagement;
using Orchard.Security;
using Orchard.UI.Admin;
using Orchard.DisplayManagement;
using Orchard.Localization;
using Orchard.Services;
using System.Web.Mvc;
using Orchard.Mvc.Filters;
﻿using System.Collections.Generic;
using Orchard.DisplayManagement.Shapes;

namespace Orchard.DisplayManagement {
    public interface IShapeDisplay : IDependency {
        string Display(Shape shape);
        string Display(object shape);
        IEnumerable<string> Display(IEnumerable<object> shapes);
    }
}
