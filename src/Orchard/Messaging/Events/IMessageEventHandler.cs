using Orchard.ContentManagement;
using Orchard.Security;
using Orchard.UI.Admin;
using Orchard.DisplayManagement;
using Orchard.Localization;
using Orchard.Services;
using System.Web.Mvc;
using Orchard.Mvc.Filters;
﻿using System;
using Orchard.Events;
using Orchard.Messaging.Models;

namespace Orchard.Messaging.Events {
    [Obsolete]
    public interface IMessageEventHandler : IEventHandler {
        void Sending(MessageContext context);
        void Sent(MessageContext context);
    }
}
