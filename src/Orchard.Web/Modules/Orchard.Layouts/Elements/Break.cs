using Orchard.ContentManagement;
using Orchard.Security;
using Orchard.UI.Admin;
using Orchard.DisplayManagement;
using Orchard.Localization;
using Orchard.Services;
using System.Web.Mvc;
using Orchard.Mvc.Filters;
namespace Orchard.Layouts.Elements {
    public class Break : ContentElement {
        public override string ToolboxIcon {
            get { return "\uf068"; }
        }

        public override bool HasEditor {
            get { return false; }
    }
}
