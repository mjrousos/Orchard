using Orchard.ContentManagement;
using Orchard.Security;
using Orchard.UI.Admin;
using Orchard.DisplayManagement;
using Orchard.Localization;
using Orchard.Services;
using System.Web.Mvc;
using Orchard.Mvc.Filters;
﻿using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Orchard.Core.Navigation.Models;

namespace Orchard.Core.Navigation.ViewModels {
    public class MenuPartViewModel {
        public IEnumerable<ContentItem> Menus { get; set; }
        public int CurrentMenuId { get; set; }
        public bool OnMenu { get; set; }
        public ContentItem ContentItem { get; set; }
        [StringLength(MenuPartRecord.DefaultMenuTextLength)]
        public string MenuText { get; set; }
    }
}
