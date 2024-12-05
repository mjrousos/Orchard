using Orchard.ContentManagement;
using Orchard.Security;
using Orchard.UI.Admin;
using Orchard.DisplayManagement;
using Orchard.Localization;
using Orchard.Services;
using System.Web.Mvc;
using Orchard.Mvc.Filters;
﻿using System.Collections.Generic;
using Newtonsoft.Json;
using Orchard.Roles.ViewModels;

namespace Orchard.Roles.Models {
    public class RolesUserSuspensionSettingsPart : ContentPart {
        public List<RoleSuspensionConfiguration> Configuration {
            get {
                return JsonConvert
                  .DeserializeObject<List<RoleSuspensionConfiguration>>(SerializedConfiguration);
            }
            set { SerializedConfiguration = JsonConvert.SerializeObject(value); }
        }
        public string SerializedConfiguration {
            get { return this.Retrieve(x => x.SerializedConfiguration, defaultValue: string.Empty); }
            set { this.Store(x => x.SerializedConfiguration, value ?? string.Empty); }
    }
}
