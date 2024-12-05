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

namespace Orchard.Projections.FilterEditors.Forms {
    public class BooleanFilterForm : IFormProvider {
        public const string FormName = "BooleanFilter";
        protected dynamic Shape { get; set; }
        public Localizer T { get; set; }
        public BooleanFilterForm(IShapeFactory shapeFactory) {
            Shape = shapeFactory;
            T = NullLocalizer.Instance;
        }
        public void Describe(DescribeContext context) {
            Func<IShapeFactory, object> form =
                shape => {
                    var f = Shape.Form(
                        Id: "BooleanFilter",
                        _Options: Shape.Fieldset(
                            _ValueUndefined: Shape.Radio(
                                Id: "value-undefined", Name: "Value",
                                Title: T("Undefined"), Value: "undefined"
                                ),
                            _ValueTrue: Shape.Radio(
                                Id: "value-true", Name: "Value",
                                Title: T("Yes"), Value: "true", Checked: true
                            _ValueFalse: Shape.Radio(
                                Id: "value-false", Name: "Value",
                                Title: T("No"), Value: "false"
                            Description: T("Enter the value the string should be.")
                        ));
                    return f;
                };
            context.Form(FormName, form);
        public static LocalizedString DisplayFilter(string fieldName, dynamic formState, Localizer T) {
            
            if(formState.Value == "undefined") {
                return T("{0} is undefined", fieldName);
            }
            bool value = Convert.ToBoolean(formState.Value);
            return value
                       ? T("{0} is true", fieldName)
                       : T("{0} is false", fieldName);
        public static Action<IHqlExpressionFactory> GetFilterPredicate(dynamic formState, string property) {
            if (formState.Value == "undefined") {
                return x => x.IsNull(property);
            if (value) {
                return x => x.Gt(property, (long)0);
            return x => x.Eq(property, (long)0);
    }
}
