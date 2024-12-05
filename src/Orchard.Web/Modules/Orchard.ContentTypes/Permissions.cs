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

namespace Orchard.ContentTypes {
    public class Permissions : IPermissionProvider {
        public static readonly Permission ViewContentTypes = new Permission { Name = "ViewContentTypes", Description = "View content types" };
        public static readonly Permission EditContentTypes = new Permission { Name = "EditContentTypes", Description = "Edit content types" };
        public virtual Feature Feature { get; set; }
        public IEnumerable<Permission> GetPermissions() {
            return new [] {
                ViewContentTypes,
                EditContentTypes
            };
        }
        public IEnumerable<PermissionStereotype> GetDefaultStereotypes() {
            return new[] {
                new PermissionStereotype {
                    Name = "Administrator",
                    Permissions = GetPermissions()
                }
    }
}
