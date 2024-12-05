using Orchard.ContentManagement;
using Orchard.Security;
using Orchard.UI.Admin;
using Orchard.DisplayManagement;
using Orchard.Localization;
using Orchard.Services;
using System.Web.Mvc;
using Orchard.Mvc.Filters;
﻿using Orchard.DynamicForms.Services.Models;
using Orchard.Events;

namespace Orchard.DynamicForms.Services {
    public interface IDynamicFormEventHandler : IEventHandler {
        void Submitted(FormSubmittedEventContext context);
        void Validating(FormValidatingEventContext context);
        void Validated(FormValidatedEventContext context);
    }
}
