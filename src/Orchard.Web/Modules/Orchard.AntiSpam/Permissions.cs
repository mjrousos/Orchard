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

namespace Orchard.AntiSpam {
    public class Permissions : IPermissionProvider {
        public static readonly Permission ManageAntiSpam = new Permission { Description = "Manage anti-spam", Name = "ManageAntiSpam" };
        public virtual Feature Feature { get; set; }
        public IEnumerable<Permission> GetPermissions() {
            return new[] {
                ManageAntiSpam,
            };
        }
        public IEnumerable<PermissionStereotype> GetDefaultStereotypes() {
                new PermissionStereotype {
                    Name = "Administrator",
                    Permissions = new[] {ManageAntiSpam}
                },
                    Name = "Editor",
                    Name = "Moderator",
                    Name = "Author",
                    Permissions = new Permission[0]
                    Name = "Contributor",
                    Permissions = new Permission[0] 
    }
}
