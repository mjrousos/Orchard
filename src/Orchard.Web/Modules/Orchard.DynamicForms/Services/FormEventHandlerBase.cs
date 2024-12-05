using Orchard.ContentManagement;
using Orchard.Security;
using Orchard.UI.Admin;
using Orchard.DisplayManagement;
using Orchard.Localization;
using Orchard.Services;
using System.Web.Mvc;
using Orchard.Mvc.Filters;
using Orchard.DynamicForms.Services.Models;

namespace Orchard.DynamicForms.Services {
    public abstract class FormEventHandlerBase : Component, IDynamicFormEventHandler {
        public virtual void Submitted(FormSubmittedEventContext context) {}
        public virtual void Validating(FormValidatingEventContext context) {}
        public virtual void Validated(FormValidatedEventContext context) {}
    }
}
