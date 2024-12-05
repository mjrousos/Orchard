using Orchard.ContentManagement;
using Orchard.Security;
using Orchard.UI.Admin;
using Orchard.DisplayManagement;
using Orchard.Localization;
using Orchard.Services;
using System.Web.Mvc;
using Orchard.Mvc.Filters;
﻿using System.Collections.Generic;
using Orchard.MediaProcessing.Models;

namespace Orchard.MediaProcessing.ViewModels {
    public class AdminIndexViewModel {
        public IList<ImageProfileEntry> ImageProfiles { get; set; }
        public AdminIndexOptions Options { get; set; }
        public dynamic Pager { get; set; }
    }
    public class ImageProfileEntry {
        public ImageProfilePartRecord ImageProfile { get; set; }
        public bool IsChecked { get; set; }
        public int ImageProfileId { get; set; }
        public string Name { get; set; }
    public class AdminIndexOptions {
        public string Search { get; set; }
        public ImageProfilesFilter Filter { get; set; }
        public ImageProfilesBulkAction BulkAction { get; set; }
    public enum ImageProfilesFilter {
        All
    public enum ImageProfilesBulkAction {
        None,
        Delete
}
