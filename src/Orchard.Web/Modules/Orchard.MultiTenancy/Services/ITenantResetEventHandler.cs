using Orchard.ContentManagement;
using Orchard.Security;
using Orchard.UI.Admin;
using Orchard.DisplayManagement;
using Orchard.Localization;
using Orchard.Services;
using System.Web.Mvc;
using Orchard.Mvc.Filters;
﻿using Orchard.Events;

namespace Orchard.MultiTenancy.Services {
    /// <summary>
    /// An event handler interface that allows implementers to execute code when a tenant is being reset.
    /// </summary>
    public interface ITenantResetEventHandler : IEventHandler {
        void Resetting();
    }
}
