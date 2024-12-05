using Orchard.ContentManagement;
using Orchard.Security;
using Orchard.UI.Admin;
using Orchard.DisplayManagement;
using Orchard.Localization;
using Orchard.Services;
using System.Web.Mvc;
using Orchard.Mvc.Filters;
﻿using Orchard.ContentManagement;

namespace Orchard.AntiSpam.Models {
    public class SpamFilterPart : ContentPart<SpamFilterPartRecord> {
        public SpamStatus Status {
            get { return Record.Status; }
            set { Record.Status = value; }
        }
    }
}
