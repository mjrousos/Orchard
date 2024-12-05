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
    public class TokenDescriptor {
        public string Target { get; set; }
        public string Token { get; set; }
        public string ChainTarget { get; set; }
        public LocalizedString Name { get; set; }
        public LocalizedString Description { get; set; }
    }
    public class TokenTypeDescriptor {
        public IEnumerable<TokenDescriptor> Tokens { get; set; }
}
