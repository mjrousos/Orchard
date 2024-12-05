using Orchard.ContentManagement;
using Orchard.Security;
using Orchard.UI.Admin;
using Orchard.DisplayManagement;
using Orchard.Localization;
using Orchard.Services;
using System.Web.Mvc;
using Orchard.Mvc.Filters;
using System;
using System.ComponentModel.DataAnnotations;

namespace Orchard.Setup.Annotations {
    public class StringLengthMin : ValidationAttribute {
        private readonly int _minimumLength;
        public StringLengthMin(int minimumLength) {
            _minimumLength = minimumLength;
            if (minimumLength <= 1)
                throw new ArgumentException("Value must be greater than or equal to 2", "minimumLength");
        }
        public override bool IsValid(object value) {
            return !(value is string) || (value as string).Length >= _minimumLength;
    }
}
