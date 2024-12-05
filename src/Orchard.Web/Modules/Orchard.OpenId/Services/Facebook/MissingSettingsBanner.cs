using Orchard.ContentManagement;
using Orchard.Security;
using Orchard.UI.Admin;
using Orchard.DisplayManagement;
using Orchard.Localization;
using Orchard.Services;
using System.Web.Mvc;
using Orchard.Mvc.Filters;
﻿using System.Collections.Generic;
using Orchard.Environment.Extensions;
using Orchard.OpenId.Models;
using Orchard.UI.Admin.Notification;
using Orchard.UI.Notify;

namespace Orchard.Azure.Authentication.Services.Facebook {
    [OrchardFeature("Orchard.OpenId.Facebook")]
    public class MissingSettingsBanner : INotificationProvider {
        private readonly IOrchardServices _orchardServices;
        private readonly UrlHelper _urlHelper;
        public MissingSettingsBanner(IOrchardServices orchardServices, UrlHelper urlHelper)
        {
            _orchardServices = orchardServices;
            _urlHelper = urlHelper;
            T = NullLocalizer.Instance;
        }
        public Localizer T { get; set; }
        public IEnumerable<NotifyEntry> GetNotifications() {
            var workContext = _orchardServices.WorkContext;
            var settings = workContext.CurrentSite.As<FacebookSettingsPart>();
            if (settings == null || !settings.IsValid()) {
                var url = _urlHelper.Action("OpenId", "Admin", new { Area = "Settings" });
                yield return new NotifyEntry { Message = T("The <a href=\"{0}\">Facebook settings</a> need to be configured.", url), Type = NotifyType.Warning };
            }
    }
}
