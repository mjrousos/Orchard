using Orchard.ContentManagement;
using Orchard.Security;
using Orchard.UI.Admin;
using Orchard.DisplayManagement;
using Orchard.Localization;
using Orchard.Services;
using System.Web.Mvc;
using Orchard.Mvc.Filters;
using System.Collections.Generic;
using Orchard.Layouts.Models;

namespace Orchard.Layouts.ViewModels {
    public class SnippetViewModel {
        public SnippetViewModel() {
            FieldEditors = new List<dynamic>();
        }
        public SnippetDescriptor Descriptor { get; set; }
        public IList<dynamic> FieldEditors { get; set; }
    }
}
