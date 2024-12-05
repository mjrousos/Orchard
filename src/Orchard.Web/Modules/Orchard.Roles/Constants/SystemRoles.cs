using Orchard.ContentManagement;
using Orchard.Security;
using Orchard.UI.Admin;
using Orchard.DisplayManagement;
using Orchard.Localization;
using Orchard.Services;
using System.Web.Mvc;
using Orchard.Mvc.Filters;
﻿using System.Collections.Generic;

namespace Orchard.Roles.Constants {
    public static class SystemRoles {
        public const string Anonymous = nameof(Anonymous);
        public const string Authenticated = nameof(Authenticated);
        public static IEnumerable<string> GetSystemRoles() {
            return new List<string> { Anonymous, Authenticated };
        }
    }
}
