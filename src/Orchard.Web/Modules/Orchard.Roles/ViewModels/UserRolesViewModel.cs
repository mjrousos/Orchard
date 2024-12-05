using Orchard.ContentManagement;
using Orchard.Security;
using Orchard.UI.Admin;
using Orchard.DisplayManagement;
using Orchard.Localization;
using Orchard.Services;
using System.Web.Mvc;
using Orchard.Mvc.Filters;
﻿using System.Collections.Generic;
using Orchard.Roles.Models;

namespace Orchard.Roles.ViewModels {
    public class UserRolesViewModel {
        public UserRolesViewModel() {
            Roles = new List<UserRoleEntry>();
            AuthorizedRoleIds = new List<int>();
        }
        public IUser User { get; set; }
        public IUserRoles UserRoles { get; set; }
        public IList<UserRoleEntry> Roles { get; set; }
        public IList<int> AuthorizedRoleIds { get; set; }
    }
    public class UserRoleEntry {
        public int RoleId { get; set; }
        public string Name { get; set; }
        public bool Granted { get; set; }
}
