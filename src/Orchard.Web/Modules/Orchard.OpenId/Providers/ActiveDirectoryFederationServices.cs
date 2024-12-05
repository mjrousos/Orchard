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
    [OrchardFeature("Orchard.OpenId.ActiveDirectoryFederationServices")]
    public class ActiveDirectoryFederationServices : IOpenIdProvider {
        private readonly IWorkContextAccessor _workContextAccessor;
        public ActiveDirectoryFederationServices(
            IWorkContextAccessor workContextAccessor) {
            _workContextAccessor = workContextAccessor;
        }
        public string AuthenticationType {
            get { return "OpenIdConnect"; }
        public string Name {
            get { return "ADFS"; }
        public string DisplayName {
            get { return "Active Directory Federation Services"; }
        public bool IsValid {
            get { return IsProviderValid(); }
        private bool IsProviderValid() {
            try {
                ActiveDirectoryFederationServicesSettingsPart settings;
                ISite site;
                var scope = _workContextAccessor.GetContext();
                site = scope.Resolve<ISiteService>().GetSiteSettings();
                settings = site.As<ActiveDirectoryFederationServicesSettingsPart>();
                return (settings != null && settings.IsValid());
            }
            catch (Exception) {
                return false;
    }
}
