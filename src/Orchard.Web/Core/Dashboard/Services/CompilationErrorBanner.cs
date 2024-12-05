using Orchard.ContentManagement;
using Orchard.Security;
using Orchard.UI.Admin;
using Orchard.DisplayManagement;
using Orchard.Localization;
using Orchard.Services;
using System.Web.Mvc;
using Orchard.Mvc.Filters;
﻿using System.Linq;
using System.Collections.Generic;
using Orchard.Environment.Extensions;
using Orchard.UI.Admin.Notification;
using Orchard.UI.Notify;

namespace Orchard.Core.Dashboard.Services {
    public class CompilationErrorBanner : INotificationProvider {
        private readonly ICriticalErrorProvider _errorProvider;
        public CompilationErrorBanner(ICriticalErrorProvider errorProvider) {
            _errorProvider = errorProvider;
            T = NullLocalizer.Instance;
        }
        public Localizer T { get; set; }
        public IEnumerable<NotifyEntry> GetNotifications() {
            return _errorProvider.GetErrors()
                .Select(message => new NotifyEntry { Message = message, Type = NotifyType.Error });
    }
}
