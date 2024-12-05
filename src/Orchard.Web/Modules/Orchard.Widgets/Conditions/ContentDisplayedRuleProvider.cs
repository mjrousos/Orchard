using Orchard.ContentManagement;
using Orchard.Security;
using Orchard.UI.Admin;
using Orchard.DisplayManagement;
using Orchard.Localization;
using Orchard.Services;
using System.Web.Mvc;
using Orchard.Mvc.Filters;
﻿using System;
using Orchard.Conditions.Services;
using Orchard.Widgets.Handlers;

namespace Orchard.Widgets.Conditions {
    public class ContentDisplayedRuleProvider : IConditionProvider {
        private readonly IDisplayedContentItemHandler _displayedContentItemHandler;
        public ContentDisplayedRuleProvider(IDisplayedContentItemHandler displayedContentItemHandler) {
            _displayedContentItemHandler = displayedContentItemHandler;
        }
        public void Evaluate(ConditionEvaluationContext evaluationContext) {
            if (!String.Equals(evaluationContext.FunctionName, "contenttype", StringComparison.OrdinalIgnoreCase)) {
                return;
            }
            var contentType = Convert.ToString(evaluationContext.Arguments[0]);
            evaluationContext.Result = _displayedContentItemHandler.IsDisplayed(contentType);
    }
}
