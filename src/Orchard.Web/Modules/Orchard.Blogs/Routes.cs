using Orchard.ContentManagement;
using Orchard.Security;
using Orchard.UI.Admin;
using Orchard.DisplayManagement;
using Orchard.Localization;
using Orchard.Services;
using System.Web.Mvc;
using Orchard.Mvc.Filters;
﻿using System.Collections.Generic;
using System.Web.Routing;
using Orchard.Blogs.Routing;
using Orchard.Mvc.Routes;

namespace Orchard.Blogs {
    public class Routes : IRouteProvider {
        private readonly IArchiveConstraint _archiveConstraint;
        private readonly IRsdConstraint _rsdConstraint;
        public Routes(
            IArchiveConstraint archiveConstraint,
            IRsdConstraint rsdConstraint) {
            _archiveConstraint = archiveConstraint;
            _rsdConstraint = rsdConstraint;
        }
        public void GetRoutes(ICollection<RouteDescriptor> routes) {
            var routeDescriptors = new[] {
                             new RouteDescriptor {
                                                     Route = new Route(
                                                         "Admin/Blogs/Create",
                                                         new RouteValueDictionary {
                                                                                      {"area", "Orchard.Blogs"},
                                                                                      {"controller", "BlogAdmin"},
                                                                                      {"action", "Create"}
                                                                                  },
                                                         new RouteValueDictionary(),
                                                                                      {"area", "Orchard.Blogs"}
                                                         new MvcRouteHandler())
                                                 },
                                                         "Admin/Blogs/{blogId}/Edit",
                                                                                      {"action", "Edit"}
                                                         new RouteValueDictionary (),
                                                         "Admin/Blogs/{blogId}/Remove",
                                                                                      {"action", "Remove"}
                                                         "Admin/Blogs/{blogId}",
                                                                                      {"action", "Item"}
                                                         "Admin/Blogs/{blogId}/Posts/Create",
                                                                                      {"controller", "BlogPostAdmin"},
                                                         "Admin/Blogs/Posts/CreateWithoutBlog",
                                                                                      {"action", "CreateWithoutBlog"}
                                                         "Admin/Blogs/{blogId}/Posts/{postId}/Edit",
                                                         "Admin/Blogs/{blogId}/Posts/{postId}/Delete",
                                                                                      {"action", "Delete"}
                                                         "Admin/Blogs/{blogId}/Posts/{postId}/Publish",
                                                                                      {"action", "Publish"}
                                                         "Admin/Blogs/{blogId}/Posts/{postId}/Unpublish",
                                                                                      {"action", "Unpublish"}
                                                         "Admin/Blogs",
                                                                                      {"action", "List"}
                                                         "Blogs",
                                                                                      {"controller", "Blog"},
                                                         "{*path}",
                                                                                      {"controller", "BlogPost"},
                                                                                      {"action", "ListByArchive"}
                                                                                      {"path", _archiveConstraint},
                                                     Priority = 11,
                                                                                      {"controller", "RemoteBlogPublishing"},
                                                                                      {"action", "Rsd"}
                                                                                      {"path", _rsdConstraint}
                                                 }
                         };
            foreach (var routeDescriptor in routeDescriptors)
                routes.Add(routeDescriptor);
    }
}
