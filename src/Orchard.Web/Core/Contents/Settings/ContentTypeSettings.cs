using Orchard.ContentManagement;
using Orchard.Security;
using Orchard.UI.Admin;
using Orchard.DisplayManagement;
using Orchard.Localization;
using Orchard.Services;
using System.Web.Mvc;
using Orchard.Mvc.Filters;
﻿namespace Orchard.Core.Contents.Settings {
    public class ContentTypeSettings {
        /// <summary>
        /// Used to determine if an instance of this content type can be created through the UI
        /// </summary>
        public bool Creatable { get; set; }
        /// Used to determine if an instance of this content type can be listed in the contents page
        public bool Listable { get; set; }
        /// Used to determine if this content type supports draft versions
        public bool Draftable { get; set; }
        /// Defines the stereotype of the type
        public string Stereotype { get; set; }
        /// Used to determine if this content type supports custom permissions
        public bool Securable { get; set; }
    }
}
