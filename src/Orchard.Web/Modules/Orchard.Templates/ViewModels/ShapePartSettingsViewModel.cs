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
using Orchard.Templates.Services;

namespace Orchard.Templates.ViewModels {
    public class ShapePartSettingsViewModel {
        [UIHint("TemplateProcessorPicker")]
        public string Processor { get; set; }
        public IList<ITemplateProcessor> AvailableProcessors { get; set; }
    }
}
