using Orchard.ContentManagement;
using Orchard.Security;
using Orchard.UI.Admin;
using Orchard.DisplayManagement;
using Orchard.Localization;
using Orchard.Services;
using System.Web.Mvc;
using Orchard.Mvc.Filters;
﻿using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Orchard.Azure.MediaServices.Infrastructure.Assets;
using Orchard.Azure.MediaServices.Models.Assets;

namespace Orchard.Azure.MediaServices.ViewModels.Media {
    public class AssetViewModel {
        [Required]
        public string Name { get; set; }
        public string Description { get; set; }
        public bool IncludeInPlayer { get; set; }
        public string MediaQuery { get; set; }
        public IEnumerable<AssetDriverResult> SpecializedSettings { get; set; }
        public Asset Asset { get; set; }
    }
}
