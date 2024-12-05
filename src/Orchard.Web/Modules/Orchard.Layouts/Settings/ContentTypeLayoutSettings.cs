using Orchard.ContentManagement;
using Orchard.Security;
using Orchard.UI.Admin;
using Orchard.DisplayManagement;
using Orchard.Localization;
using Orchard.Services;
using System.Web.Mvc;
using Orchard.Mvc.Filters;
﻿namespace Orchard.Layouts.Settings {
    public class ContentTypeLayoutSettings {
        /// <summary>
        /// This setting is used to configure a content type to be placeable on a layout.
        /// </summary>
        public bool Placeable { get; set; }
    }
}
