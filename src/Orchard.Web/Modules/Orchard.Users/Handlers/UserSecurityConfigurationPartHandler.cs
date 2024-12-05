using Orchard.ContentManagement;
using Orchard.Security;
using Orchard.UI.Admin;
using Orchard.DisplayManagement;
using Orchard.Localization;
using Orchard.Services;
using System.Web.Mvc;
using Orchard.Mvc.Filters;
﻿using Orchard.ContentManagement.Handlers;
using Orchard.Data;
using Orchard.Users.Models;

namespace Orchard.Users.Handlers {
    public class UserSecurityConfigurationPartHandler : ContentHandler {
        public UserSecurityConfigurationPartHandler(
            IRepository<UserSecurityConfigurationPartRecord> repository) {
            Filters.Add(new ActivatingFilter<UserSecurityConfigurationPart>("User"));
            Filters.Add(StorageFilter.For(repository));
        }
    }
}
