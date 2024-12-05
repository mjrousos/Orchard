using Orchard.ContentManagement;
using Orchard.Security;
using Orchard.UI.Admin;
using Orchard.DisplayManagement;
using Orchard.Localization;
using Orchard.Services;
using System.Web.Mvc;
using Orchard.Mvc.Filters;
﻿using System.Collections.Generic;
using Orchard.ContentPicker.Fields;

namespace Orchard.ContentPicker.ViewModels {
    public class ContentPickerFieldViewModel {
        public ICollection<ContentItem> ContentItems { get; set; }
        public string SelectedIds { get; set; }
        public ContentPickerField Field { get; set; }
        public ContentPart Part { get; set; }
    }
}
