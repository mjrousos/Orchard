using Orchard.ContentManagement;
using Orchard.Security;
using Orchard.UI.Admin;
using Orchard.DisplayManagement;
using Orchard.Localization;
using Orchard.Services;
using System.Web.Mvc;
using Orchard.Mvc.Filters;
﻿namespace Orchard.Environment {

    /// <summary>
    /// Describes a service which returns the a machine identifier running the application.
    /// </summary>
    public interface IApplicationEnvironment {
    
        /// <summary>
        /// Returns the machine identifier running the application.
        /// </summary>
        string GetEnvironmentIdentifier();
    }
}
