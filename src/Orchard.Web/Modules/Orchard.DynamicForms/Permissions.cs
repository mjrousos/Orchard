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
using Orchard.DynamicForms.Elements;
using Orchard.Environment.Extensions.Models;
using Orchard.Security.Permissions;

namespace Orchard.DynamicForms {
    public class Permissions : IPermissionProvider {
        private static readonly Permission SubmitAnyForm = new Permission { Description = "Submit any forms", Name = "Submit" };
        private static readonly Permission SubmitForm = new Permission { Description = "Submit {0} forms", Name = "Submit_{0}", ImpliedBy = new[] { SubmitAnyForm } };
        public static readonly Permission ManageForms = new Permission { Description = "Manage custom forms", Name = "ManageForms" };
        public virtual Feature Feature { get; set; }
        public IEnumerable<Permission> GetPermissions() {
            yield return SubmitAnyForm;
            yield return ManageForms;
        }
        public IEnumerable<PermissionStereotype> GetDefaultStereotypes() {
            return new[] {
                new PermissionStereotype {
                    Name = "Administrator",
                    Permissions = new[] { SubmitAnyForm, ManageForms }
                },
                    Name = "Editor",
                    Permissions = new[] { SubmitAnyForm }
                    Name = "Moderator",
                    Name = "Author",
                    Name = "Contributor",
                }
            };
        /// <summary>
        /// Generates a permission dynamically for a content type
        /// </summary>
        public static Permission CreateSubmitPermission(Form form) {
            return new Permission {
                Name = String.Format(SubmitForm.Name, form.Name),
                Description = String.Format(SubmitForm.Description, form.Name),
                Category = "Dynamic Forms",
                ImpliedBy = new [] { SubmitForm }
    }
}
