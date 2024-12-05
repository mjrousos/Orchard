using Orchard.ContentManagement;
using Orchard.Security;
using Orchard.UI.Admin;
using Orchard.DisplayManagement;
using Orchard.Localization;
using Orchard.Services;
using System.Web.Mvc;
using Orchard.Mvc.Filters;
﻿using Orchard.ContentManagement;
using Orchard.ContentManagement.MetaData.Models;

namespace Orchard.Tests.ContentManagement.Models {
    public class Phi : ContentField {
        public Phi() {
            PartFieldDefinition = new ContentPartFieldDefinition(new ContentFieldDefinition("Phi"), "Phi", new SettingsDictionary());
        }
    }
}
