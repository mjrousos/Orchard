using Orchard.ContentManagement;
using Orchard.Security;
using Orchard.UI.Admin;
using Orchard.DisplayManagement;
using Orchard.Localization;
using Orchard.Services;
using System.Web.Mvc;
using Orchard.Mvc.Filters;
﻿using System.ComponentModel.DataAnnotations;
using Orchard.Layouts.Framework.Elements;

namespace Orchard.Layouts.ViewModels {
    public class ElementBlueprintPropertiesViewModel {
        public string ElementTypeName { get; set; }
        [Required]
        public string ElementDisplayName { get; set; }
        [MaxLength(2048)]
        public string ElementDescription { get; set; }
        public string ElementCategory { get; set; }
        public Element BaseElement { get; set; }
    }
}
