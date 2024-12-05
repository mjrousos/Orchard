using Orchard.ContentManagement;
using Orchard.Security;
using Orchard.UI.Admin;
using Orchard.DisplayManagement;
using Orchard.Localization;
using Orchard.Services;
using System.Web.Mvc;
using Orchard.Mvc.Filters;
﻿using System;
using Orchard.Data.Conventions;

namespace Orchard.DynamicForms.Models {
    public class Submission {
        public virtual int Id { get; set; }
        public virtual string FormName { get; set; }
        [StringLengthMax]
        public virtual string FormData { get; set; }
        public virtual DateTime CreatedUtc { get; set; }
    }
}
