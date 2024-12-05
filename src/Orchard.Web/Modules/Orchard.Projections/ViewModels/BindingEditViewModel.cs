using Orchard.ContentManagement;
using Orchard.Security;
using Orchard.UI.Admin;
using Orchard.DisplayManagement;
using Orchard.Localization;
using Orchard.Services;
using System.Web.Mvc;
using Orchard.Mvc.Filters;
﻿using System.ComponentModel.DataAnnotations;

namespace Orchard.Projections.ViewModels {
    public class BindingEditViewModel {
        public int Id { get; set; }
        [StringLength(255), Required]
        public string FullName { get; set; }
        [StringLength(64), Required]
        public string Member { get; set; }
        public string Display { get; set; }
        [StringLength(500), Required]
        public string Description { get; set; }
    }
}
