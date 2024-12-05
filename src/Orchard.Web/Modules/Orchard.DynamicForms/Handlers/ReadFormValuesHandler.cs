using Orchard.ContentManagement;
using Orchard.Security;
using Orchard.UI.Admin;
using Orchard.DisplayManagement;
using Orchard.Localization;
using Orchard.Services;
using System.Web.Mvc;
using Orchard.Mvc.Filters;
using System;
using Orchard.DynamicForms.Elements;
using Orchard.DynamicForms.Services;

namespace Orchard.DynamicForms.Handlers {
    public class ReadFormValuesHandler : FormElementEventHandlerBase {
        public override void GetElementValue(FormElement element, ReadElementValuesContext context) {
            if (String.IsNullOrWhiteSpace(element.Name))
                return;
            var key = element.Name;
            var valueProviderResult = context.ValueProvider.GetValue(key);
            if (String.IsNullOrWhiteSpace(key) || valueProviderResult == null)
            var items = valueProviderResult.RawValue as string[];
            if (items == null)
            var combinedValues = String.Join(",", items);
            context.Output[key] = combinedValues;
            element.RuntimeValue = combinedValues;
            element.PostedValue = combinedValues;
        }
    }
}
