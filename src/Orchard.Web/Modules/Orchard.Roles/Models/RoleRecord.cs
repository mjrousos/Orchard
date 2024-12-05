using Orchard.ContentManagement;
using Orchard.Security;
using Orchard.UI.Admin;
using Orchard.DisplayManagement;
using Orchard.Localization;
using Orchard.Services;
using System.Web.Mvc;
using Orchard.Mvc.Filters;
﻿using System.Collections.Generic;
using Orchard.Data.Conventions;

namespace Orchard.Roles.Models {
    public class RoleRecord {
        public RoleRecord() {
            RolesPermissions = new List<RolesPermissionsRecord>();
        }
        public virtual int Id { get; set; }
        public virtual string Name { get; set; }
        [CascadeAllDeleteOrphan]
        public virtual IList<RolesPermissionsRecord> RolesPermissions { get; set; }
    }
}
