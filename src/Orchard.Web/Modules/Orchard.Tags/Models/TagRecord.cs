using Orchard.ContentManagement;
using Orchard.Security;
using Orchard.UI.Admin;
using Orchard.DisplayManagement;
using Orchard.Localization;
using Orchard.Services;
using System.Web.Mvc;
using Orchard.Mvc.Filters;
﻿using System.Collections.Generic;

namespace Orchard.Tags.Models {
    public class TagRecord {
        public TagRecord() {
            ContentTags = new List<ContentTagRecord>();
        }
        public virtual int Id { get; set; }
        public virtual string TagName { get; set; }
        public virtual IList<ContentTagRecord> ContentTags { get; set; }
    }
}
