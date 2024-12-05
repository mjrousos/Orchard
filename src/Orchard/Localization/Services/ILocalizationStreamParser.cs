using Orchard.ContentManagement;
using Orchard.Security;
using Orchard.UI.Admin;
using Orchard.DisplayManagement;
using Orchard.Localization;
using Orchard.Services;
using System.Web.Mvc;
using Orchard.Mvc.Filters;
﻿using System.Collections.Generic;

namespace Orchard.Localization.Services {
    public interface ILocalizationStreamParser : IDependency {
        void ParseLocalizationStream(string text, IDictionary<string, string> translations, bool merge);
    }
}
