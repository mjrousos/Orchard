using Orchard.ContentManagement;
using Orchard.Security;
using Orchard.UI.Admin;
using Orchard.DisplayManagement;
using Orchard.Localization;
using Orchard.Services;
using System.Web.Mvc;
using Orchard.Mvc.Filters;
﻿using System.ComponentModel.DataAnnotations;
using Orchard.DisplayManagement.Shapes;

namespace Orchard.Core.Common.OwnerEditor {
    public class OwnerEditorViewModel : Shape {
        [Required]
        public string Owner { get; set; }
    }
}
