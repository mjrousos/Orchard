using Orchard.ContentManagement;
using Orchard.Security;
using Orchard.UI.Admin;
using Orchard.DisplayManagement;
using Orchard.Localization;
using Orchard.Services;
using System.Web.Mvc;
using Orchard.Mvc.Filters;
﻿using System;
using System.Web.Routing;
using System.Xml.Linq;
using Orchard.Core.Feeds;
using Orchard.Core.Feeds.Models;
using Orchard.Environment.Extensions;
using Orchard.Mvc.Extensions;
using Orchard.Tags.Services;

namespace Orchard.Tags.Feeds {
    [OrchardFeature("Orchard.Tags.Feeds")]
    public class TagFeedQuery : IFeedQueryProvider, IFeedQuery {
        private readonly ITagService _tagService;
        public TagFeedQuery(ITagService tagService) {
            _tagService = tagService;
            T = NullLocalizer.Instance;
        }
        public Localizer T { get; set; }
        public FeedQueryMatch Match(FeedContext context) {
            var tagIdValue = context.ValueProvider.GetValue("tag");
            if (tagIdValue == null)
                return null;
            var tagName = (string)tagIdValue.ConvertTo(typeof(string));
            var tag = _tagService.GetTagByName(tagName);
            if (tag == null) {
            }
            return new FeedQueryMatch { FeedQuery = this, Priority = -5 };
        public void Execute(FeedContext context) {
                return;
            var limitValue = context.ValueProvider.GetValue("limit");
            var limit = 20;
            if (limitValue != null) {
                Int32.TryParse(Convert.ToString(limitValue), out limit);
            limit = Math.Min(limit, 100);
            var displayRouteValues = new RouteValueDictionary {
                {"area", "Orchard.Tags"},
                {"controller", "Home"},
                {"action", "Search"},
                {"tagName", tag.TagName}
            };
            if (context.Format == "rss") {
                var link = new XElement("link");
                context.Response.Element.SetElementValue("title", tag.TagName);
                context.Response.Element.Add(link);
                context.Response.Element.SetElementValue("description", T("Content tagged with {0}", tag.TagName).ToString());
                context.Response.Contextualize(requestContext => {
                    var urlHelper = new UrlHelper(requestContext);
                    var uriBuilder = new UriBuilder(urlHelper.MakeAbsolute("/")) { Path = urlHelper.RouteUrl(displayRouteValues) };
                    link.Add(uriBuilder.Uri.OriginalString);
                });
            else {
                context.Builder.AddProperty(context, null, "title", tag.TagName);
                context.Builder.AddProperty(context, null, "description", T("Content tagged with {0}", tag.TagName).ToString());
                    context.Builder.AddProperty(context, null, "link", urlHelper.MakeAbsolute(urlHelper.RouteUrl(displayRouteValues)));
            var items = _tagService.GetTaggedContentItems(tag.Id, 0, limit);
            foreach (var item in items) {
                context.Builder.AddItem(context, item.ContentItem);
    }
}
