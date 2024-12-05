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
    public class EnumerationValidationSettings : ValidationSettingsBase {
        public bool? Required { get; set; }
    }
}


