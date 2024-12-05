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

namespace Orchard.ContentPreview {
    public class Permissions : IPermissionProvider {
        public static readonly Permission ContentPreview =
            new Permission { Name = nameof(ContentPreview), Description = "Display content preview" };
        public virtual Feature Feature { get; set; }
        public IEnumerable<Permission> GetPermissions() => new[] { ContentPreview };
        public IEnumerable<PermissionStereotype> GetDefaultStereotypes() =>
            new[] {
                new PermissionStereotype {
                    Name = "Administrator",
                    Permissions = new[] { ContentPreview }
                }
            };
    }
}
