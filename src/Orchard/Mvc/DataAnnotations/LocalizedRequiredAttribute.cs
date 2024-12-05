using Orchard.ContentManagement;
using Orchard.Security;
using Orchard.UI.Admin;
using Orchard.DisplayManagement;
using Orchard.Localization;
using Orchard.Services;
using System.Web.Mvc;
using Orchard.Mvc.Filters;
﻿using System;
using System.ComponentModel.DataAnnotations;

namespace Orchard.Mvc.DataAnnotations {
    public class LocalizedRequiredAttribute : RequiredAttribute {
        public LocalizedRequiredAttribute(RequiredAttribute attribute, Localizer t) {
            AllowEmptyStrings = attribute.AllowEmptyStrings;
            if ( !String.IsNullOrEmpty(attribute.ErrorMessage) )
                ErrorMessage = attribute.ErrorMessage;
            T = t;
        }
        public Localizer T { get; set; }
        public override string FormatErrorMessage(string name) {
            return String.IsNullOrEmpty(ErrorMessage)
                ? T("The {0} field is required.", name).Text
                : T(ErrorMessage, name).Text;
    }
}
