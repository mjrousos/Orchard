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

namespace Orchard.MediaLibrary.WebSearch {
    public class Permissions : IPermissionProvider {
        public static readonly Permission AccessMediaWebSearch =
            new Permission { Description = "Access Media Web Search", Name = nameof(AccessMediaWebSearch), ImpliedBy = new[] { MediaLibrary.Permissions.ManageMediaContent } };
        public virtual Feature Feature { get; set; }
        public IEnumerable<Permission> GetPermissions() =>
            new[] {
                AccessMediaWebSearch
            };
        public IEnumerable<PermissionStereotype> GetDefaultStereotypes() =>
                new PermissionStereotype {
                    Name = "Administrator",
                    Permissions = new[] { AccessMediaWebSearch }
                },
                    Name = "Editor",
    }
}
