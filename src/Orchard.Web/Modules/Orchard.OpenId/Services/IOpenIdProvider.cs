using Orchard.ContentManagement;
using Orchard.Security;
using Orchard.UI.Admin;
using Orchard.DisplayManagement;
using Orchard.Localization;
using Orchard.Services;
using System.Web.Mvc;
using Orchard.Mvc.Filters;
﻿namespace Orchard.OpenId.Services {
    public interface IOpenIdProvider : IDependency {
        string AuthenticationType { get; }
        string DisplayName { get; }
        bool IsValid { get; }
        string Name { get; }
    }
}
