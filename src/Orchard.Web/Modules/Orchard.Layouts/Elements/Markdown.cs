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
    public class Markdown : ContentElement {
        public override string ToolboxIcon {
            get { return "\uf0f6"; }
        }
    }
}
