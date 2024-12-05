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
using System.Web.Routing;
using System.Xml.Linq;
using Orchard.Blogs.Models;
using Orchard.Core.Feeds;
using Orchard.Core.Feeds.Models;
using Orchard.Mvc.Extensions;

namespace Orchard.Blogs.Feeds {
    public class BlogPartFeedItemBuilder : IFeedItemBuilder {
        private IContentManager _contentManager;
        public BlogPartFeedItemBuilder(IContentManager contentManager) {
            _contentManager = contentManager;
        }
        public void Populate(FeedContext context) {
            var containerIdValue = context.ValueProvider.GetValue("containerid");
            if (containerIdValue == null)
                return;
            var containerId = (int)containerIdValue.ConvertTo(typeof(int));
            var container = _contentManager.Get(containerId);
            if (container == null) {
            }
            if (container.ContentType != "Blog") {
            var blog = container.As<BlogPart>();
            if (context.Format == "rss") {
                context.Response.Element.SetElementValue("description", blog.Description);
            else {
                context.Builder.AddProperty(context, null, "description", blog.Description);
    }
}
