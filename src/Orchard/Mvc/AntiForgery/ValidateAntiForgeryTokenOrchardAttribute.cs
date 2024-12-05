using Orchard.ContentManagement;
using Orchard.Security;
using Orchard.UI.Admin;
using Orchard.DisplayManagement;
using Orchard.Localization;
using Orchard.Services;
using System.Web.Mvc;
using Orchard.Mvc.Filters;
using System;

namespace Orchard.Mvc.AntiForgery {
    [AttributeUsage(AttributeTargets.Method)]
    public class ValidateAntiForgeryTokenOrchardAttribute : FilterAttribute {
        private readonly bool _enabled = true;
        public ValidateAntiForgeryTokenOrchardAttribute() : this(true) {}
        public ValidateAntiForgeryTokenOrchardAttribute(bool enabled) {
            _enabled = enabled;
        }
        public bool Enabled { get { return _enabled; } }
    }
}
