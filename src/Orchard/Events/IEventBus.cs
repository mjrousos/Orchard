using Orchard.ContentManagement;
using Orchard.Security;
using Orchard.UI.Admin;
using Orchard.DisplayManagement;
using Orchard.Localization;
using Orchard.Services;
using System.Web.Mvc;
using Orchard.Mvc.Filters;
﻿using System.Collections;
using System.Collections.Generic;

namespace Orchard.Events {
    public interface IEventBus : IDependency {
        IEnumerable Notify(string messageName, IDictionary<string, object> eventData);
    }
}
