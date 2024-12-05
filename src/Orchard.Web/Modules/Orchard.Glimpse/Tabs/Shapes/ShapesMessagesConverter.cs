using Orchard.ContentManagement;
using Orchard.Security;
using Orchard.UI.Admin;
using Orchard.DisplayManagement;
using Orchard.Localization;
using Orchard.Services;
using System.Web.Mvc;
using Orchard.Mvc.Filters;
﻿using System.Collections.Generic;
using Glimpse.Core.Extensibility;
using Glimpse.Core.Tab.Assist;
using Orchard.Glimpse.Extensions;

namespace Orchard.Glimpse.Tabs.Shapes {
    public class ShapesMessagesConverter : SerializationConverter<IEnumerable<ShapeMessage>> {
        public override object Convert(IEnumerable<ShapeMessage> messages) {
            var root = new TabSection("Type", "Display Type", "Position", "Placement Source", "Prefix", "Binding Source", "Available Binding Sources", "Wrappers", "Alternates", "Build Display Duration");
            foreach (var message in messages) {
                root.AddRow()
                    .Column(message.Type)
                    .Column(message.DisplayType)
                    .Column(message.Position)
                    .Column(message.PlacementSource)
                    .Column(message.Prefix)
                    .Column(message.BindingSource)
                    .Column(message.BindingSources)
                    .Column(message.Wrappers)
                    .Column(message.Alternates)
                    .Column(message.Duration.ToTimingString());
            }
            return root.Build();
        }
    }
}
