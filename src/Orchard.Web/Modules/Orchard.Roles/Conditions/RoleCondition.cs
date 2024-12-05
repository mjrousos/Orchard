using Orchard.ContentManagement;
using Orchard.Security;
using Orchard.UI.Admin;
using Orchard.DisplayManagement;
using Orchard.Localization;
using Orchard.Services;
using System.Web.Mvc;
using Orchard.Mvc.Filters;
﻿using System;
using System.Linq;
using Orchard.Events;
using Orchard.Roles.Models;

namespace Orchard.Roles.Conditions {
    public interface IConditionProvider : IEventHandler {
        void Evaluate(dynamic evaluationContext);
    }
    public class RoleConditionProvider : IConditionProvider {
        private readonly IAuthenticationService _authenticationService;
        public RoleConditionProvider(IAuthenticationService authenticationService) {
            _authenticationService = authenticationService;
        }
        public void Evaluate(dynamic evaluationContext) {
            if (!string.Equals(evaluationContext.FunctionName, "role", StringComparison.OrdinalIgnoreCase)) {
                return;
            }
            var user = _authenticationService.GetAuthenticatedUser();
            var roles = ((object[])evaluationContext.Arguments).Cast<string>();
            evaluationContext.Result = user.UserIsInRole(roles);
}
