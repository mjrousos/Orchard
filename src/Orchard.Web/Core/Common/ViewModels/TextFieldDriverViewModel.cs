using Orchard.ContentManagement;
using Orchard.Security;
using Orchard.UI.Admin;
using Orchard.DisplayManagement;
using Orchard.Localization;
using Orchard.Services;
using System.Web.Mvc;
using Orchard.Mvc.Filters;
﻿using Orchard.ContentManagement;
using Orchard.Core.Common.Fields;
using Orchard.Core.Common.Settings;

namespace Orchard.Core.Common.ViewModels {
    public class TextFieldDriverViewModel {
        public TextField Field { get; set; }
        public string Text { get; set; }
        public TextFieldSettings Settings { get; set; }
        public IContent ContentItem { get; set; }
    }
}
