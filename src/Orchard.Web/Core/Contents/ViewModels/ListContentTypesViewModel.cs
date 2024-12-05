using Orchard.ContentManagement;
using Orchard.Security;
using Orchard.UI.Admin;
using Orchard.DisplayManagement;
using Orchard.Localization;
using Orchard.Services;
using System.Web.Mvc;
using Orchard.Mvc.Filters;
﻿using System.Collections.Generic;
using Orchard.ContentManagement.MetaData.Models;

namespace Orchard.Core.Contents.ViewModels {
    public class ListContentTypesViewModel  {
        public IEnumerable<ContentTypeDefinition> Types { get; set; }
    }
}
