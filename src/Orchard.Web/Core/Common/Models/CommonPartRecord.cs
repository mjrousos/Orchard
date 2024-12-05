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

namespace Orchard.Core.Common.Models {
    public class CommonPartRecord : ContentPartRecord {
        public virtual int OwnerId { get; set; }
        public virtual ContentItemRecord Container { get; set; }
        public virtual DateTime? CreatedUtc { get; set; }
        public virtual DateTime? PublishedUtc { get; set; }
        public virtual DateTime? ModifiedUtc { get; set; }
    }
}
