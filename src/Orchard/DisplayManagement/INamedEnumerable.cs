using Orchard.ContentManagement;
using Orchard.Security;
using Orchard.UI.Admin;
using Orchard.DisplayManagement;
using Orchard.Localization;
using Orchard.Services;
using System.Web.Mvc;
using Orchard.Mvc.Filters;
﻿using System.Collections.Generic;

namespace Orchard.DisplayManagement {
    public interface INamedEnumerable<T> : IEnumerable<T> {
        IEnumerable<T> Positional { get; }
        IDictionary<string, T> Named { get; }
    }
}
