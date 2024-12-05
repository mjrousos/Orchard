using Orchard.ContentManagement;
using Orchard.Security;
using Orchard.UI.Admin;
using Orchard.DisplayManagement;
using Orchard.Localization;
using Orchard.Services;
using System.Web.Mvc;
using Orchard.Mvc.Filters;
﻿using System.Collections.Generic;
using Orchard.UI.Notify;

namespace Orchard.UI.Admin.Notification {
    public interface INotificationProvider : IDependency {
        /// <summary>
        /// Returns all notifications to display per zone
        /// </summary>
        IEnumerable<NotifyEntry> GetNotifications();
    }
}
