using Orchard.ContentManagement;
using Orchard.Security;
using Orchard.UI.Admin;
using Orchard.DisplayManagement;
using Orchard.Localization;
using Orchard.Services;
using System.Web.Mvc;
using Orchard.Mvc.Filters;
﻿using Orchard.Events;
using System.Text;

namespace Orchard.OutputCache {
    public interface ICachingEventHandler : IEventHandler {
        void KeyGenerated(StringBuilder key);
    }
}
