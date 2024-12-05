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

namespace Orchard.Templates {
    public class Permissions : IPermissionProvider {
        public static readonly Permission ManageTemplates = new Permission { Description = "Managing Templates", Name = "ManageTemplates" };
        public virtual Feature Feature { get; set; }
        public IEnumerable<Permission> GetPermissions() {
            return new[] {
                ManageTemplates,
            };
        }
        public IEnumerable<PermissionStereotype> GetDefaultStereotypes() {
                new PermissionStereotype {
                    Name = "Administrator",
                    Permissions = new[] { ManageTemplates }
                },
                    Name = "Editor",
                    Name = "Moderator",
                    Name = "Author"
                    Name = "Contributor",
    }
}
