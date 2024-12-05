using Orchard.ContentManagement;
using Orchard.Security;
using Orchard.UI.Admin;
using Orchard.DisplayManagement;
using Orchard.Localization;
using Orchard.Services;
using System.Web.Mvc;
using Orchard.Mvc.Filters;
﻿using Orchard.Forms.Services;

namespace Orchard.DynamicForms.Forms {
    public class AddModelErrorForm : Component, IFormProvider {
    
        public void Describe(DescribeContext context) {
            context.Form("AddModelError", factory => {
                var shape = (dynamic)factory;
                var form = shape.Form(
                    Id: "AddModelError",
                    _Key: shape.Textbox(
                        Id: "key",
                        Name: "Key",
                        Title: "Key",
                        Classes: new[] { "text", "large", "tokenized" },
                        Description: T("The key / form field name for which to add a model validation error.")),
                    _Message: shape.Textbox(
                        Id: "errorMessage",
                        Name: "ErrorMessage",
                        Title: "Error Message",
                        Description: T("The model validation error message to add.")));
                return form;
            });
        }
    }
}
