using Orchard.ContentManagement;
using Orchard.Security;
using Orchard.UI.Admin;
using Orchard.DisplayManagement;
using Orchard.Localization;
using Orchard.Services;
using System.Web.Mvc;
using Orchard.Mvc.Filters;
﻿using Orchard.DynamicForms.Services;
using Orchard.DynamicForms.Services.Models;

namespace Orchard.DynamicForms.Handlers {
    public class ValidatorsCoordinator : FormEventHandlerBase {
        public override void Validating(FormValidatingEventContext context) {
            var form = context.Form;
            var values = context.Values;
            var formService = context.FormService;
            var formElements = formService.GetFormElements(form);
            var modelState = context.ModelState;
            // Get the validators for each element and validate its submitted values.
            foreach (var element in formElements) {
                var validators = formService.GetValidators(element);
                var attemptedValue = values[element.Name];
                foreach (var validator in validators) {
                    var validateContext = new ValidateInputContext {
                        ModelState = modelState,
                        AttemptedValue = attemptedValue,
                        FieldName = element.Name,
                        Values = values,
                        Updater = context.Updater
                    };
                    validator.Validate(element, validateContext);
                }
            }
        }
    }
}
