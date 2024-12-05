using Orchard.ContentManagement;
using Orchard.Security;
using Orchard.UI.Admin;
using Orchard.DisplayManagement;
using Orchard.Localization;
using Orchard.Services;
using System.Web.Mvc;
using Orchard.Mvc.Filters;
﻿namespace Orchard.Azure.MediaServices.ViewModels.Settings {
    public class EncryptionSettingsViewModel {
        public string KeySeedValue { get; set; }
        public string LicenseAcquisitionUrl { get; set; }
    }
}
