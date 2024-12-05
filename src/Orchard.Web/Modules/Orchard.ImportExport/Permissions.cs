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

namespace Orchard.ImportExport {
    public class Permissions : IPermissionProvider {
        public static readonly Permission Import = new Permission { Description = "Import Data", Name = "Import" };
        public static readonly Permission Export = new Permission { Description = "Export Data", Name = "Export" };
        public virtual Feature Feature { get; set; }
        public IEnumerable<Permission> GetPermissions() {
            return new[] { Import, Export };
        }
        public IEnumerable<PermissionStereotype> GetDefaultStereotypes() {
            return new[] {
                             new PermissionStereotype {
                                                          Name = "Administrator",
                                                          Permissions = new[] {Import, Export}
                                                      }
                         };
    }
}
