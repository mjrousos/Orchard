using Orchard.ContentManagement;
using Orchard.Security;
using Orchard.UI.Admin;
using Orchard.DisplayManagement;
using Orchard.Localization;
using Orchard.Services;
using System.Web.Mvc;
using Orchard.Mvc.Filters;
﻿using System.ComponentModel.DataAnnotations;

namespace Orchard.Projections.Models {
    public class MemberBindingRecord {
        public virtual int Id { get; set; }
        [StringLength(255)]
        public virtual string Type { get; set; }
        [StringLength(64)]
        public virtual string Member { get; set; }
        [StringLength(500)]
        public virtual string Description { get; set; }
        public virtual string DisplayName { get; set; }
    }
}
