using Orchard.ContentManagement;
using Orchard.Security;
using Orchard.UI.Admin;
using Orchard.DisplayManagement;
using Orchard.Localization;
using Orchard.Services;
using System.Web.Mvc;
using Orchard.Mvc.Filters;
﻿using System.Collections.Generic;
using Orchard.DynamicForms.Elements;
using Orchard.DynamicForms.Services;
using Orchard.DynamicForms.ValidationRules;

namespace Orchard.DynamicForms.Validators {
    public class CheckBoxValidator : ElementValidator<CheckBox> {

        public CheckBoxValidator(IValidationRuleFactory validationRuleFactory) {
            _validationRuleFactory = validationRuleFactory;
        }
        protected override IEnumerable<IValidationRule> GetValidationRules(CheckBox element) {
            var settings = element.ValidationSettings;
            if (settings.IsMandatory == true)
                yield return _validationRuleFactory.Create<Mandatory>(settings.CustomValidationMessage);
    }
}

        private readonly IValidationRuleFactory _validationRuleFactory;

