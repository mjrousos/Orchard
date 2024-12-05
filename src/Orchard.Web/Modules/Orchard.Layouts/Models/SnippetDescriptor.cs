using Orchard.ContentManagement;
using Orchard.Security;
using Orchard.UI.Admin;
using Orchard.DisplayManagement;
using Orchard.Localization;
using Orchard.Services;
using System.Web.Mvc;
using Orchard.Mvc.Filters;
using System.Collections.Generic;

namespace Orchard.Layouts.Models {
    public class SnippetDescriptor {
        public string Category { get; set; }
        public LocalizedString Description { get; set; }
        public LocalizedString DisplayName { get; set; }
        public string ToolboxIcon { get; set; }
        public SnippetDescriptor() {
            Fields = new List<SnippetFieldDescriptor>();
        }
        public IList<SnippetFieldDescriptor> Fields { get; set; }
    }
}
