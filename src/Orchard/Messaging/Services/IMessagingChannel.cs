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
using Orchard.Messaging.Models;

namespace Orchard.Messaging.Services {
    [Obsolete]
    public interface IMessagingChannel : IDependency {
        /// <summary>
        /// Actually sends the message though this channel
        /// </summary>
        void SendMessage(MessageContext message);
        /// Provides all the handled services, the user can choose from when receving messages
        IEnumerable<string> GetAvailableServices();
    }
}
