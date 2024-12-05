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

namespace Orchard.Themes {
    public class Permissions : IPermissionProvider {
        public static readonly Permission ApplyTheme = new Permission { Description = "Apply a Theme", Name = "ApplyTheme" };
        public virtual Feature Feature { get; set; }
        public IEnumerable<Permission> GetPermissions() {
            return new[] {
                                        ApplyTheme,
                                    };
        }
        public IEnumerable<PermissionStereotype> GetDefaultStereotypes() {
                             new PermissionStereotype {
                                                          Name = "Administrator",
                                                          Permissions = new[] {ApplyTheme}
                                                      },
                         };
    }
}
