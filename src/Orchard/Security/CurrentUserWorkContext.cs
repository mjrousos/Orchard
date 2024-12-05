using Orchard.ContentManagement;
using Orchard.Security;
using Orchard.UI.Admin;
using Orchard.DisplayManagement;
using Orchard.Localization;
using Orchard.Services;
using System.Web.Mvc;
using Orchard.Mvc.Filters;
﻿using System;

namespace Orchard.Security {
    public class CurrentUserWorkContext : IWorkContextStateProvider {
        private readonly IAuthenticationService _authenticationService;
        public CurrentUserWorkContext(IAuthenticationService authenticationService) {
            _authenticationService = authenticationService;
        }
        public Func<WorkContext, T> Get<T>(string name) {
            if (name == "CurrentUser") 
                return ctx => (T)_authenticationService.GetAuthenticatedUser();
            return null;
    }
}
