using Orchard.ContentManagement;
using Orchard.Security;
using Orchard.UI.Admin;
using Orchard.DisplayManagement;
using Orchard.Localization;
using Orchard.Services;
using System.Web.Mvc;
using Orchard.Mvc.Filters;
using System.Collections.Generic;
using Orchard.ContentManagement.Utilities;

namespace Orchard.Roles.Models {
    public class UserRolesPart : ContentPart, IUserRoles {
        internal LazyField<IList<string>> _roles = new LazyField<IList<string>>();
        public IList<string> Roles {
            get { return _roles.Value; }
        }
    }
}
