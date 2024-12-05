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
using System.Text;
using System.Threading.Tasks;
using Orchard.Messaging.Services;

namespace Orchard.Tests.Modules.Stubs {
    public class MessageChannelSelectorStub : IMessageChannelSelector {
        private IMessageChannel _messageChannel;
        public MessageChannelSelectorStub(IMessageChannel messageChannel) {
            _messageChannel = messageChannel;
        }
        public MessageChannelSelectorResult GetChannel(string messageType, object payload) {
            return new MessageChannelSelectorResult {
                Priority = 0,
                MessageChannel = () => { return _messageChannel; }
            };
    }
}
