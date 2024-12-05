using Orchard.ContentManagement;
using Orchard.Security;
using Orchard.UI.Admin;
using Orchard.DisplayManagement;
using Orchard.Localization;
using Orchard.Services;
using System.Web.Mvc;
using Orchard.Mvc.Filters;
﻿using Orchard.ContentManagement.Records;

namespace Orchard.Users.Models {
    public class UserSecurityConfigurationPartRecord : ContentPartRecord {
        // We are creating a record for this rather than making do with the infoset
        // because this will allow us to explicitly query for those users that must
        // (or not) be saved from suspension.
        public virtual bool SaveFromSuspension { get; set; }
        public virtual bool PreventPasswordExpiration { get; set; }
    }
}
