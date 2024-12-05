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
    public class EditEventViewModel {
        public int Id { get; set; }
        public int EventId { get; set; }
        public EventDescriptor Event { get; set; }
        public dynamic Form { get; set; }
    }
}
