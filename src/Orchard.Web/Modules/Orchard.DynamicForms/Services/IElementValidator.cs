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
    public interface IElementValidator : IDependency {
        void Validate(FormElement element, ValidateInputContext context);
        void RegisterClientValidation(FormElement element, RegisterClientValidationAttributesContext context);
    }
}
