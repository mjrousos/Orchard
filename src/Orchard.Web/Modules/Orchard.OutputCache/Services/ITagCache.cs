using Orchard.ContentManagement;
using Orchard.Security;
using Orchard.UI.Admin;
using Orchard.DisplayManagement;
using Orchard.Localization;
using Orchard.Services;
using System.Web.Mvc;
using Orchard.Mvc.Filters;
﻿using System.Collections.Generic;

namespace Orchard.OutputCache.Services {
    public interface ITagCache : ISingletonDependency {
        void Tag(string tag, params string[] keys);
        IEnumerable<string> GetTaggedItems(string tag);
        void RemoveTag(string tag);
    }
}
