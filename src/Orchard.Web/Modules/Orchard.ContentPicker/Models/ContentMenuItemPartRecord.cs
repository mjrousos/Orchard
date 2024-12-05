using Orchard.ContentManagement;
using Orchard.Security;
using Orchard.UI.Admin;
using Orchard.DisplayManagement;
using Orchard.Localization;
using Orchard.Services;
using System.Web.Mvc;
using Orchard.Mvc.Filters;
﻿using Orchard.ContentManagement.Records;

namespace Orchard.ContentPicker.Models {
    public class ContentMenuItemPartRecord : ContentPartRecord {
        public virtual ContentItemRecord ContentMenuItemRecord { get; set; }
    }
}
