using Orchard.ContentManagement;
using Orchard.Security;
using Orchard.UI.Admin;
using Orchard.DisplayManagement;
using Orchard.Localization;
using Orchard.Services;
using System.Web.Mvc;
using Orchard.Mvc.Filters;
﻿using System;
using System.ComponentModel.DataAnnotations;

namespace Orchard.Azure.MediaServices.ViewModels.Settings {
    public class GeneralSettingsViewModel {
        public string WamsAccountName { get; set; }
        public string WamsAccountKey { get; set; }
		public string StorageAccountKey { get; set; }
        public bool EnableDynamicPackaging { get; set; }
        [Required]
        public TimeSpan AccessPolicyDuration { get; set; }
        public string AllowedVideoFilenameExtensions { get; set; }
    }
}
