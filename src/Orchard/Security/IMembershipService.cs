using Orchard.ContentManagement;
using Orchard.Security;
using Orchard.UI.Admin;
using Orchard.DisplayManagement;
using Orchard.Localization;
using Orchard.Services;
using System.Web.Mvc;
using Orchard.Mvc.Filters;
﻿using System.Collections.Generic;

namespace Orchard.Security {
    public interface IMembershipService : IDependency {
        IMembershipSettings GetSettings();
        IUser CreateUser(CreateUserParams createUserParams);
        IUser GetUser(string username);
        IUser ValidateUser(string userNameOrEmail, string password, out List<LocalizedString> validationErrors);
        void SetPassword(IUser user, string password);
        bool PasswordIsExpired(IUser user, int days);
    }
}
