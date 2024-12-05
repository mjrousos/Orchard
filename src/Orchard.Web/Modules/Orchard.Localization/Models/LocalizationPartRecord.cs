using Orchard.ContentManagement;
using Orchard.Security;
using Orchard.UI.Admin;
using Orchard.DisplayManagement;
using Orchard.Localization;
using Orchard.Services;
using System.Web.Mvc;
using Orchard.Mvc.Filters;
﻿using Orchard.ContentManagement.Records;

namespace Orchard.Localization.Models {
    public class LocalizationPartRecord : ContentPartRecord {
        public virtual int CultureId { get; set; }
        public virtual int MasterContentItemId { get; set; }
    }
}
