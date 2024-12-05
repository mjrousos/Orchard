using Orchard.ContentManagement;
using Orchard.Security;
using Orchard.UI.Admin;
using Orchard.DisplayManagement;
using Orchard.Localization;
using Orchard.Services;
using System.Web.Mvc;
using Orchard.Mvc.Filters;
using Orchard.Core.Feeds.Models;

namespace Orchard.Core.Feeds {
    public interface IFeedQuery {
        void Execute(FeedContext context);
    }
}
