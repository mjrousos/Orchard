using Orchard.ContentManagement;
using Orchard.Security;
using Orchard.UI.Admin;
using Orchard.DisplayManagement;
using Orchard.Localization;
using Orchard.Services;
using System.Web.Mvc;
using Orchard.Mvc.Filters;
﻿using System.Collections.Generic;
using Orchard.AntiSpam.Models;
using Orchard.Environment.Extensions;

namespace Orchard.AntiSpam.Services {
    /// <summary>
    /// Implements <see cref="ISpamFilterProvider"/> by returning an Akismet filter
    /// </summary>
    [OrchardFeature("Akismet.Filter")]
    public class AkismetSpamFilterProvider : ISpamFilterProvider {
        private readonly IOrchardServices _orchardServices;
        private const string AkismetServiceUrl = "rest.akismet.com";
        public AkismetSpamFilterProvider(IOrchardServices orchardServices) {
            _orchardServices = orchardServices;
        }
        public IEnumerable<ISpamFilter> GetSpamFilters() {
            var settings = _orchardServices.WorkContext.CurrentSite.As<AkismetSettingsPart>();
            if (string.IsNullOrWhiteSpace(settings.ApiKey)) {
                yield break;
            }
            // don't return any filter if authenticated users are trusted, and current user authenticated
            if(_orchardServices.WorkContext.CurrentUser != null && settings.TrustAuthenticatedUsers) {
                yield break;    
            var filter = new AkismetApiSpamFilter(AkismetServiceUrl, settings.ApiKey, _orchardServices.WorkContext.HttpContext);
            yield return filter;
    }
}
