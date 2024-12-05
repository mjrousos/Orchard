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
    public interface IValidationRule {
        string ErrorMessage { get; set; }
        void Validate(ValidateInputContext context);
        void RegisterClientAttributes(RegisterClientValidationAttributesContext context);
    }
}
