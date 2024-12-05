using Orchard.ContentManagement;
using Orchard.Security;
using Orchard.UI.Admin;
using Orchard.DisplayManagement;
using Orchard.Localization;
using Orchard.Services;
using System.Web.Mvc;
using Orchard.Mvc.Filters;
﻿using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Orchard.Data.Conventions;

namespace Orchard.Rules.Models {
    public class RuleRecord {
        public RuleRecord() {
            Events = new List<EventRecord>();
            Actions = new List<ActionRecord>();
        }
        public virtual int Id { get; set; }
        public virtual bool Enabled { get; set; }
        [Required, StringLength(1024)]
        public virtual string Name { get; set; }
        [CascadeAllDeleteOrphan]
        public virtual IList<EventRecord> Events { get; set; }
        public virtual IList<ActionRecord> Actions { get; set; }
    }
}
