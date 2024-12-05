using Orchard.ContentManagement;
using Orchard.Security;
using Orchard.UI.Admin;
using Orchard.DisplayManagement;
using Orchard.Localization;
using Orchard.Services;
using System.Web.Mvc;
using Orchard.Mvc.Filters;
﻿using Glimpse.Core.Extensibility;
using Glimpse.Core.Extensions;
using System.Linq;

namespace Orchard.Glimpse.Tabs.Widgets {
    public class WidgetTab : TabBase, ITabSetup, IKey {
        public override object GetData(ITabContext context) {
            var messages = context.GetMessages<WidgetMessage>().ToList();
            if (!messages.Any()) {
                return null;
            }
            return messages;
        }
        public override string Name => "Widgets";
        public void Setup(ITabSetupContext context) {
            context.PersistMessages<WidgetMessage>();
        public string Key => "glimpse_orchard_widgets";
    }
}
