using Orchard.ContentManagement;
using Orchard.Security;
using Orchard.UI.Admin;
using Orchard.DisplayManagement;
using Orchard.Localization;
using Orchard.Services;
using System.Web.Mvc;
using Orchard.Mvc.Filters;
﻿using Orchard.Layouts.Models;

namespace Orchard.Layouts.ViewModels {
    public class SnippetFieldViewModel {
        public SnippetFieldDescriptor Descriptor { get; set; }
        public string Value { get; set; }
    }
}
