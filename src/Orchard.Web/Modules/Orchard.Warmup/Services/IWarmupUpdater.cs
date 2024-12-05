using Orchard.ContentManagement;
using Orchard.Security;
using Orchard.UI.Admin;
using Orchard.DisplayManagement;
using Orchard.Localization;
using Orchard.Services;
using System.Web.Mvc;
using Orchard.Mvc.Filters;
﻿namespace Orchard.Warmup.Services {
    public interface IWarmupUpdater : IDependency {
        /// <summary>
        ///  Forces a regeneration of all static pages
        /// </summary>
        void Generate();

        /// Generates static pages if needed
        void EnsureGenerate();
    }
}
