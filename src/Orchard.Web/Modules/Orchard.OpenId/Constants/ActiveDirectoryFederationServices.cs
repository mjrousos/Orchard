using Orchard.ContentManagement;
using Orchard.Security;
using Orchard.UI.Admin;
using Orchard.DisplayManagement;
using Orchard.Localization;
using Orchard.Services;
using System.Web.Mvc;
using Orchard.Mvc.Filters;
﻿namespace Orchard.OpenId.Constants {
    public class ActiveDirectoryFederationServices {
        public const string DefaultClientId = "xXxXxXxX-xXxX-xXxX-xXxX-xXxXxXxXxXxX";
        public const string DefaultMetadataAddress = "https://your-adfs-domain/adfs/.well-known/openid-configuration";
        public const string DefaultPostLogoutRedirectUri = "https://your-website/";
    }
}
