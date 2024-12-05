using Orchard.ContentManagement;
using Orchard.Security;
using Orchard.UI.Admin;
using Orchard.DisplayManagement;
using Orchard.Localization;
using Orchard.Services;
using System.Web.Mvc;
using Orchard.Mvc.Filters;
﻿using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Orchard.Tags.ViewModels {
    public class TagsAdminEditViewModel {
        public int Id { get; set; }
        [Required, DisplayName("Name")]
        public string TagName { get; set; } 
    }
}
