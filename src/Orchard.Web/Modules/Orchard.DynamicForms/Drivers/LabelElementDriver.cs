using Orchard.ContentManagement;
using Orchard.Security;
using Orchard.UI.Admin;
using Orchard.DisplayManagement;
using Orchard.Localization;
using Orchard.Services;
using System.Web.Mvc;
using Orchard.Mvc.Filters;
﻿using System.Collections.Generic;
using Orchard.DynamicForms.Elements;
using Orchard.Layouts.Framework.Display;
using Orchard.Layouts.Framework.Drivers;
using Orchard.Layouts.Helpers;
using Orchard.Layouts.Services;
using Orchard.Tokens;
using DescribeContext = Orchard.Forms.Services.DescribeContext;

namespace Orchard.DynamicForms.Drivers {
    public class LabelElementDriver : FormsElementDriver<Label> {
        private readonly ITokenizer _tokenizer;
        public LabelElementDriver(IFormsBasedElementServices formsServices, ITokenizer tokenizer) : base(formsServices) {
            _tokenizer = tokenizer;
        }
        protected override IEnumerable<string> FormNames {
            get { yield return "Label"; }
        protected override void DescribeForm(DescribeContext context) {
            context.Form("Label", factory => {
                var shape = (dynamic)factory;
                var form = shape.Fieldset(
                    Id: "Label",
                    _LabelText: shape.Textbox(
                        Id: "LabelText",
                        Name: "LabelText",
                        Title: "Text",
                        Classes: new[] { "text", "large", "tokenized" },
                        Description: T("The label text.")),
                    _LabelFor: shape.Textbox(
                        Id: "LabelFor",
                        Name: "LabelFor",
                        Title: "For",
                        Description: T("The name of the field this label is for.")));
                return form;
            });
        protected override void OnDisplaying(Label element, ElementDisplayingContext context) {
            context.ElementShape.ProcessedText = _tokenizer.Replace(element.Text, context.GetTokenData(), new ReplaceOptions { Encoding = ReplaceOptions.NoEncode });
            context.ElementShape.ProcessedFor = _tokenizer.Replace(element.For, context.GetTokenData());
    }
}
