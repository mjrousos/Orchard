using Orchard.ContentManagement;
using Orchard.Security;
using Orchard.UI.Admin;
using Orchard.DisplayManagement;
using Orchard.Localization;
using Orchard.Services;
using System.Web.Mvc;
using Orchard.Mvc.Filters;
using System.Collections.Generic;

namespace Orchard.DynamicForms.Services.Models {
    public class RegisterClientValidationAttributesContext : ValidationContext {
        public RegisterClientValidationAttributesContext() {
            ClientAttributes = new Dictionary<string, string>();
        }
        public IDictionary<string, string> ClientAttributes { get; set; }
    }
}
