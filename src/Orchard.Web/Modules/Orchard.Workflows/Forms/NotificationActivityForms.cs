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
    public class NotificationActivityForms : IFormProvider {
        protected dynamic Shape { get; set; }
        public Localizer T { get; set; }
        public NotificationActivityForms(IShapeFactory shapeFactory) {
            Shape = shapeFactory;
            T = NullLocalizer.Instance;
        }
        public void Describe(DescribeContext context) {
            context.Form("ActivityNotify",
                shape => Shape.Form(
                Id: "ActivityNotify",
                _Type: Shape.SelectList(
                    Id: "notification", Name: "Notification",
                    Title: T("Notification type"),
                    Description: T("Select what type of notification should be displayed."))
                    .Add(new SelectListItem { Value = "Information", Text = T("Information").Text })
                    .Add(new SelectListItem { Value = "Warning", Text = T("Warning").Text })
                    .Add(new SelectListItem { Value = "Error", Text = T("Error").Text }),
                _Message: Shape.Textbox(
                    Id: "message", Name: "Message",
                    Title: T("Message"),
                    Description: T("The notification message to display."),
                    Classes: new[] { "text medium", "tokenized" })
                )
            );
    }
}
