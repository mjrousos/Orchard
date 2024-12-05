using Orchard.ContentManagement;
using Orchard.Security;
using Orchard.UI.Admin;
using Orchard.DisplayManagement;
using Orchard.Localization;
using Orchard.Services;
using System.Web.Mvc;
using Orchard.Mvc.Filters;
﻿namespace Orchard.Azure.MediaServices.ViewModels.Settings {
    public class SettingsViewModel {
        public GeneralSettingsViewModel General { get; set; }
        public EncodingSettingsViewModel EncodingSettings { get; set; }
        public EncryptionSettingsViewModel EncryptionSettings { get; set; }
        public SubtitleLanguagesSettingsViewModel SubtitleLanguages { get; set; }
    }
}
