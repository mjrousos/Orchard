using Orchard.ContentManagement;
using Orchard.Security;
using Orchard.UI.Admin;
using Orchard.DisplayManagement;
using Orchard.Localization;
using Orchard.Services;
using System.Web.Mvc;
using Orchard.Mvc.Filters;
﻿namespace Orchard.WebApi.Filters {
    /// <summary>
    /// Any implementation of <see cref="IApiFilterProvider"/> will be injected as a WebAPI filter.
    /// </summary>
    public interface IApiFilterProvider : IDependency {
         
    }
}
