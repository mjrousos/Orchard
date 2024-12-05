using Orchard.ContentManagement;
using Orchard.Security;
using Orchard.UI.Admin;
using Orchard.DisplayManagement;
using Orchard.Localization;
using Orchard.Services;
using System.Web.Mvc;
using Orchard.Mvc.Filters;
﻿using System.Collections.Generic;
using Orchard.ContentManagement.Records;

namespace Orchard.Tags.Models {
    public class TagsPartRecord : ContentPartRecord {
        public TagsPartRecord() {
            Tags = new List<ContentTagRecord>();
        }
        public virtual IList<ContentTagRecord> Tags { get; set; }
    }
}
