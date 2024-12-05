using Orchard.ContentManagement;
using Orchard.Security;
using Orchard.UI.Admin;
using Orchard.DisplayManagement;
using Orchard.Localization;
using Orchard.Services;
using System.Web.Mvc;
using Orchard.Mvc.Filters;
using Orchard.Layouts.Framework.Elements;
using Orchard.Layouts.Helpers;

namespace Orchard.Layouts.Elements {
    public class Image : Element {
        public override string Category {
            get { return "Media"; }
        }
        public override string ToolboxIcon {
            get { return "\uf1c5"; }
        public int? MediaId {
            get { return this.Retrieve(x => x.MediaId); }
            set { this.Store(x => x.MediaId, value); }
    }
}
