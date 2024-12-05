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

namespace Orchard.ContentManagement {
    public class IdentityResolverSelectorResult {
        public int Priority { get; set; }
        public Func<ContentIdentity, IEnumerable<ContentItem>> Resolve { get; set; }
    }
    public interface IIdentityResolverSelector : IDependency {
        IdentityResolverSelectorResult GetResolver(ContentIdentity contentIdentity);
}
