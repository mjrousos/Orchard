using Orchard.ContentManagement;
using Orchard.Security;
using Orchard.UI.Admin;
using Orchard.DisplayManagement;
using Orchard.Localization;
using Orchard.Services;
using System.Web.Mvc;
using Orchard.Mvc.Filters;
﻿using System.Collections.Generic;
using Orchard.Messaging.Services;
using Orchard.Messaging.Models;

namespace Orchard.Tests.Messaging {
    public class MessagingChannelStub : IMessageChannel {
        public List<IDictionary<string, object>> Messages { get; private set; }
        
        public MessagingChannelStub() {
            Messages = new List<IDictionary<string, object>>();
        }
        public void Process(IDictionary<string, object> parameters) {
            Messages.Add(parameters);
    }
}
