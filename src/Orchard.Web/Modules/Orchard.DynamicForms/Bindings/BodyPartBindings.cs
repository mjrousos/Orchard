using Orchard.ContentManagement;
using Orchard.Security;
using Orchard.UI.Admin;
using Orchard.DisplayManagement;
using Orchard.Localization;
using Orchard.Services;
using System.Web.Mvc;
using Orchard.Mvc.Filters;
using Orchard.Core.Common.Models;
using Orchard.DynamicForms.Services;
using Orchard.DynamicForms.Services.Models;

namespace Orchard.DynamicForms.Bindings {
    public class BodyPartBindings : Component, IBindingProvider {
        public void Describe(BindingDescribeContext context) {
            context.For<BodyPart>()
                .Binding("Text", (contentItem, part, s) => part.Text = s);
        }
    }
}
