using Orchard.ContentManagement;
using Orchard.Security;
using Orchard.UI.Admin;
using Orchard.DisplayManagement;
using Orchard.Localization;
using Orchard.Services;
using System.Web.Mvc;
using Orchard.Mvc.Filters;
﻿namespace Orchard.Messaging.Services {
    /// <summary>
    /// Default empty implementation of <see cref="IMessageChannelSelector"/>
    /// </summary>
    public class NullMessageChannelSelector : IMessageChannelSelector {
        public MessageChannelSelectorResult GetChannel(string messageType, object payload) {
            return null;
        }
    }
}
