using Orchard.ContentManagement;
using Orchard.Security;
using Orchard.UI.Admin;
using Orchard.DisplayManagement;
using Orchard.Localization;
using Orchard.Services;
using System.Web.Mvc;
using Orchard.Mvc.Filters;
﻿using System.Web.Mvc;

namespace Orchard.DynamicForms.Services {
    public interface IController {
        TempDataDictionary TempData { get; }
        ModelStateDictionary ModelState { get; }
    }
}
