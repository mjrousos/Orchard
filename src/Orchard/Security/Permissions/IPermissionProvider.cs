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

namespace Orchard.Security.Permissions {
    /// <summary>
    /// Implemented by modules to enumerate the types of permissions
    /// the which may be granted
    /// </summary>
    public interface IPermissionProvider : IDependency {
        Feature Feature { get; }
        IEnumerable<Permission> GetPermissions();
        IEnumerable<PermissionStereotype> GetDefaultStereotypes();
    }
    public class PermissionStereotype {
        public string Name { get; set; }
        public IEnumerable<Permission> Permissions { get; set; }
}
