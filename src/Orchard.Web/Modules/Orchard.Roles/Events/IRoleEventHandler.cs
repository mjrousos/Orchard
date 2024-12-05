using Orchard.ContentManagement;
using Orchard.Security;
using Orchard.UI.Admin;
using Orchard.DisplayManagement;
using Orchard.Localization;
using Orchard.Services;
using System.Web.Mvc;
using Orchard.Mvc.Filters;
﻿using Orchard.Events;

namespace Orchard.Roles.Events {
    public interface IRoleEventHandler : IEventHandler {
        void Created(RoleCreatedContext context);
        void Removed(RoleRemovedContext context);
        void Renamed(RoleRenamedContext context);
        void PermissionAdded(PermissionAddedContext context);
        void PermissionRemoved(PermissionRemovedContext context);
        void UserAdded(UserAddedContext context);
        void UserRemoved(UserRemovedContext context);
    }
}
