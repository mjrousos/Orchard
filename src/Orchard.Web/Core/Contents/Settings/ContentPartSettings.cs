using Orchard.ContentManagement;
using Orchard.Security;
using Orchard.UI.Admin;
using Orchard.DisplayManagement;
using Orchard.Localization;
using Orchard.Services;
using System.Web.Mvc;
using Orchard.Mvc.Filters;
﻿namespace Orchard.Core.Contents.Settings {
    public class ContentPartSettings {
        /// <summary>
        /// This setting is used to display a Content Part in list of Parts to attach to a Content Type
        /// </summary>
        public bool Attachable { get; set; }

        public string Description { get; set; }
    }
}
