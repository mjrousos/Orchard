using Orchard.ContentManagement;
using Orchard.Security;
using Orchard.UI.Admin;
using Orchard.DisplayManagement;
using Orchard.Localization;
using Orchard.Services;
using System.Web.Mvc;
using Orchard.Mvc.Filters;
﻿using System.Collections.Generic;
using Orchard.UI.Admin.Notification;
using Orchard.UI.Notify;
using System.Linq;

namespace Orchard.MessageBus.Services {
    public class MessageBusNotificationProvider : INotificationProvider {
        private readonly IEnumerable<IMessageBroker> _messageBrokers;
        public MessageBusNotificationProvider(IEnumerable<IMessageBroker> messageBrokers) {
            _messageBrokers = messageBrokers;
            T = NullLocalizer.Instance;
        }
        public Localizer T { get; set; }
        public IEnumerable<NotifyEntry> GetNotifications() {
            if (!_messageBrokers.Any()) {
                yield return new NotifyEntry { Message = T("You need to enable an message bus broker implementation like SQL Server Service Broker."), Type = NotifyType.Warning };
            }
    }
}
