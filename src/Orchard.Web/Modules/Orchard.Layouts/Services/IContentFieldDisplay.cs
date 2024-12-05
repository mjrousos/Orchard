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
    public interface IContentFieldDisplay : IDependency {
        dynamic BuildDisplay(IContent content, ContentField field, string displayType = "", string groupId = "");
        dynamic BuildEditor(IContent content, ContentField field, string groupId = "");
        dynamic UpdateEditor(IContent content, ContentField field, IUpdateModel updater, string groupId = "");
    }
}
