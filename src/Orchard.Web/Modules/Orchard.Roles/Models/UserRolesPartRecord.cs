using Orchard.ContentManagement;
using Orchard.Security;
using Orchard.UI.Admin;
using Orchard.DisplayManagement;
using Orchard.Localization;
using Orchard.Services;
using System.Web.Mvc;
using Orchard.Mvc.Filters;
﻿namespace Orchard.Roles.Models {
    public class UserRolesPartRecord {
        public virtual int Id { get; set; }
        public virtual int UserId { get; set; }
        public virtual RoleRecord Role { get; set; }
    }
}
