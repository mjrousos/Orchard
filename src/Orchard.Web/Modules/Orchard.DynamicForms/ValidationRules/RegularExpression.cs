using Orchard.ContentManagement;
using Orchard.Security;
using Orchard.UI.Admin;
using Orchard.DisplayManagement;
using Orchard.Localization;
using Orchard.Services;
using System.Web.Mvc;
using Orchard.Mvc.Filters;
﻿using System;
using System.Text.RegularExpressions;
using Orchard.DynamicForms.Helpers;
using Orchard.DynamicForms.Services;
using Orchard.DynamicForms.Services.Models;

namespace Orchard.DynamicForms.ValidationRules {
    public class RegularExpression : ValidationRule {
        public RegularExpression() {
            RegexOptions = RegexOptions.Singleline | RegexOptions.IgnoreCase;
        }
        public string Pattern { get; set; }
        public RegexOptions RegexOptions { get; set; }
        public override void Validate(ValidateInputContext context) {
            if (!Regex.IsMatch(context.AttemptedValue, Pattern, RegexOptions)) {
                var message = GetValidationMessage(context);
                context.ModelState.AddModelError(context.FieldName, message.Text);
            }
        public override void RegisterClientAttributes(RegisterClientValidationAttributesContext context) {
            context.ClientAttributes["data-val-regex"] = GetValidationMessage(context).Text;
            context.ClientAttributes["data-val-regex-pattern"] = Pattern;

            return String.IsNullOrWhiteSpace(ErrorMessage)
                ? T("{0} must match the following pattern: {1}.", context.FieldName, Pattern)
                : T(ErrorMessage);
    }
}

        private LocalizedString GetValidationMessage(ValidationContext context) {

