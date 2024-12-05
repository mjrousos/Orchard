using Orchard.ContentManagement;
using Orchard.Security;
using Orchard.UI.Admin;
using Orchard.DisplayManagement;
using Orchard.Localization;
using Orchard.Services;
using System.Web.Mvc;
using Orchard.Mvc.Filters;
﻿using System;

namespace Orchard.Tokens.Providers {
    public class ShapeTokens : Component, ITokenProvider {
        private readonly IShapeDisplay _shapeDisplay;
        private readonly IShapeFactory _shapeFactory;
        public ShapeTokens(IShapeDisplay shapeDisplay, IShapeFactory shapeFactory) {
            _shapeDisplay = shapeDisplay;
            _shapeFactory = shapeFactory;
        }
        public void Describe(DescribeContext context) {
            context.For("Shape", T("Shape"), T("Shape tokens."))
                .Token("Execute:*", T("Execute:<shape name>"), T("Executes the specified shape."));
        public void Evaluate(EvaluateContext context) {
            context.For("Shape", "")
                .Token(t => t.StartsWith("Execute:", StringComparison.OrdinalIgnoreCase) ? t.Substring("Execute:".Length) : null, (shapeName, data) => TokenValue(context, shapeName, data));
        private object TokenValue(EvaluateContext context, string shapeName, string data) {
            var parameters = Arguments.From(context.Data.Values, context.Data.Keys);
            var shape = _shapeFactory.Create(shapeName, parameters);
            return _shapeDisplay.Display(shape);
    }
}
