using Orchard.ContentManagement;
using Orchard.Security;
using Orchard.UI.Admin;
using Orchard.DisplayManagement;
using Orchard.Localization;
using Orchard.Services;
using System.Web.Mvc;
using Orchard.Mvc.Filters;
﻿namespace Orchard.Security {
    public class DefaultMembershipValidationService : IMembershipValidationService {
        public bool CanAuthenticateWithCookie(IUser user) {
            return true;
        }
    }
}
