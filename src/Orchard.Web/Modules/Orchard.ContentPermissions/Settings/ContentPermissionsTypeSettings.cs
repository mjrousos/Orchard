using Orchard.ContentManagement;
using Orchard.Security;
using Orchard.UI.Admin;
using Orchard.DisplayManagement;
using Orchard.Localization;
using Orchard.Services;
using System.Web.Mvc;
using Orchard.Mvc.Filters;
﻿namespace Orchard.ContentPermissions.Settings {
    public class ContentPermissionsTypeSettings {
        /// <summary>
        /// Used to determine if instances of this content type supports custom permissions
        /// </summary>
        public bool SecurableContentItems { get; set; }
    }
}
