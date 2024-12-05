using Orchard.ContentManagement;
using Orchard.Security;
using Orchard.UI.Admin;
using Orchard.DisplayManagement;
using Orchard.Localization;
using Orchard.Services;
using System.Web.Mvc;
using Orchard.Mvc.Filters;
using Orchard.DynamicForms.Elements;
using Orchard.DynamicForms.Services.Models;

namespace Orchard.DynamicForms.Services {
    public abstract class FormElementEventHandlerBase : IFormElementEventHandler {
        public virtual void GetElementValue(FormElement element, ReadElementValuesContext context) {}
        public virtual void RegisterClientValidation(FormElement element, RegisterClientValidationAttributesContext context) {}
    }
}
