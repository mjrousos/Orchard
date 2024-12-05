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

namespace Orchard.Projections.Providers.SortCriteria {
    public class SortCriterionFormProvider : IFormProvider {
        public const string FormName = "SortOrder";
        protected dynamic Shape { get; set; }
        public Localizer T { get; set; }
        public SortCriterionFormProvider(IShapeFactory shapeFactory) {
            Shape = shapeFactory;
            T = NullLocalizer.Instance;
        }
        public void Describe(DescribeContext context) {
            Func<IShapeFactory, object> form =
                shape => {
                    var f = Shape.Form(
                        _Options: Shape.Fieldset(
                            _ValueTrue: Shape.Radio(
                                Id: "sortAscending", Name: "Sort",
                                Checked: true, // default value
                                Title: T("Sort ascending"), Value: "true"
                                ),
                            _ValueFalse: Shape.Radio(
                                Id: "sortDescending", Name: "Sort",
                                Title: T("Sort descending"), Value: "false"
                            Description: T("The direction the field will be sorted by.")
                        ));
                    return f;
                };
            context.Form(FormName, form);
    }
    public class SortCriterionFormValidator : FormHandler {
        public override void Validating(ValidatingContext context) {
            if (context.FormName == SortCriterionFormProvider.FormName) {
                if (context.ValueProvider.GetValue("Sort") == null) {
                    context.ModelState.AddModelError("Sort", T("The Sort field is required.").Text);
                }
            }
}
