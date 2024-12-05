using Orchard.ContentManagement;
using Orchard.Security;
using Orchard.UI.Admin;
using Orchard.DisplayManagement;
using Orchard.Localization;
using Orchard.Services;
using System.Web.Mvc;
using Orchard.Mvc.Filters;
﻿using Orchard.Environment.Extensions;
using Orchard.Forms.Services;

namespace Orchard.DynamicForms.Forms {
    [OrchardFeature("Orchard.DynamicForms.Activities.Validation")]
    public class DynamicFormValidatingForm : Component, IFormProvider {
        public void Describe(DescribeContext context) {
            context.Form("DynamicFormValidatingScript", shapeFactory => {
                var shape = (dynamic) shapeFactory;
                var form = shape.Form(
                    Id: "DynamicFormValidatingScript",
                    _Script: shape.TextArea(
                        Id: "Script",
                        Name: "Script",
                        Title: T("Script"),
                        Description: T("The script to validate the submitted form. You can use ContentItem, Services, WorkContext, Workflow and T(). Call AddModelError(string key, LocalizedString errorMessage) to add modelstate errors."),
                        Classes: new[] {"tokenized"}));
                return form;
            });
        }
    }
}
