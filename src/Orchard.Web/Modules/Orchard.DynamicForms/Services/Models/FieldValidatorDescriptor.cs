using Orchard.ContentManagement;
using Orchard.Security;
using Orchard.UI.Admin;
using Orchard.DisplayManagement;
using Orchard.Localization;
using Orchard.Services;
using System.Web.Mvc;
using Orchard.Mvc.Filters;
﻿namespace Orchard.DynamicForms.Services.Models {
    public class FieldValidatorSetting {
        public string Name { get; set; }
        public bool Enabled { get; set; }
        public string CustomValidationMessage { get; set; }
    }
}
