using Orchard.ContentManagement;
using Orchard.Security;
using Orchard.UI.Admin;
using Orchard.DisplayManagement;
using Orchard.Localization;
using Orchard.Services;
using System.Web.Mvc;
using Orchard.Mvc.Filters;
﻿using System;

namespace Orchard.Forms.Services {
    public static class FormNodesProcessor {
        public static void ProcessForm(dynamic shape, Action<object> process) {
            // if it's not a shape, ignore
            // e.g., SelectListItem
            if (!(shape is IShape)) {
                return;
            }
            // execute external code on this node
            process(shape);
            // recursively process child nodes
            if (shape.Items != null) {
                foreach (var item in shape.Items) {
                    ProcessForm(item, process);
                }
        }
    }
}
