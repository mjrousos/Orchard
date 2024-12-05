using Orchard.ContentManagement;
using Orchard.Security;
using Orchard.UI.Admin;
using Orchard.DisplayManagement;
using Orchard.Localization;
using Orchard.Services;
using System.Web.Mvc;
using Orchard.Mvc.Filters;
﻿namespace Orchard.Data.Migration.Records {
    public class DataMigrationRecord {
        public virtual int Id { get; set; }
        public virtual string DataMigrationClass { get; set; }
        public virtual int? Version { get; set; }
    }
}
