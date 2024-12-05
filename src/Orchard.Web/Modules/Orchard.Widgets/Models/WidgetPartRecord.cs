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
    public class WidgetPartRecord : ContentPartRecord {
        public virtual string Title { get; set; }
        public virtual string Position { get; set; }
        public virtual string Zone { get; set; }
        public virtual bool RenderTitle { get; set; }
        public virtual string Name { get; set; }
    }
}
