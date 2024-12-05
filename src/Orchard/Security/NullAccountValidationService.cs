using Orchard.ContentManagement;
using Orchard.Security;
using Orchard.UI.Admin;
using Orchard.DisplayManagement;
using Orchard.Localization;
using Orchard.Services;
using System.Web.Mvc;
using Orchard.Mvc.Filters;
﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Orchard.Security {
    /// <summary>
    /// Provides a default implementation of <c>IAccountValidationService</c> used only for dependency resolution
    /// in a setup context. No members on this implementation will ever be called; at the time when this
    /// interface is actually used in a tenant, another implementation is assumed to have suppressed it.
    /// </summary>
    public class NullAccountValidationService : IAccountValidationService {
        public bool ValidateEmail(AccountValidationContext context) {
            throw new NotImplementedException();
        }
        public bool ValidatePassword(AccountValidationContext context) {
        public bool ValidateUserName(AccountValidationContext context) {
    }
}
