using Orchard.ContentManagement;
using Orchard.Security;
using Orchard.UI.Admin;
using Orchard.DisplayManagement;
using Orchard.Localization;
using Orchard.Services;
using System.Web.Mvc;
using Orchard.Mvc.Filters;
﻿using Orchard.ContentManagement;

namespace Orchard.Users.Models {
    public class UserSecurityConfigurationPart : ContentPart<UserSecurityConfigurationPartRecord> {
        public bool SaveFromSuspension {
            get { return Retrieve(x => x.SaveFromSuspension); }
            set { Store(x => x.SaveFromSuspension, value); }
        }
        public bool PreventPasswordExpiration {
            get { return Retrieve(x => x.PreventPasswordExpiration); }
            set { Store(x => x.PreventPasswordExpiration, value); }
    }
}
