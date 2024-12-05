using Orchard.ContentManagement;
using Orchard.Security;
using Orchard.UI.Admin;
using Orchard.DisplayManagement;
using Orchard.Localization;
using Orchard.Services;
using System.Web.Mvc;
using Orchard.Mvc.Filters;
using Orchard.DynamicForms.Services.Models;
using Orchard.Tokens;

namespace Orchard.DynamicForms.Services {
    public abstract class ValidationRule : Component, IValidationRule {
        public string ErrorMessage { get; set; }
        public abstract void Validate(ValidateInputContext context);
        public virtual void RegisterClientAttributes(RegisterClientValidationAttributesContext context) { }
        public ITokenizer Tokenizer { get; set; }
        protected string Tokenize(string errorMessage, ValidationContext context) {
            return Tokenizer.Replace(errorMessage, null);
        }
    }
}
