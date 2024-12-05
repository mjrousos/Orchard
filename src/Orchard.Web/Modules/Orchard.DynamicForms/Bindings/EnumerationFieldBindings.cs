using Orchard.ContentManagement;
using Orchard.Security;
using Orchard.UI.Admin;
using Orchard.DisplayManagement;
using Orchard.Localization;
using Orchard.Services;
using System.Web.Mvc;
using Orchard.Mvc.Filters;
using System;
using Orchard.DynamicForms.Services;
using Orchard.DynamicForms.Services.Models;
using Orchard.Fields.Fields;

namespace Orchard.DynamicForms.Bindings {
    public class EnumerationFieldBindings : Component, IBindingProvider {
        public void Describe(BindingDescribeContext context) {
            context.For<EnumerationField>()
                .Binding("SelectedValues", (contentItem, field, s) => {
                    if (String.IsNullOrWhiteSpace(s)) {
                        field.Value = "";
                        return;
                    }
                    var separators = new[] {',', ';'};
                    var hasMultipleValues = s.IndexOfAny(separators) >= 0;
                    if (hasMultipleValues)
                        field.SelectedValues = s.Split(separators, StringSplitOptions.RemoveEmptyEntries);
                    else {
                        field.Value = s;
                });
        }
    }
}
