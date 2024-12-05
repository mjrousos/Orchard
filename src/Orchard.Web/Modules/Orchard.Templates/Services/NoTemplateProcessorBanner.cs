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
using System.Web;
using Orchard.UI.Admin.Notification;
using Orchard.UI.Notify;

namespace Orchard.Templates.Services {
    public class NoTemplateProcessorBanner : INotificationProvider {
        private readonly IEnumerable<ITemplateProcessor> _processors;
        public NoTemplateProcessorBanner(IEnumerable<ITemplateProcessor> processors) {
            _processors = processors;
            T = NullLocalizer.Instance;
        }
        public Localizer T { get; set; }
        public IEnumerable<NotifyEntry> GetNotifications() {
            if (!_processors.Any()) {
                yield return new NotifyEntry { Message = T("To be able to use Templates enable a template processor like Razor Templates."), Type = NotifyType.Warning };
            }
    }
}
