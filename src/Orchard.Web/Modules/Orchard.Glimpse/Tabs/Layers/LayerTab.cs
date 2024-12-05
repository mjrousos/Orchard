using Orchard.ContentManagement;
using Orchard.Security;
using Orchard.UI.Admin;
using Orchard.DisplayManagement;
using Orchard.Localization;
using Orchard.Services;
using System.Web.Mvc;
using Orchard.Mvc.Filters;
﻿using System.Linq;
using Glimpse.Core.Extensibility;
using Glimpse.Core.Extensions;

namespace Orchard.Glimpse.Tabs.Layers {
    public class LayerTab : TabBase, ITabSetup, IKey {
        public override object GetData(ITabContext context) {
            var messages = context.GetMessages<LayerMessage>().ToList();
            if (!messages.Any()) {
                return null;
            }
            return messages;
        }
        public override string Name => "Layers";
        public void Setup(ITabSetupContext context) {
            context.PersistMessages<LayerMessage>();
        public string Key => "glimpse_orchard_layers";
    }
}
