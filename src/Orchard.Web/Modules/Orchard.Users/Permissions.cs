using Orchard.ContentManagement;
using Orchard.Security;
using Orchard.UI.Admin;
using Orchard.DisplayManagement;
using Orchard.Localization;
using Orchard.Services;
using System.Web.Mvc;
using Orchard.Mvc.Filters;
﻿using System.Collections.Generic;
using Orchard.Environment.Extensions.Models;
using Orchard.Security.Permissions;

namespace Orchard.Users {
    public class Permissions : IPermissionProvider {
        public static readonly Permission ManageUsers =
            new Permission { Description = "Managing Users", Name = "ManageUsers" };
        public static readonly Permission ViewUsers =
            new Permission { Description = "View List of Users", Name = "ViewUsers", ImpliedBy = new[] { ManageUsers } };
        public virtual Feature Feature { get; set; }
        public IEnumerable<Permission> GetPermissions() {
            return new[] {
                ManageUsers, ViewUsers
            };
        }
        public IEnumerable<PermissionStereotype> GetDefaultStereotypes() {
                new PermissionStereotype {
                    Name = "Administrator",
                    Permissions = new[] { ManageUsers, ViewUsers }
                },
    }
}
