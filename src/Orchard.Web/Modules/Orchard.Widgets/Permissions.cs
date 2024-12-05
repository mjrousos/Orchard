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

namespace Orchard.Widgets {
    public class Permissions : IPermissionProvider {
        public static readonly Permission ManageWidgets = new Permission { Description = "Managing Widgets", Name = "ManageWidgets" };
        public virtual Feature Feature { get; set; }
        public IEnumerable<Permission> GetPermissions() {
            return new[] {
                ManageWidgets,
            };
        }
        public IEnumerable<PermissionStereotype> GetDefaultStereotypes() {
                new PermissionStereotype {
                    Name = "Administrator",
                    Permissions = new[] {ManageWidgets}
                },
    }
}
