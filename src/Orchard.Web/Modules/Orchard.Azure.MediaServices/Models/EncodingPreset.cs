using Orchard.ContentManagement;
using Orchard.Security;
using Orchard.UI.Admin;
using Orchard.DisplayManagement;
using Orchard.Localization;
using Orchard.Services;
using System.Web.Mvc;
using Orchard.Mvc.Filters;
﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Orchard.Azure.MediaServices.Models {
    public class EncodingPreset {
        public string Name { get; set; }
        [AllowHtml]
        public string CustomXml { get; set; }
    }
}
