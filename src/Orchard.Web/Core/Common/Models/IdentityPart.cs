using Orchard.ContentManagement;
using Orchard.Security;
using Orchard.UI.Admin;
using Orchard.DisplayManagement;
using Orchard.Localization;
using Orchard.Services;
using System.Web.Mvc;
using Orchard.Mvc.Filters;

namespace Orchard.Core.Common.Models {
    public class IdentityPart : ContentPart<IdentityPartRecord> {
        public string Identifier {
            get { return Retrieve(x => x.Identifier); }
            set { Store(x => x.Identifier, value); }
        }
    }
}
