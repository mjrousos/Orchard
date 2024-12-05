using Orchard.ContentManagement;
using Orchard.Security;
using Orchard.UI.Admin;
using Orchard.DisplayManagement;
using Orchard.Localization;
using Orchard.Services;
using System.Web.Mvc;
using Orchard.Mvc.Filters;
﻿namespace Orchard.Alias.Records {
    public class AliasRecord {
        public virtual int Id { get; set; }
        public virtual string Path { get; set; }
        public virtual ActionRecord Action { get; set; }
        public virtual string RouteValues { get; set; }
        public virtual string Source { get; set; }
        public virtual bool IsManaged { get; set; }
    }
}
