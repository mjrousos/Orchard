using Orchard.ContentManagement;
using Orchard.Security;
using Orchard.UI.Admin;
using Orchard.DisplayManagement;
using Orchard.Localization;
using Orchard.Services;
using System.Web.Mvc;
using Orchard.Mvc.Filters;
﻿using Orchard.Environment.Extensions;

namespace Orchard.SecureSocketsLayer.Services {
    [OrchardSuppressDependency("Orchard.Security.Providers.DefaultSslSettingsProvider")]
    public class SecureSocketsLayerSettingsProvider : ISslSettingsProvider {
        private readonly ISecureSocketsLayerService _secureSocketsLayerService;
        public SecureSocketsLayerSettingsProvider(ISecureSocketsLayerService secureSocketsLayerService) {
            _secureSocketsLayerService = secureSocketsLayerService;
        }
        public bool GetRequiresSSL() {
            return _secureSocketsLayerService.GetSettings().Enabled;
    }
}
