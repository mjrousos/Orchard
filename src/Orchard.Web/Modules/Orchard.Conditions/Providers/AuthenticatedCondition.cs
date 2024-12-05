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

namespace Orchard.Conditions.Providers {
    public class AuthenticatedCondition : IConditionProvider {
        private readonly IAuthenticationService _authenticationService;
        public AuthenticatedCondition(IAuthenticationService authenticationService) {
            _authenticationService = authenticationService;
        }
        public void Evaluate(ConditionEvaluationContext evaluationContext) { 
            if (!String.Equals(evaluationContext.FunctionName, "authenticated", StringComparison.OrdinalIgnoreCase)) {
                return;
            }
            if (_authenticationService.GetAuthenticatedUser() != null) {
                evaluationContext.Result = true;
            evaluationContext.Result = false;
    }
}
