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
    public class TypePadSettingsPart : ContentPart {
        public bool TrustAuthenticatedUsers {
            get { return this.Retrieve(x => x.TrustAuthenticatedUsers); }
            set { this.Store(x => x.TrustAuthenticatedUsers, value); }
        }
        public string ApiKey {
            get { return this.Retrieve(x => x.ApiKey); }
            set { this.Store(x => x.ApiKey, value); }
    }
}
