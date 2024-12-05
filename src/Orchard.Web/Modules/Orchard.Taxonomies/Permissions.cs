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

namespace Orchard.Taxonomies {
    public class Permissions : IPermissionProvider {
        public static readonly Permission ManageTaxonomies = new Permission { Description = "Manage taxonomies", Name = "ManageTaxonomies" };
        public static readonly Permission CreateTaxonomy = new Permission { Description = "Create taxonomy", Name = "CreateTaxonomy", ImpliedBy = new[] { ManageTaxonomies } };
        public static readonly Permission ManageTerms = new Permission { Description = "Manage terms", Name = "ManageTerms", ImpliedBy = new[] { CreateTaxonomy } };
        public static readonly Permission MergeTerms = new Permission { Description = "Merge terms", Name = "MergeTerms", ImpliedBy = new[] { ManageTerms } };
        public static readonly Permission CreateTerm = new Permission { Description = "Create term", Name = "CreateTerm", ImpliedBy = new[] { ManageTerms, MergeTerms } };
        public static readonly Permission EditTerm = new Permission { Description = "Edit term", Name = "EditTerm", ImpliedBy = new[] { ManageTerms, MergeTerms } };
        public static readonly Permission DeleteTerm = new Permission { Description = "Delete term", Name = "DeleteTerm", ImpliedBy = new[] { ManageTerms, MergeTerms } };
        public virtual Feature Feature { get; set; }
        public IEnumerable<Permission> GetPermissions() {
            return new[] {
                ManageTaxonomies,
                CreateTaxonomy,
                ManageTerms,
                MergeTerms,
                CreateTerm,
                EditTerm,
                DeleteTerm
            };
        }
        public IEnumerable<PermissionStereotype> GetDefaultStereotypes() {
                new PermissionStereotype {
                    Name = "Administrator",
                    Permissions = new[] {ManageTaxonomies}
                },
                    Name = "Editor",
                    Name = "Moderator",
                    Name = "Author",
                    Permissions = new[] {CreateTaxonomy}
                    Name = "Contributor",
                    Permissions = new Permission[0] 
    }
}
