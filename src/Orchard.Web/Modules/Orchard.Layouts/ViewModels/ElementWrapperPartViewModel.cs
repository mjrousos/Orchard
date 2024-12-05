using Orchard.ContentManagement;
using Orchard.Security;
using Orchard.UI.Admin;
using Orchard.DisplayManagement;
using Orchard.Localization;
using Orchard.Services;
using System.Web.Mvc;
using Orchard.Mvc.Filters;
﻿using System.Collections.Generic;
using Orchard.Layouts.Framework.Drivers;

namespace Orchard.Layouts.ViewModels {
    public class ElementWrapperPartViewModel {
        public IList<string> Tabs { get; set; }
        public EditorResult ElementEditorResult { get; set; }
        public IList<dynamic> ElementEditors { get; set; }
        public string ElementTypeName { get; set; }
        public LocalizedString ElementDisplayText { get; set; }
    }
}
