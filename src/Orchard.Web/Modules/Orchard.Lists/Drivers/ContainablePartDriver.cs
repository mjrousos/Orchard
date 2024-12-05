using Orchard.ContentManagement;
using Orchard.Security;
using Orchard.UI.Admin;
using Orchard.DisplayManagement;
using Orchard.Localization;
using Orchard.Services;
using System.Web.Mvc;
using Orchard.Mvc.Filters;
﻿using Orchard.ContentManagement;
using Orchard.ContentManagement.Drivers;
using Orchard.Core.Containers.Models;

namespace Orchard.Lists.Drivers {
    public class ContainablePartDriver : ContentPartDriver<ContainablePart> {
        protected override DriverResult Editor(ContainablePart part, dynamic shapeHelper) {
            return Combined(
                ContentShape("Breadcrumbs_ContentItem", breadcrumbs => breadcrumbs.ContentItem(part)),
                ContentShape("ListNavigation", nav => nav.ContainablePart(part)),
                ContentShape("Dialog_CloseButton", saveButton => saveButton));
        }
        protected override DriverResult Editor(ContainablePart part, IUpdateModel updater, dynamic shapeHelper) {
            return Editor(part, updater);
    }
}
