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
    public interface IAccountValidationService : IDependency {
        /// <summary>
        /// Verifies whether the string is a valid password.
        /// </summary>
        /// <param name="context">The object describing the context of the validation.</param>
        /// <returns>true if the context contains a valid password, false otherwise.</returns>
        bool ValidatePassword(AccountValidationContext context);
        /// Verifies whether the string is a valid UserName.
        /// <returns>true if the context contains a valid UserName, false otherwise.</returns>
        bool ValidateUserName(AccountValidationContext context);
        /// Verifies whether the string is a valid email.
        bool ValidateEmail(AccountValidationContext context);
        
    }
}
