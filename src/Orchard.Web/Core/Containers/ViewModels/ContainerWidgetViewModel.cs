using Orchard.ContentManagement;
using Orchard.Security;
using Orchard.UI.Admin;
using Orchard.DisplayManagement;
using Orchard.Localization;
using Orchard.Services;
using System.Web.Mvc;
using Orchard.Mvc.Filters;
﻿using System.Web.Mvc;
using Orchard.Core.Containers.Models;

namespace Orchard.Core.Containers.ViewModels {
    public class ContainerWidgetViewModel {
        public bool UseFilter { get; set; }
        public SelectList AvailableContainers { get; set; }
        public ContainerWidgetPart Part { get; set; }
    }
}
