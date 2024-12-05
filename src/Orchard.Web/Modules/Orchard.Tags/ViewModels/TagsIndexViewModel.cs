using Orchard.ContentManagement;
using Orchard.Security;
using Orchard.UI.Admin;
using Orchard.DisplayManagement;
using Orchard.Localization;
using Orchard.Services;
using System.Web.Mvc;
using Orchard.Mvc.Filters;
﻿using System.Collections.Generic;
using Orchard.Tags.Models;

namespace Orchard.Tags.ViewModels {
    public class TagsIndexViewModel {
        public IList<TagRecord> Tags { get; set; }
    }
}
