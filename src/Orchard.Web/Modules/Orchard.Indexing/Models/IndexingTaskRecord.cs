using Orchard.ContentManagement;
using Orchard.Security;
using Orchard.UI.Admin;
using Orchard.DisplayManagement;
using Orchard.Localization;
using Orchard.Services;
using System.Web.Mvc;
using Orchard.Mvc.Filters;
﻿using System;
using Orchard.ContentManagement.Records;

namespace Orchard.Indexing.Models {
    public class IndexingTaskRecord {
        public const int Update = 0;
        public const int Delete = 1;
        public virtual int Id { get; set; }
        public virtual int Action { get; set; }
        public virtual DateTime? CreatedUtc { get; set; }
        public virtual ContentItemRecord ContentItemRecord { get; set; }
    }
}
