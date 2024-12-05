using Orchard.ContentManagement;
using Orchard.Security;
using Orchard.UI.Admin;
using Orchard.DisplayManagement;
using Orchard.Localization;
using Orchard.Services;
using System.Web.Mvc;
using Orchard.Mvc.Filters;
﻿using System.Collections.Generic;
using Orchard.Azure.MediaServices.Models;

namespace Orchard.Azure.MediaServices.ViewModels.Media {
    public class CloudVideoPartViewModel {
        public CloudVideoPartViewModel(IEnumerable<string> subtitleLanguages) {
            TemporaryVideoFile = new TemporaryFileViewModel();
            SubtitleLanguages = subtitleLanguages;
        }
        public int Id { get; set; }
        public CloudVideoPart Part { get; set; }
        public IEnumerable<string> AllowedVideoFilenameExtensions { get; set; }
        public TemporaryFileViewModel TemporaryVideoFile { get; set; }
        public IEnumerable<string> SubtitleLanguages { get; private set; }
        public string AddedSubtitleLanguage { get; set; }
        public WamsAssetViewModel WamsVideo { get; set; }
        public WamsAssetViewModel WamsThumbnail { get; set; }
        public WamsAssetViewModel WamsSubtitle { get; set; }
    }
}
