using Orchard.ContentManagement;
using Orchard.Security;
using Orchard.UI.Admin;
using Orchard.DisplayManagement;
using Orchard.Localization;
using Orchard.Services;
using System.Web.Mvc;
using Orchard.Mvc.Filters;
﻿using System.Collections.Generic;

namespace Orchard.Tokens {
    public interface ITokenManager : IDependency {
        IEnumerable<TokenTypeDescriptor> Describe(IEnumerable<string> targets);
        IDictionary<string, object> Evaluate(string target, IDictionary<string, string> tokens, IDictionary<string, object> data);
    }
}
