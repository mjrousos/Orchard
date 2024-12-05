using Orchard.ContentManagement;
using Orchard.Security;
using Orchard.UI.Admin;
using Orchard.DisplayManagement;
using Orchard.Localization;
using Orchard.Services;
using System.Web.Mvc;
using Orchard.Mvc.Filters;
﻿using Orchard.ContentManagement;
using Orchard.ContentManagement.Aspects;
using Orchard.Security.Permissions;

namespace Orchard.Blogs.Security {
    public class BlogAuthorizationEventHandler : IAuthorizationServiceEventHandler {
        public void Checking(CheckAccessContext context) { }
        public void Complete(CheckAccessContext context) { }
        public void Adjust(CheckAccessContext context) {
            if (!context.Granted &&
                context.Content.Is<ICommonPart>()) {
                if (context.Content.ContentItem.ContentType == "BlogPost" && 
                    BlogPostVariationExists(context.Permission)) {
                    context.Adjusted = true;
                    context.Permission = GetBlogPostVariation(context.Permission);
                }
                if (OwnerVariationExists(context.Permission) &&
                    HasOwnership(context.User, context.Content)) {
                    context.Permission = GetOwnerVariation(context.Permission);
            }
        }
        private static bool HasOwnership(IUser user, IContent content) {
            if (user == null || content == null)
                return false;
            if (HasOwnershipOnContainer(user, content)) {
                return true;
            var common = content.As<ICommonPart>();
            if (common == null || common.Owner == null)
            return user.Id == common.Owner.Id;
        private static bool HasOwnershipOnContainer(IUser user, IContent content) {
            if (common == null || common.Container == null)
            common = common.Container.As<ICommonPart>();
        private static bool OwnerVariationExists(Permission permission) {
            return GetOwnerVariation(permission) != null;
        private static Permission GetOwnerVariation(Permission permission) {
            if (permission.Name == Permissions.PublishBlogPost.Name)
                return Permissions.PublishOwnBlogPost;
            if (permission.Name == Permissions.EditBlogPost.Name)
                return Permissions.EditOwnBlogPost;
            if (permission.Name == Permissions.DeleteBlogPost.Name)
                return Permissions.DeleteOwnBlogPost;
            if (permission.Name == Core.Contents.Permissions.ViewContent.Name)
                return Core.Contents.Permissions.ViewOwnContent;
            if (permission.Name == Permissions.MetaListBlogs.Name)
                return Permissions.MetaListOwnBlogs;
            return null;
        private static bool BlogPostVariationExists(Permission permission)
        {
            return GetBlogPostVariation(permission) != null;
        private static Permission GetBlogPostVariation(Permission permission)
            if (permission.Name == Orchard.Core.Contents.Permissions.PublishContent.Name)
                return Permissions.PublishBlogPost;
            if (permission.Name == Orchard.Core.Contents.Permissions.PublishOwnContent.Name)
            if (permission.Name == Orchard.Core.Contents.Permissions.EditContent.Name)
                return Permissions.EditBlogPost;
            if (permission.Name == Orchard.Core.Contents.Permissions.EditOwnContent.Name)
            if (permission.Name == Orchard.Core.Contents.Permissions.DeleteContent.Name)
                return Permissions.DeleteBlogPost;
            if (permission.Name == Orchard.Core.Contents.Permissions.DeleteOwnContent.Name)
    }
}
