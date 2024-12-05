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
using Orchard.Security.Permissions;

namespace Orchard.Roles.ViewModels {
    public class RoleEditViewModel  {
        public int Id { get; set; }
        [Required, StringLength(255)]
        public string Name { get; set; }
        public IDictionary<string, IEnumerable<Permission>> RoleCategoryPermissions { get; set; }
        public IEnumerable<string> CurrentPermissions { get; set; }
        public IEnumerable<string> EffectivePermissions { get; set; }
    }
}
