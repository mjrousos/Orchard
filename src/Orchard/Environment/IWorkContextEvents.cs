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
    /// Describes events fired during work context lifetime.
    /// </summary>
    public interface IWorkContextEvents : IUnitOfWorkDependency {
        /// <summary>
        /// Fired when the work context is started.
        /// </summary>
        void Started();

        /// Fired when the work context is finished.
        void Finished();
    }
}
