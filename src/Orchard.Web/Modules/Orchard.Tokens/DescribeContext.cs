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
    public abstract class DescribeContext {
        public abstract IEnumerable<TokenTypeDescriptor> Describe(params string[] targets);
        public abstract DescribeFor For(string target);
        public abstract DescribeFor For(string target, LocalizedString name, LocalizedString description);
    }
}
