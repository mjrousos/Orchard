using Orchard.ContentManagement;
using Orchard.Security;
using Orchard.UI.Admin;
using Orchard.DisplayManagement;
using Orchard.Localization;
using Orchard.Services;
using System.Web.Mvc;
using Orchard.Mvc.Filters;
﻿namespace Orchard.Alias.Records {
    public class ActionRecord {
        public virtual int Id { get; set; }
        public virtual string Area { get; set; }
        public virtual string Controller { get; set; }
        public virtual string Action { get; set; }
    }
}
