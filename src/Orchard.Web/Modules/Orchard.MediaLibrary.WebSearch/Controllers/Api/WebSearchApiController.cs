using Orchard.ContentManagement;
using Orchard.Security;
using Orchard.UI.Admin;
using Orchard.DisplayManagement;
using Orchard.Localization;
using Orchard.Services;
using System.Web.Mvc;
using Orchard.Mvc.Filters;
﻿using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web.Http;
using Orchard.MediaLibrary.WebSearch.Providers;

namespace Orchard.MediaLibrary.WebSearch.Controllers.Api {
    public class WebSearchApiController : ApiController {
        private readonly IAuthorizer _authorizer;
        private readonly IEnumerable<IWebSearchProvider> _wsp;
        public WebSearchApiController(IAuthorizer authorizer, IEnumerable<IWebSearchProvider> wsp) {
            _authorizer = authorizer;
            _wsp = wsp;
        }
        [HttpGet]
        public IHttpActionResult GetImages(string query, string providerType) {
            if (!_authorizer.Authorize(Permissions.AccessMediaWebSearch)) {
                return StatusCode(HttpStatusCode.Unauthorized);
            }
            var selectedProvider = _wsp.FirstOrDefault(provider => provider.Name == providerType);
            if (selectedProvider == null || !selectedProvider.IsValid()) {
                return NotFound();
            return Json(selectedProvider.GetImages(query));
    }
}
