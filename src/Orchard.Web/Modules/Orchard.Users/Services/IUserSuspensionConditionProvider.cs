using Orchard.ContentManagement;
using Orchard.Security;
using Orchard.UI.Admin;
using Orchard.DisplayManagement;
using Orchard.Localization;
using Orchard.Services;
using System.Web.Mvc;
using Orchard.Mvc.Filters;
﻿using Orchard.ContentManagement;
using Orchard.Users.Models;

namespace Orchard.Users.Services {
    public interface IUserSuspensionConditionProvider : IDependency {
        IContentQuery<UserPart> AlterQuery(
            IContentQuery<UserPart> query);
        bool UserIsProtected(UserPart userPart);
    }
}
