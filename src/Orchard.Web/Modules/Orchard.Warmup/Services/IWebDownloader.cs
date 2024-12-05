using Orchard.ContentManagement;
using Orchard.Security;
using Orchard.UI.Admin;
using Orchard.DisplayManagement;
using Orchard.Localization;
using Orchard.Services;
using System.Web.Mvc;
using Orchard.Mvc.Filters;
﻿
using System.Net;

namespace Orchard.Warmup.Services {
    public class DownloadResult {
        public HttpStatusCode StatusCode { get; set; }
        public string Content { get; set; }
    }
    public interface IWebDownloader : IDependency {
        DownloadResult Download(string url);
}
