using Orchard.ContentManagement;
using Orchard.Security;
using Orchard.UI.Admin;
using Orchard.DisplayManagement;
using Orchard.Localization;
using Orchard.Services;
using System.Web.Mvc;
using Orchard.Mvc.Filters;
﻿using System.Collections.Generic;
using Orchard.Events;

namespace Orchard.Messaging.Services {
    public interface IMessageService : IEventHandler {
        void Send(string type, IDictionary<string, object> parameters);
    }
}
