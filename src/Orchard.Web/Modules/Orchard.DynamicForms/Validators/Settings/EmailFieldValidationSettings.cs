using Orchard.ContentManagement;
using Orchard.Security;
using Orchard.UI.Admin;
using Orchard.DisplayManagement;
using Orchard.Localization;
using Orchard.Services;
using System.Web.Mvc;
using Orchard.Mvc.Filters;
using Orchard.DynamicForms.Services.Models;

namespace Orchard.DynamicForms.Validators.Settings {
    public class EmailFieldValidationSettings : ValidationSettingsBase {
        public bool? IsRequired { get; set; }
        public int? MaximumLength { get; set; }
        public string CompareWith { get; set; }
    }
}
