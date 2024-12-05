using Orchard.ContentManagement;
using Orchard.Security;
using Orchard.UI.Admin;
using Orchard.DisplayManagement;
using Orchard.Localization;
using Orchard.Services;
using System.Web.Mvc;
using Orchard.Mvc.Filters;
using Orchard.Layouts.Framework.Elements;

namespace Orchard.Layouts.Elements {
    public abstract class UIElement : Element {
        public override string Category {
            get { return "UI"; }
        }
        public override string ToolboxIcon {
            get { return "\uf0c8"; }
    }
}
