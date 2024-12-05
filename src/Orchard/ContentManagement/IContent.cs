using Orchard.ContentManagement;
using Orchard.Security;
using Orchard.UI.Admin;
using Orchard.DisplayManagement;
using Orchard.Localization;
using Orchard.Services;
using System.Web.Mvc;
using Orchard.Mvc.Filters;
﻿namespace Orchard.ContentManagement {
    public interface IContent {
        ContentItem ContentItem { get; }

        /// <summary>
        /// The ContentItem's identifier.
        /// </summary>
        int Id { get; }
    }
}
