using Orchard.ContentManagement;
using Orchard.Security;
using Orchard.UI.Admin;
using Orchard.DisplayManagement;
using Orchard.Localization;
using Orchard.Services;
using System.Web.Mvc;
using Orchard.Mvc.Filters;
﻿using System.Collections.Generic;
using Orchard.ContentManagement.MetaData;

namespace Orchard.ContentTypes.ViewModels {
    public class EditFieldNameViewModel {
        /// <summary>
        /// The technical name of the field
        /// </summary>
        public string Name { get; set; }
        /// The display name of the field
        public string DisplayName { get; set; }
   }
}
