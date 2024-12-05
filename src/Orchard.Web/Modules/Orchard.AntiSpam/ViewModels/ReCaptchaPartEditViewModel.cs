using Orchard.ContentManagement;
using Orchard.Security;
using Orchard.UI.Admin;
using Orchard.DisplayManagement;
using Orchard.Localization;
using Orchard.Services;
using System.Web.Mvc;
using Orchard.Mvc.Filters;
﻿using Newtonsoft.Json;

namespace Orchard.AntiSpam.ViewModels {
    public class ReCaptchaPartEditViewModel {
        public string PublicKey { get; set; }
    }
    public class ReCaptchaPartResponseModel {
        [JsonProperty("success")]
        public bool Success { get; set; }
        [JsonProperty("error-codes")]
        public string[] ErrorCodes { get; set; }
}
