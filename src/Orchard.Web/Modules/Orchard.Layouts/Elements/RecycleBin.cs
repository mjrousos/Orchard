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
    public class RecycleBin : Container {
        public override string Category { get { return null; } }
        public override bool IsSystemElement { get { return true; } }
    }
}
