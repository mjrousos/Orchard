using Orchard.ContentManagement;
using Orchard.Security;
using Orchard.UI.Admin;
using Orchard.DisplayManagement;
using Orchard.Localization;
using Orchard.Services;
using System.Web.Mvc;
using Orchard.Mvc.Filters;
﻿using Orchard.ContentManagement.Records;

namespace Orchard.Widgets.Models {
    public class LayerPartRecord : ContentPartRecord {
        public virtual string Name { get; set; }
        public virtual string Description { get; set; }
        public virtual string LayerRule { get; set; }
    }
}
