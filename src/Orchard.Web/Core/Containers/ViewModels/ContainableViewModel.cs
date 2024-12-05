using Orchard.ContentManagement;
using Orchard.Security;
using Orchard.UI.Admin;
using Orchard.DisplayManagement;
using Orchard.Localization;
using Orchard.Services;
using System.Web.Mvc;
using Orchard.Mvc.Filters;
﻿using System.Web.Mvc;

namespace Orchard.Core.Containers.ViewModels {
    public class ContainableViewModel {
        public int ContainerId { get; set; }
        public SelectList AvailableContainers { get; set; }
        public int Position { get; set; }
        public bool ShowContainerPicker { get; set; }
        public bool ShowPositionEditor { get; set; }
    }
}
