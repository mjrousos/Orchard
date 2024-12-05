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

namespace Orchard.OpenId.Models {
    [OrchardFeature("Orchard.OpenId.ActiveDirectoryFederationServices")]
    public class ActiveDirectoryFederationServicesSettingsPart : ContentPart {
        public string ClientId {
            get { return this.Retrieve(x => x.ClientId, () => Constants.ActiveDirectoryFederationServices.DefaultClientId); }
            set { this.Store(x => x.ClientId, value); }
        }
        public string MetadataAddress {
            get { return this.Retrieve(x => x.MetadataAddress, () => Constants.ActiveDirectoryFederationServices.DefaultMetadataAddress); }
            set { this.Store(x => x.MetadataAddress, value); }
        public string PostLogoutRedirectUri {
            get { return this.Retrieve(x => x.PostLogoutRedirectUri); }
            set { this.Store(x => x.PostLogoutRedirectUri, value); }
        public bool IsValid() {
            if (String.IsNullOrWhiteSpace(ClientId) ||
                String.CompareOrdinal(ClientId, Constants.ActiveDirectoryFederationServices.DefaultClientId) == 0 ||
                String.IsNullOrWhiteSpace(MetadataAddress) ||
                String.CompareOrdinal(MetadataAddress, Constants.ActiveDirectoryFederationServices.DefaultMetadataAddress) == 0 ||
                String.IsNullOrWhiteSpace(PostLogoutRedirectUri)) {
                return false;
            }
            return true;
    }
}
