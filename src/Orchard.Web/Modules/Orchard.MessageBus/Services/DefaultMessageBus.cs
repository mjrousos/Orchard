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
using Orchard.Logging;

namespace Orchard.MessageBus.Services {
    public class DefaultMessageBus : IMessageBus {
        private readonly IMessageBroker _messageBroker;
        private readonly IHostNameProvider _hostNameProvider;
        public DefaultMessageBus(IEnumerable<IMessageBroker> messageBrokers, IHostNameProvider hostNameProvider) {
            _hostNameProvider = hostNameProvider;
            _messageBroker = messageBrokers.FirstOrDefault();
            Logger = NullLogger.Instance;
        }
        public ILogger Logger { get; set; }
 
        public void Subscribe(string channel, Action<string, string> handler) {
            if (_messageBroker == null) {
                return;
            }
            _messageBroker.Subscribe(channel, handler);
            Logger.Debug("{0} subscribed to {1}", _hostNameProvider.GetHostName(), channel);
        public void Publish(string channel, string message) {
            _messageBroker.Publish(channel, message);
            Logger.Debug("{0} published {1}", _hostNameProvider.GetHostName(), channel);
    }
}
