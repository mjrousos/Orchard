using Orchard.ContentManagement;
using Orchard.Security;
using Orchard.UI.Admin;
using Orchard.DisplayManagement;
using Orchard.Localization;
using Orchard.Services;
using System.Web.Mvc;
using Orchard.Mvc.Filters;
﻿using Orchard.Forms.Services;
using DescribeContext = Orchard.Forms.Services.DescribeContext;

namespace Orchard.DynamicForms.Forms {
    public class PlaceholderForm : Component, IFormProvider {
        public void Describe(DescribeContext context) {
            context.Form("Placeholder", factory => {
                var shape = (dynamic)factory;
                var form = shape.Fieldset(
                    Id: "Placeholder",
                    _Placeholder: shape.Textbox(
                        Id: "Placeholder",
                        Name: "Placeholder",
                        Title: "Placeholder",
                        Classes: new[] { "text", "large", "tokenized" },
                        Description: T("The text to render as placeholder.")));
                return form;
            });
        }
    }
}
