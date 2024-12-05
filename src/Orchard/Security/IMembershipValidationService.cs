using Orchard.ContentManagement;
using Orchard.Security;
using Orchard.UI.Admin;
using Orchard.DisplayManagement;
using Orchard.Localization;
using Orchard.Services;
using System.Web.Mvc;
using Orchard.Mvc.Filters;
﻿namespace Orchard.Security {
    public interface IMembershipValidationService : IDependency {
        /// <summary>
        /// Returns <c>true</c> if the user is allowed to login from an auth cookie, <c>false</c> otherwise.
        /// </summary>
        bool CanAuthenticateWithCookie(IUser user);
    }
}
