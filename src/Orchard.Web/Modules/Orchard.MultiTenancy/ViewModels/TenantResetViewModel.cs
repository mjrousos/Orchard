using Orchard.ContentManagement;
using Orchard.Security;
using Orchard.UI.Admin;
using Orchard.DisplayManagement;
using Orchard.Localization;
using Orchard.Services;
using System.Web.Mvc;
using Orchard.Mvc.Filters;
﻿using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using System.Linq;

namespace Orchard.MultiTenancy.ViewModels {
    public class TenantResetViewModel  {
        public TenantResetViewModel() {
            DatabaseTableNames = Enumerable.Empty<string>();
        }
        [Required]
        public string Name { get; set; }
        public bool DropDatabaseTables { get; set; }
        public IEnumerable<string> DatabaseTableNames { get; set; }
    }
}
