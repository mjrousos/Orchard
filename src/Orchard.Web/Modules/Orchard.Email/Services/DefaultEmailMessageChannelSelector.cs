using Orchard.ContentManagement;
using Orchard.Security;
using Orchard.UI.Admin;
using Orchard.DisplayManagement;
using Orchard.Localization;
using Orchard.Services;
using System.Web.Mvc;
using Orchard.Mvc.Filters;
﻿using Orchard.Messaging.Services;

namespace Orchard.Email.Services {
    public class DefaultEmailMessageChannelSelector : Component, IMessageChannelSelector {
        private readonly IWorkContextAccessor _workContextAccessor;
        public const string ChannelName = "Email";
        public DefaultEmailMessageChannelSelector(IWorkContextAccessor workContextAccessor) {
            _workContextAccessor = workContextAccessor;
        }
        public MessageChannelSelectorResult GetChannel(string messageType, object payload) {
            if (messageType == "Email") {
                var workContext = _workContextAccessor.GetContext();
                return new MessageChannelSelectorResult {
                    Priority = 50,
                    MessageChannel = () => workContext.Resolve<ISmtpChannel>()
                };
            }
            return null;
    }
}
