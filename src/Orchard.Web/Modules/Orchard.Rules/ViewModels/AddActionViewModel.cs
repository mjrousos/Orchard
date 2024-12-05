using Orchard.ContentManagement;
using Orchard.Security;
using Orchard.UI.Admin;
using Orchard.DisplayManagement;
using Orchard.Localization;
using Orchard.Services;
using System.Web.Mvc;
using Orchard.Mvc.Filters;
﻿using System.Collections.Generic;
using Orchard.Rules.Models;

namespace Orchard.Rules.ViewModels {
    public class AddActionViewModel {
        public int Id { get; set; }
        public IEnumerable<TypeDescriptor<ActionDescriptor>> Actions { get; set; }
    }
}
