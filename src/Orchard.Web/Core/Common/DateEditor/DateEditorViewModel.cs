using Orchard.ContentManagement;
using Orchard.Security;
using Orchard.UI.Admin;
using Orchard.DisplayManagement;
using Orchard.Localization;
using Orchard.Services;
using System.Web.Mvc;
using Orchard.Mvc.Filters;
﻿using Orchard.Core.Common.ViewModels;
using Orchard.DisplayManagement.Shapes;

namespace Orchard.Core.Common.DateEditor {
    public class DateEditorViewModel : Shape {
        public virtual DateTimeEditor Editor { get; set; }
    }
}
