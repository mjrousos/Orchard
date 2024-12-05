using Orchard.ContentManagement;
using Orchard.Security;
using Orchard.UI.Admin;
using Orchard.DisplayManagement;
using Orchard.Localization;
using Orchard.Services;
using System.Web.Mvc;
using Orchard.Mvc.Filters;
﻿using Orchard.Forms.Services;

namespace Orchard.Layouts.Services {
    public interface IFormsBasedElementServices : IDependency
    {
        IFormManager FormManager { get; }
        ICultureAccessor CultureAccessor { get; }
    }
}
