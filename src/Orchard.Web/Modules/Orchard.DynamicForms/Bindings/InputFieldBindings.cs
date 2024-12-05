using Orchard.ContentManagement;
using Orchard.Security;
using Orchard.UI.Admin;
using Orchard.DisplayManagement;
using Orchard.Localization;
using Orchard.Services;
using System.Web.Mvc;
using Orchard.Mvc.Filters;
using Orchard.DynamicForms.Services;
using Orchard.DynamicForms.Services.Models;
using Orchard.Fields.Fields;

namespace Orchard.DynamicForms.Bindings {
    public class InputFieldBindings : Component, IBindingProvider {
        public void Describe(BindingDescribeContext context) {
            context.For<InputField>()
                .Binding("Text", (contentItem, field, s) => field.Value = s);
        }
    }
}
