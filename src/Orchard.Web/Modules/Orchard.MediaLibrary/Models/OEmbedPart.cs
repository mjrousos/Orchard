using Orchard.ContentManagement;
using Orchard.Security;
using Orchard.UI.Admin;
using Orchard.DisplayManagement;
using Orchard.Localization;
using Orchard.Services;
using System.Web.Mvc;
using Orchard.Mvc.Filters;
﻿using Orchard.ContentManagement;
using Orchard.ContentManagement.FieldStorage.InfosetStorage;

namespace Orchard.MediaLibrary.Models {
    public class OEmbedPart : ContentPart {
        public string this[string index] {
            get { return this.As<InfosetPart>().Get("OEmbedPart", index, null); }
            set { this.As<InfosetPart>().Set("OEmbedPart", index, null, value); }
        }
        public string Source {
            get { return this.As<InfosetPart>().Get("OEmbedPart", "Source"); }
            set { this.As<InfosetPart>().Set("OEmbedPart", "Source", value); }
   }
}
