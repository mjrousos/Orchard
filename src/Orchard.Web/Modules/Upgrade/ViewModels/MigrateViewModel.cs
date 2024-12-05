using Orchard.ContentManagement;
using Orchard.Security;
using Orchard.UI.Admin;
using Orchard.DisplayManagement;
using Orchard.Localization;
using Orchard.Services;
using System.Web.Mvc;
using Orchard.Mvc.Filters;
﻿using System.Collections.Generic;

namespace Upgrade.ViewModels {
    public class MigrateViewModel {
        public IList<ContentTypeEntry> ContentTypes { get; set; }
    }
    public class ContentTypeEntry {
        public string ContentTypeName { get; set; }
        public bool IsChecked { get; set; }
}
