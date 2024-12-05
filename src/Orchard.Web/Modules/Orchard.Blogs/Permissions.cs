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

namespace Orchard.Blogs {
    public class Permissions : IPermissionProvider {
        public static readonly Permission ManageBlogs = new Permission { Description = "Manage blogs for others", Name = "ManageBlogs" };
        public static readonly Permission ManageOwnBlogs = new Permission { Description = "Manage own blogs", Name = "ManageOwnBlogs", ImpliedBy = new[] { ManageBlogs } };
        public static readonly Permission PublishBlogPost = new Permission { Description = "Publish or unpublish blog post for others", Name = "PublishBlogPost", ImpliedBy = new[] { ManageBlogs } };
        public static readonly Permission PublishOwnBlogPost = new Permission { Description = "Publish or unpublish own blog post", Name = "PublishOwnBlogPost", ImpliedBy = new[] { PublishBlogPost, ManageOwnBlogs } };
        public static readonly Permission EditBlogPost = new Permission { Description = "Edit blog posts for others", Name = "EditBlogPost", ImpliedBy = new[] { PublishBlogPost } };
        public static readonly Permission EditOwnBlogPost = new Permission { Description = "Edit own blog posts", Name = "EditOwnBlogPost", ImpliedBy = new[] { EditBlogPost, PublishOwnBlogPost } };
        public static readonly Permission DeleteBlogPost = new Permission { Description = "Delete blog post for others", Name = "DeleteBlogPost", ImpliedBy = new[] { ManageBlogs } };
        public static readonly Permission DeleteOwnBlogPost = new Permission { Description = "Delete own blog post", Name = "DeleteOwnBlogPost", ImpliedBy = new[] { DeleteBlogPost, ManageOwnBlogs } };
        public static readonly Permission MetaListBlogs = new Permission { ImpliedBy = new[] { EditBlogPost, PublishBlogPost, DeleteBlogPost }, Name = "MetaListBlogs"};
        public static readonly Permission MetaListOwnBlogs = new Permission { ImpliedBy = new[] { EditOwnBlogPost, PublishOwnBlogPost, DeleteOwnBlogPost }, Name = "MetaListOwnBlogs" };
        public virtual Feature Feature { get; set; }
        public IEnumerable<Permission> GetPermissions() {
            return new[] {
                ManageOwnBlogs,
                ManageBlogs,
                EditOwnBlogPost,
                EditBlogPost,
                PublishOwnBlogPost,
                PublishBlogPost,
                DeleteOwnBlogPost,
                DeleteBlogPost,
            };
        }
        public IEnumerable<PermissionStereotype> GetDefaultStereotypes() {
                new PermissionStereotype {
                    Name = "Administrator",
                    Permissions = new[] {ManageBlogs}
                },
                    Name = "Editor",
                    Permissions = new[] {PublishBlogPost,EditBlogPost,DeleteBlogPost}
                    Name = "Moderator",
                    Name = "Author",
                    Permissions = new[] {ManageOwnBlogs}
                    Name = "Contributor",
                    Permissions = new[] {EditOwnBlogPost}
    }
}
