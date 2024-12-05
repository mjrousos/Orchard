using Orchard.ContentManagement;
using Orchard.Security;
using Orchard.UI.Admin;
using Orchard.DisplayManagement;
using Orchard.Localization;
using Orchard.Services;
using System.Web.Mvc;
using Orchard.Mvc.Filters;
﻿using Orchard.Data.Conventions;

namespace Orchard.Rules.Models {
    public class ActionRecord {
        public virtual int Id { get; set; }
        public virtual string Category { get; set; }
        public virtual string Type { get; set; }
        [StringLengthMax]
        public virtual string Parameters { get; set; }
        public virtual int Position { get; set; }
        // Parent property
        public virtual RuleRecord RuleRecord { get; set; }
    }
}
