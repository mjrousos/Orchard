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
    public class AccountValidationContext {
        public AccountValidationContext() {
            ValidationErrors = new Dictionary<string, LocalizedString>();
        }
        // Results
        public IDictionary<string, LocalizedString> ValidationErrors { get; set; }
        public bool ValidationSuccessful { get { return !ValidationErrors.Any(); } }
        // Things to validate
        public string UserName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        // Additional useful information
        public IUser User { get; set; }
    }
}
