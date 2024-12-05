using Orchard.ContentManagement;
using Orchard.Security;
using Orchard.UI.Admin;
using Orchard.DisplayManagement;
using Orchard.Localization;
using Orchard.Services;
using System.Web.Mvc;
using Orchard.Mvc.Filters;
﻿using Orchard.ContentManagement;
using Orchard.Environment.Extensions;

namespace Orchard.Search.Models {
    [OrchardFeature("Orchard.Search.Content")]
    public class AdminSearchSettingsPart : ContentPart {
        
        public string SearchIndex {
            get { return this.Retrieve(x => x.SearchIndex); }
            set { this.Store(x => x.SearchIndex, value); }
        }
    }
}
