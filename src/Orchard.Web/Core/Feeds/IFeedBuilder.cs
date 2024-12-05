using Orchard.ContentManagement;
using Orchard.Security;
using Orchard.UI.Admin;
using Orchard.DisplayManagement;
using Orchard.Localization;
using Orchard.Services;
using System.Web.Mvc;
using Orchard.Mvc.Filters;
using System;
using Orchard.Core.Feeds.Models;

namespace Orchard.Core.Feeds {
    public interface IFeedBuilder {
        ActionResult Process(FeedContext context, Action populate);
        FeedItem<TItem> AddItem<TItem>(FeedContext context, TItem contentItem);
        void AddProperty(FeedContext context, FeedItem feedItem, string name, string value);
    }
}
