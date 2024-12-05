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
    public abstract class DescribeFor {
        public abstract IEnumerable<TokenDescriptor> Tokens { get; }
        public abstract LocalizedString Name { get; }
        public abstract LocalizedString Description { get; }
        public abstract DescribeFor Token(string token, LocalizedString name, LocalizedString description);
        public abstract DescribeFor Token(string token, LocalizedString name, LocalizedString description, string chainTarget);
    }
}
