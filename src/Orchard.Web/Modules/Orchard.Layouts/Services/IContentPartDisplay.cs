using Orchard.ContentManagement;
using Orchard.Security;
using Orchard.UI.Admin;
using Orchard.DisplayManagement;
using Orchard.Localization;
using Orchard.Services;
using System.Web.Mvc;
using Orchard.Mvc.Filters;
﻿using Orchard.ContentManagement;

namespace Orchard.Layouts.Services {
    public interface IContentPartDisplay : IDependency {
        dynamic BuildDisplay(ContentPart part, string displayType = "", string groupId = "");
        dynamic BuildEditor(ContentPart part, string groupId = "");
        dynamic UpdateEditor(ContentPart part, IUpdateModel updater, string groupId = "");
    }
}
