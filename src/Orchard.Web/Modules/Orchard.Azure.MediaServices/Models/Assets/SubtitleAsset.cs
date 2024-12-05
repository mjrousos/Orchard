using Orchard.ContentManagement;
using Orchard.Security;
using Orchard.UI.Admin;
using Orchard.DisplayManagement;
using Orchard.Localization;
using Orchard.Services;
using System.Web.Mvc;
using Orchard.Mvc.Filters;
using System;

namespace Orchard.Azure.MediaServices.Models.Assets {
    public class SubtitleAsset : Asset {
        public string Language {
            get { return Storage.Get<string>("Language"); }
            set { Storage.Set("Language", value); }
        }
    }
}
