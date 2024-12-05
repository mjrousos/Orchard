using Orchard.ContentManagement;
using Orchard.Security;
using Orchard.UI.Admin;
using Orchard.DisplayManagement;
using Orchard.Localization;
using Orchard.Services;
using System.Web.Mvc;
using Orchard.Mvc.Filters;
﻿using System.Collections.Generic;
using System.Linq;
using Orchard.Environment.Extensions;
using Orchard.Layouts.Elements;
using Orchard.Layouts.Framework.Display;
using Orchard.Layouts.Framework.Drivers;
using Orchard.Mvc;
using Orchard.UI.Notify;

namespace Orchard.Layouts.Drivers {
    [OrchardFeature("Orchard.Layouts.UI")]
    public class NotificationsElementDriver : ElementDriver<Notifications> {
        private readonly IHttpContextAccessor _httpContextAccessor;
        public NotificationsElementDriver(IHttpContextAccessor httpContextAccessor, IShapeFactory shapeFactory) {
            _httpContextAccessor = httpContextAccessor;
            New = shapeFactory;
        }
        public dynamic New { get; set; }
        protected override void OnCreatingDisplay(Notifications element, ElementCreatingDisplayShapeContext context) {
            if (context.DisplayType == "Design")
                return;
            var httpContext = _httpContextAccessor.Current();
            if (httpContext == null)
            var messageEntries = httpContext.Items[NotifyFilter.TempDataMessages] as IList<NotifyEntry> ?? new List<NotifyEntry>();
            context.Cancel = !messageEntries.Any();
        protected override void OnDisplaying(Notifications element, ElementDisplayingContext context) {
            var shapes = messageEntries.Select(x => New.Message(x)).ToList();
            context.ElementShape.Messages = shapes;
    }
}
