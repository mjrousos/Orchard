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

namespace Orchard.Comments {
    public class Permissions : IPermissionProvider {
        public static readonly Permission AddComment = new Permission { Description = "Add comment", Name = "AddComment" };
        public static readonly Permission ManageComments = new Permission { Description = "Manage comments", Name = "ManageComments" };
        public virtual Feature Feature { get; set; }
        public IEnumerable<Permission> GetPermissions() {
            return new[] {
                AddComment,
                ManageComments,
            };
        }
        public IEnumerable<PermissionStereotype> GetDefaultStereotypes() {
                new PermissionStereotype {
                    Name = "Administrator",
                    Permissions = new[] {ManageComments, AddComment}
                },
                    Name = "Anonymous",
                    Permissions = new[] {AddComment}
                    Name = "Authenticated",
                    Name = "Editor",
                    Name = "Moderator",
                    Name = "Author",
                    Name = "Contributor",
    }
}
