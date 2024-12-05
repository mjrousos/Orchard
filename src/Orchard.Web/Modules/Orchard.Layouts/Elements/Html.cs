using Orchard.ContentManagement;
using Orchard.Security;
using Orchard.UI.Admin;
using Orchard.DisplayManagement;
using Orchard.Localization;
using Orchard.Services;
using System.Web.Mvc;
using Orchard.Mvc.Filters;

namespace Orchard.Layouts.Elements {
    public class Html : ContentElement {
        public override LocalizedString DisplayText {
            get { return T("HTML"); }
        }
    }
}
