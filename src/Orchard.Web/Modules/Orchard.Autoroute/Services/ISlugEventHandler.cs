using Orchard.ContentManagement;
using Orchard.Security;
using Orchard.UI.Admin;
using Orchard.DisplayManagement;
using Orchard.Localization;
using Orchard.Services;
using System.Web.Mvc;
using Orchard.Mvc.Filters;
﻿using Orchard.Events;

namespace Orchard.Autoroute.Services {
    public interface ISlugEventHandler : IEventHandler {
        void FillingSlugFromTitle(FillSlugContext context);
        void FilledSlugFromTitle(FillSlugContext context);
    }
    public class FillSlugContext {
        public FillSlugContext(IContent content, string title) {
            Content = content;
            Title = title;
        }
        public IContent Content { get; set; }
        public string Title { get; set; }
        public string Slug { get; set; }
        public bool Adjusted { get; set; }
}
