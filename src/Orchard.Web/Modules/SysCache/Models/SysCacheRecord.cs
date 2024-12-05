using Orchard.ContentManagement;
using Orchard.Security;
using Orchard.UI.Admin;
using Orchard.DisplayManagement;
using Orchard.Localization;
using Orchard.Services;
using System.Web.Mvc;
using Orchard.Mvc.Filters;
﻿namespace SysCache.Models {
    /// <summary>
    /// Fake record in order to force the mappings to be updated
    /// once the modules is enabled/disabled
    /// </summary>
    public class SysCacheRecord {
        public virtual int Id { get; set; }
    }
}
