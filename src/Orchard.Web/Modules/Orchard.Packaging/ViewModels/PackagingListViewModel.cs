using Orchard.ContentManagement;
using Orchard.Security;
using Orchard.UI.Admin;
using Orchard.DisplayManagement;
using Orchard.Localization;
using Orchard.Services;
using System.Web.Mvc;
using Orchard.Mvc.Filters;
using System;
using System.Collections.Generic;
using Orchard.Packaging.Models;

namespace Orchard.Packaging.ViewModels {
    public class PackagingListViewModel {
        public DateTime? LastUpdateCheckUtc { get; set; }
        public IEnumerable<UpdatePackageEntry> Entries { get; set; }
        public dynamic Pager { get; set; }
    }
}
