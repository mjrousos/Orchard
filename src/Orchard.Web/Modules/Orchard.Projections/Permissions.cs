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

namespace Orchard.Projections {
    public class Permissions : IPermissionProvider {
        public static readonly Permission ManageQueries = new Permission { Description = "Manage queries", Name = "ManageQueries", Category = "Projection"};
        public virtual Feature Feature { get; set; }
        public IEnumerable<Permission> GetPermissions() {
            yield return ManageQueries;
        }
        public IEnumerable<PermissionStereotype> GetDefaultStereotypes() {
            return new[] {
                new PermissionStereotype {
                    Name = "Administrator",
                    Permissions = new[] { ManageQueries }
                },
                    Name = "Editor",
                }
            };
    }
}
