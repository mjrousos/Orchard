using Orchard.ContentManagement;
using Orchard.Security;
using Orchard.UI.Admin;
using Orchard.DisplayManagement;
using Orchard.Localization;
using Orchard.Services;
using System.Web.Mvc;
using Orchard.Mvc.Filters;
﻿using System.Web;

namespace Orchard.Web.Tests.Stubs {
    internal class StubContext : HttpContextBase {
        private readonly StubRequest request;
        public StubContext(string relativeUrl) {
            request = new StubRequest(relativeUrl);
        }
        public override HttpRequestBase Request {
            get { return request; }
    }
}
