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

namespace Orchard.Packaging {
    public class Permissions : IPermissionProvider {
        public static readonly Permission ManagePackages = new Permission { Description = "Manage packages", Name = "ManagePackages" };
        public virtual Feature Feature { get; set; }
        public IEnumerable<Permission> GetPermissions() {
            return new[] { ManagePackages };
        }
        public IEnumerable<PermissionStereotype> GetDefaultStereotypes() {
            // By default no one can manage packages except the default site administrator
            return new List<PermissionStereotype>();
    }
}
