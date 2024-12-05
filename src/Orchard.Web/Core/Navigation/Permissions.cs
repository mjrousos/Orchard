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

namespace Orchard.Core.Navigation {
    public class Permissions : IPermissionProvider {
        public static readonly Permission ManageMenus = new Permission { Name = "ManageMenus", Description = "Manage all menus" };
        public virtual Feature Feature { get; set; }
        public IEnumerable<Permission> GetPermissions() {
            return new[] {
                ManageMenus
             };
        }
        public IEnumerable<PermissionStereotype> GetDefaultStereotypes() {
                new PermissionStereotype {
                    Name = "Administrator",
                    Permissions = new[] {ManageMenus}
                }
            };
    }
}
