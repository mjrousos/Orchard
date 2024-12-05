using Orchard.ContentManagement;
using Orchard.Security;
using Orchard.UI.Admin;
using Orchard.DisplayManagement;
using Orchard.Localization;
using Orchard.Services;
using System.Web.Mvc;
using Orchard.Mvc.Filters;
﻿using Orchard.Blogs.Models;
using Orchard.ContentManagement.Drivers;
using Orchard.Environment.Extensions;

namespace Orchard.Blogs.Drivers {
    [OrchardFeature("Orchard.Blogs.RemotePublishing")]
    public class RemoteBlogPublishingDriver : ContentPartDriver<BlogPart> {
        protected override DriverResult Display(BlogPart part, string displayType, dynamic shapeHelper) {
            return ContentShape("Parts_Blogs_RemotePublishing", shape => shape.Blog(part));
        }
    }
}
