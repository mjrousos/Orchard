using Orchard.ContentManagement;
using Orchard.Security;
using Orchard.UI.Admin;
using Orchard.DisplayManagement;
using Orchard.Localization;
using Orchard.Services;
using System.Web.Mvc;
using Orchard.Mvc.Filters;
using System.Collections.Generic;
using Orchard.DynamicForms.Services.Models;

namespace Orchard.DynamicForms.ViewModels {
    public class FieldValidationSettings {
        public FieldValidationSettings() {
            Validators = new List<FieldValidatorSetting>();
        }
        public IList<FieldValidatorSetting> Validators { get; set; }
        public bool ShowValidationMessage { get; set; }
    }
}
