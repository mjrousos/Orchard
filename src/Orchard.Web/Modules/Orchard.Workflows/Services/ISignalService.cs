using Orchard.ContentManagement;
using Orchard.Security;
using Orchard.UI.Admin;
using Orchard.DisplayManagement;
using Orchard.Localization;
using Orchard.Services;
using System.Web.Mvc;
using Orchard.Mvc.Filters;
﻿namespace Orchard.Workflows.Services {
    public interface ISignalService : IDependency {
        string CreateNonce(int contentItemId, string signal);
        bool DecryptNonce(string nonce, out int contentItemId, out string signal);
    }
}
