using Orchard.ContentManagement;
using Orchard.Security;
using Orchard.UI.Admin;
using Orchard.DisplayManagement;
using Orchard.Localization;
using Orchard.Services;
using System.Web.Mvc;
using Orchard.Mvc.Filters;
﻿using System;
using System.Globalization;
using Orchard.ContentManagement.FieldStorage.InfosetStorage;

namespace Orchard.MediaLibrary.Models {
    public class ImagePart : ContentPart {
        public int Width {
            get { return Convert.ToInt32(this.As<InfosetPart>().Get("ImagePart", "Width", "Value"), CultureInfo.InvariantCulture); }
            set { this.As<InfosetPart>().Set("ImagePart", "Width", "Value", Convert.ToString(value, CultureInfo.InvariantCulture)); }
        }
        public int Height {
            get { return Convert.ToInt32(this.As<InfosetPart>().Get("ImagePart", "Height", "Value"), CultureInfo.InvariantCulture); }
            set { this.As<InfosetPart>().Set("ImagePart", "Height", "Value", Convert.ToString(value, CultureInfo.InvariantCulture)); }
   }
}
