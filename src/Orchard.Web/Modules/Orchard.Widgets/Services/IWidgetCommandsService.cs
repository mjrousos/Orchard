using Orchard.ContentManagement;
using Orchard.Security;
using Orchard.UI.Admin;
using Orchard.DisplayManagement;
using Orchard.Localization;
using Orchard.Services;
using System.Web.Mvc;
using Orchard.Mvc.Filters;
﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Orchard.Commands;
using Orchard.Widgets.Models;

namespace Orchard.Widgets.Services {
    public interface IWidgetCommandsService : IDependency {
        WidgetPart CreateBaseWidget(CommandContext context, string type, string title, string name, string zone, string position, string layer, string identity, bool renderTitle, string owner, string text, bool useLoremIpsumText, string menuName);
        void Publish(WidgetPart widget);
    }
}
