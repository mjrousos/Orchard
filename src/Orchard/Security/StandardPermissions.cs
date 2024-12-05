using Orchard.ContentManagement;
using Orchard.Security;
using Orchard.UI.Admin;
using Orchard.DisplayManagement;
using Orchard.Localization;
using Orchard.Services;
using System.Web.Mvc;
using Orchard.Mvc.Filters;
﻿using System;
using System.Collections.Generic;
using System.Linq;
using Orchard.Environment.Extensions.Models;
using Orchard.Security.Permissions;

namespace Orchard.Security {
    public class StandardPermissions : IPermissionProvider {
        public static readonly Permission AccessAdminPanel = new Permission { Name = "AccessAdminPanel", Description = "Access admin panel" };
        public static readonly Permission AccessFrontEnd = new Permission { Name = "AccessFrontEnd", Description = "Access site front-end" };
        public static readonly Permission SiteOwner = new Permission { Name = "SiteOwner", Description = "Site Owners Permission" }; 
        public Feature Feature {
            get {
                // This is a lie, but it enables the permissions and stereotypes to be created
                return new Feature {
                    Descriptor = new FeatureDescriptor {
                        Id = "Orchard.Framework",
                        Category = "Core",
                        Dependencies = Enumerable.Empty<string>(),
                        Description = "",
                        Extension = new ExtensionDescriptor {
                            Id = "Orchard.Framework"
                        }
                    },
                    ExportedTypes = Enumerable.Empty<Type>()
                };
            }
        }
        public IEnumerable<Permission> GetPermissions() {
            return new[] {
                AccessAdminPanel,
                AccessFrontEnd,
                SiteOwner
            };
        public IEnumerable<PermissionStereotype> GetDefaultStereotypes() {
                new PermissionStereotype {
                    Name = "Administrator",
                    Permissions = new[] {SiteOwner, AccessAdminPanel}
                },
                    Name = "Anonymous",
                    Permissions = new[] {AccessFrontEnd}
                    Name = "Authenticated",
                    Name = "Editor",
                    Permissions = new[] {AccessAdminPanel}
                    Name = "Moderator",
                    Name = "Author",
                    Name = "Contributor",
    }
}
