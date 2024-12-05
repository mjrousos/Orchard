using Orchard.ContentManagement;
using Orchard.Security;
using Orchard.UI.Admin;
using Orchard.DisplayManagement;
using Orchard.Localization;
using Orchard.Services;
using System.Web.Mvc;
using Orchard.Mvc.Filters;
﻿using Orchard.Environment.Extensions;
using Orchard.Layouts.Framework.Elements;

namespace Orchard.Layouts.Elements {
    [OrchardFeature("Orchard.Layouts.Snippets")]
    public class Snippet : Element {
        public override string Category {
            get { return "Snippets"; }
        }
        public override bool IsSystemElement {
            get { return true; }
        public override bool HasEditor {
            get { return false; }
        public override string ToolboxIcon {
            get { return "\uf10c"; }
    }
}
