using Orchard.ContentManagement;
using Orchard.Security;
using Orchard.UI.Admin;
using Orchard.DisplayManagement;
using Orchard.Localization;
using Orchard.Services;
using System.Web.Mvc;
using Orchard.Mvc.Filters;
﻿namespace Orchard.Roles.Models {
    public class PermissionRecord {
        public virtual int Id { get; set; }
        public virtual string Name { get; set; }
        public virtual string FeatureName { get; set; }
        public virtual string Description { get; set; }
    }
}
