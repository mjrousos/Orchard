using Orchard.ContentManagement;
using Orchard.Security;
using Orchard.UI.Admin;
using Orchard.DisplayManagement;
using Orchard.Localization;
using Orchard.Services;
using System.Web.Mvc;
using Orchard.Mvc.Filters;
﻿using System;

namespace Orchard.Messaging.Services {
    public interface IMessageChannelSelector : IDependency {
        MessageChannelSelectorResult GetChannel(string messageType, object payload);
    }
    public class MessageChannelSelectorResult {
        public int Priority { get; set; }
        public Func<IMessageChannel> MessageChannel { get; set; }
}
