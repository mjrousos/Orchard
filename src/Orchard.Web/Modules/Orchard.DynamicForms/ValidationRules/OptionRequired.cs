using Orchard.ContentManagement;
using Orchard.Security;
using Orchard.UI.Admin;
using Orchard.DisplayManagement;
using Orchard.Localization;
using Orchard.Services;
using System.Web.Mvc;
using Orchard.Mvc.Filters;
﻿using System;
using Orchard.DynamicForms.Helpers;
using Orchard.DynamicForms.Services;
using Orchard.DynamicForms.Services.Models;

namespace Orchard.DynamicForms.ValidationRules {
    public class OptionRequired : ValidationRule {
        public override void Validate(ValidateInputContext context) {
            if (String.IsNullOrWhiteSpace(context.AttemptedValue)) {
                var message = GetValidationMessage(context);
                context.ModelState.AddModelError(context.FieldName, message.Text);
            }
        }
        public override void RegisterClientAttributes(RegisterClientValidationAttributesContext context) {
            context.ClientAttributes["data-val-optionrequired"] = GetValidationMessage(context).Text;
        private LocalizedString GetValidationMessage(ValidationContext context) {
            return String.IsNullOrWhiteSpace(ErrorMessage)
                ? T("An option is required for {0}.", context.FieldName)
                : T(ErrorMessage, context);
    }
}
