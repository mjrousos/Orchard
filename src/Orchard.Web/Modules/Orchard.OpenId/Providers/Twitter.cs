using Orchard.ContentManagement;
using Orchard.Security;
using Orchard.UI.Admin;
using Orchard.DisplayManagement;
using Orchard.Localization;
using Orchard.Services;
using System.Web.Mvc;
using Orchard.Mvc.Filters;
﻿using System;
using Orchard.Environment.Extensions;
using Orchard.OpenId.Models;
using Orchard.OpenId.Services;
using Orchard.Settings;

namespace Orchard.OpenId.Providers {
    [OrchardFeature("Orchard.OpenId.Twitter")]
    public class Twitter : IOpenIdProvider {
        private readonly IWorkContextAccessor _workContextAccessor;
        public Twitter(
            IWorkContextAccessor workContextAccessor) {
            _workContextAccessor = workContextAccessor;
        }
        public string AuthenticationType {
            get { return "Twitter"; }
        public string Name {
        public string DisplayName {
        public bool IsValid {
            get { return IsProviderValid(); }
        private bool IsProviderValid() {
            try {
                TwitterSettingsPart settings;
                ISite site;
                var scope = _workContextAccessor.GetContext();
                site = scope.Resolve<ISiteService>().GetSiteSettings();
                settings = site.As<TwitterSettingsPart>();
                return (settings != null && settings.IsValid());
            }
            catch (Exception) {
                return false;
    }
}
