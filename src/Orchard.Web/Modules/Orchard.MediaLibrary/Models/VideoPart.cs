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
    public class VideoPart : ContentPart {
        public int Length {
            get { return Convert.ToInt32(this.As<InfosetPart>().Get("VideoPart", "Length", "Value"), CultureInfo.InvariantCulture); }
            set { this.As<InfosetPart>().Set("VideoPart", "Length", "Value", Convert.ToString(value, CultureInfo.InvariantCulture)); }
        }
    }
}
