using Orchard.ContentManagement;
using Orchard.Security;
using Orchard.UI.Admin;
using Orchard.DisplayManagement;
using Orchard.Localization;
using Orchard.Services;
using System.Web.Mvc;
using Orchard.Mvc.Filters;
﻿using System.ComponentModel.DataAnnotations;
using Orchard.ContentManagement.Records;

namespace Orchard.Core.Navigation.Models {
    public class MenuPartRecord : ContentPartRecord {
        public const ushort DefaultMenuTextLength = 255;
        [StringLength(DefaultMenuTextLength)]
        public virtual string MenuText { get; set; }
        public virtual string MenuPosition { get; set; }
        public virtual int MenuId { get; set; }
    }
}
