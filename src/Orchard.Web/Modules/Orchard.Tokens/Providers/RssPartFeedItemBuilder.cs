using Orchard.ContentManagement;
using Orchard.Security;
using Orchard.UI.Admin;
using Orchard.DisplayManagement;
using Orchard.Localization;
using Orchard.Services;
using System.Web.Mvc;
using Orchard.Mvc.Filters;
﻿using System;
using System.Linq;
using System.Xml.Linq;
using Orchard.Core.Feeds;
using Orchard.Core.Feeds.Models;
using Orchard.Environment.Extensions;
using Orchard.Tokens.Models;
using Orchard.Tokens.Settings;

namespace Orchard.Tokens.Providers {
    [OrchardFeature("Orchard.Tokens.Feeds")]
    public class RssPartFeedItemBuilder : IFeedItemBuilder {
        private readonly ITokenizer _tokenizer;
        public RssPartFeedItemBuilder(
            ITokenizer tokenizer) {
            _tokenizer = tokenizer;
        }
        public void Populate(FeedContext context) {
            foreach (var feedItem in context.Response.Items.OfType<FeedItem<ContentItem>>()) {
                var rssPart = feedItem.Item.As<RssPart>();
                if (rssPart == null) {
                    continue;
                }
                var settings = rssPart.TypePartDefinition.Settings.GetModel<RssPartSettings>();
                // add to known formats
                if (context.Format == "rss") {
                    if (!String.IsNullOrWhiteSpace(settings.Title)) {
                        var title = feedItem.Element.Element("title");
                        if (settings.Title == "-") {
                            if (title != null) {
                                title.Remove();
                            }
                        }
                        else {
                            if (title == null) {
                                feedItem.Element.Add(title = new XElement("title"));
                            FeedItem<ContentItem> item = feedItem;
                            context.Response.Contextualize(requestContext => {
                                title.Value = _tokenizer.Replace(settings.Title, new { Content = item.Item, Text = title.Value });
                            });
                    }
                    if (!String.IsNullOrWhiteSpace(settings.Author)) {
                        var author = feedItem.Element.Element("author");
                        if (settings.Author == "-") {
                            if (author != null) {
                                author.Remove();
                            if (author == null) {
                                feedItem.Element.Add(author = new XElement("author"));
                                author.Value = _tokenizer.Replace(settings.Author, new { Content = item.Item, Text = author.Value });
                    if (!String.IsNullOrWhiteSpace(settings.Description)) {
                        var description = feedItem.Element.Element("description");
                        if (settings.Description == "-") {
                            if (description != null) {
                                description.Remove();
                            if (description == null) {
                                feedItem.Element.Add(description = new XElement("description"));
                                description.Value = _tokenizer.Replace(settings.Description, new { Content = item.Item, Text = description.Value }, new ReplaceOptions { Encoding = ReplaceOptions.NoEncode });
                    if (!String.IsNullOrWhiteSpace(settings.Enclosure)) {
                        var enclosure = feedItem.Element.Element("enclosure");
                        if (settings.Enclosure == "-") {
                            if (enclosure != null) {
                                enclosure.Remove();
                            if (enclosure == null) {
                                feedItem.Element.Add(enclosure = new XElement("enclosure"));
                                enclosure.Value = _tokenizer.Replace(settings.Enclosure, new { Content = item.Item, Text = enclosure.Value });
                    if (!String.IsNullOrWhiteSpace(settings.Link)) {
                        var link = feedItem.Element.Element("link");
                        if (settings.Link == "-") {
                            if (link != null) {
                                link.Remove();
                            if (link == null) {
                                feedItem.Element.Add(link = new XElement("link"));
                                link.Value = _tokenizer.Replace(settings.Link, new { Content = item.Item, Text = link.Value });
                    if (!String.IsNullOrWhiteSpace(settings.PubDate)) {
                        var pubDate = feedItem.Element.Element("pubDate");
                        if (settings.PubDate == "-") {
                            if (pubDate != null) {
                                pubDate.Remove();
                            if (pubDate == null) {
                                feedItem.Element.Add(pubDate = new XElement("pubDate"));
                                pubDate.Value = _tokenizer.Replace(settings.PubDate, new { Content = item.Item, Text = pubDate.Value });
                    if (!String.IsNullOrWhiteSpace(settings.Source)) {
                        var source = feedItem.Element.Element("source");
                        if (settings.Source == "-") {
                            if (source != null) {
                                source.Remove();
                            if (source == null) {
                                feedItem.Element.Add(source = new XElement("source"));
                                source.Value = _tokenizer.Replace(settings.Source, new { Content = item.Item, Text = source.Value });
                    if (!String.IsNullOrWhiteSpace(settings.Category)) {
                        var categories = feedItem.Element.Elements("category").ToArray();
                        var currentValue = String.Join(",", categories.Select(x => x.Value).ToArray());
                        if (settings.Category == "-") {
                            foreach (var category in categories) {
                                category.Remove();
                                var newValue = _tokenizer.Replace(settings.Category, new { Content = item.Item, Text = currentValue });
                                foreach (var value in newValue.Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries)) {
                                    feedItem.Element.Add(new XElement("category", value));
                                }
            }
    }
}
