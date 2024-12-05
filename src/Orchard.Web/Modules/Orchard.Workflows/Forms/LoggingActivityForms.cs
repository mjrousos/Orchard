using Orchard.ContentManagement;
using Orchard.Security;
using Orchard.UI.Admin;
using Orchard.DisplayManagement;
using Orchard.Localization;
using Orchard.Services;
using System.Web.Mvc;
using Orchard.Mvc.Filters;
﻿using System.Web.Mvc;
using Orchard.Forms.Services;

namespace Orchard.Workflows.Forms {
    public class LoggingActivityForms : IFormProvider {
        protected dynamic Shape { get; set; }
        public Localizer T { get; set; }
        public LoggingActivityForms(IShapeFactory shapeFactory) {
            Shape = shapeFactory;
            T = NullLocalizer.Instance;
        }
        public void Describe(DescribeContext context) {
            context.Form("ActivityLog",
                shape => Shape.Form(
                    Id: "ActivityLog",
                    _Type: Shape.SelectList(
                        Id: "level", Name: "Level",
                        Title: T("Log entry level"),
                        Description: T("Select what type of notification should be displayed."))
                        .Add(new SelectListItem {Value = "Debug", Text = T("Debug").Text})
                        .Add(new SelectListItem {Value = "Information", Text = T("Information").Text})
                        .Add(new SelectListItem {Value = "Warning", Text = T("Warning").Text})
                        .Add(new SelectListItem {Value = "Error", Text = T("Error").Text})
                        .Add(new SelectListItem {Value = "Fatal", Text = T("Fatal").Text}),
                    _Message: Shape.TextArea(
                        Id: "message", Name: "Message",
                        Title: T("Message"),
                        Description: T("The message to log."),
                        Classes: new[] {"text medium", "tokenized"})
                    )
                );
    }
}
