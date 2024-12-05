using Orchard.ContentManagement;
using Orchard.Security;
using Orchard.UI.Admin;
using Orchard.DisplayManagement;
using Orchard.Localization;
using Orchard.Services;
using System.Web.Mvc;
using Orchard.Mvc.Filters;
﻿using System;
using Orchard.Forms.Services;

namespace Orchard.Projections.Providers.Layouts {
    public class ShapeLayoutForms : IFormProvider {
        protected dynamic Shape { get; set; }
        public Localizer T { get; set; }
        public ShapeLayoutForms(
            IShapeFactory shapeFactory) {
            Shape = shapeFactory;
            T = NullLocalizer.Instance;
        }
        public void Describe(DescribeContext context) {
            Func<IShapeFactory, object> form =
                shape => {
                    var f = Shape.Form(
                        Id: "ShapeLayout",
                        _Options: Shape.Fieldset(
                            Title: T("Shape options"),
                            _ShapeType: Shape.TextBox(
                                Id: "shape-type", Name: "ShapeType",
                                Title: T("Shape type"),
                                Description: T("The type of the shape which is used for rendering content items."),
                                Classes: new[] { "text medium", "tokenized" }
                                )
                            )
                        );
                    return f;
                };
            context.Form("ShapeLayout", form);
    }
}
