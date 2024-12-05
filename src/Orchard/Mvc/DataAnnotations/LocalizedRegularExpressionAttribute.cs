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
    public class LocalizedRegularExpressionAttribute : RegularExpressionAttribute {
        public LocalizedRegularExpressionAttribute(RegularExpressionAttribute attribute, Localizer t)
            : base(attribute.Pattern) {
            if ( !String.IsNullOrEmpty(attribute.ErrorMessage) )
                ErrorMessage = attribute.ErrorMessage;
            T = t;
        }
        public Localizer T { get; set; }
        public override string FormatErrorMessage(string name) {
            return String.IsNullOrEmpty(ErrorMessage)
                ? T("The field {0} must match the regular expression '{1}'.", name, Pattern).Text
                : T(ErrorMessage, name, Pattern).Text;
    }
}
