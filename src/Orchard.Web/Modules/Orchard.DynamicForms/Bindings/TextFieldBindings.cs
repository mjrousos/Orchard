using Orchard.ContentManagement;
using Orchard.Security;
using Orchard.UI.Admin;
using Orchard.DisplayManagement;
using Orchard.Localization;
using Orchard.Services;
using System.Web.Mvc;
using Orchard.Mvc.Filters;
using Orchard.Core.Common.Fields;
using Orchard.DynamicForms.Services;
using Orchard.DynamicForms.Services.Models;

namespace Orchard.DynamicForms.Bindings {
    public class TextFieldBindings : Component, IBindingProvider {
        public void Describe(BindingDescribeContext context) {
            context.For<TextField>()
                .Binding("Text", (contentItem, field, s) => field.Value = s);
        }
    }
}
