using Orchard.ContentManagement;
using Orchard.Security;
using Orchard.UI.Admin;
using Orchard.DisplayManagement;
using Orchard.Localization;
using Orchard.Services;
using System.Web.Mvc;
using Orchard.Mvc.Filters;
﻿using System;
using System.Threading.Tasks;
using Microsoft.Azure.ActiveDirectory.GraphClient;

namespace Orchard.OpenId.Services.AzureActiveDirectory {
    public interface IAzureActiveDirectoryService : ISingletonDependency {
        string Token { get; set; }
        DateTimeOffset TokenExpiresOn { get; set; }
        string AzureTenant { get; set; }
        Task<string> AcquireTokenAsync();
        ActiveDirectoryClient GetActiveDirectoryClient();
    }
}
