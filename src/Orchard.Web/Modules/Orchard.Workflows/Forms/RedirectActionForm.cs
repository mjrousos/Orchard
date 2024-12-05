using Orchard.ContentManagement;
using Orchard.Security;
using Orchard.UI.Admin;
using Orchard.DisplayManagement;
using Orchard.Localization;
using Orchard.Services;
using System.Web.Mvc;
using Orchard.Mvc.Filters;
﻿using Orchard.DisplayManagement;
using Orchard.Forms.Services;

namespace Orchard.Workflows.Forms {
    public class RedirectActionForm : IFormProvider {
        protected dynamic New { get; set; }
        public Localizer T { get; set; }
        public RedirectActionForm(IShapeFactory shapeFactory) {
            New = shapeFactory;
            T = NullLocalizer.Instance;
        }
        public void Describe(DescribeContext context) {
            context.Form("ActionRedirect",
                shape => New.Form(
                Id: "ActionRedirect",
                _Url: New.Textbox(
                    Id: "Url", Name: "Url",
                    Title: T("Url"),
                    Description: T("The url to redirect to."),
                    Classes: new[] { "text large", "tokenized" })
                )
            );
    }
}
