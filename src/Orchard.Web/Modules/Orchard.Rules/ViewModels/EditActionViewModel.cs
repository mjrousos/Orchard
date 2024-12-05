using Orchard.ContentManagement;
using Orchard.Security;
using Orchard.UI.Admin;
using Orchard.DisplayManagement;
using Orchard.Localization;
using Orchard.Services;
using System.Web.Mvc;
using Orchard.Mvc.Filters;
﻿using Orchard.Rules.Models;

namespace Orchard.Rules.ViewModels {
    public class EditActionViewModel {
        public int Id { get; set; }
        public int ActionId { get; set; }
        public ActionDescriptor Action { get; set; }
        public dynamic Form { get; set; }
    }
}
