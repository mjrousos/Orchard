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
    public class LayoutEditor {
        public IContent Content { get; set; }
        public string Data { get; set; }
        public string ConfigurationData { get; set; }
        public string RecycleBin { get; set; }
        public int? TemplateId { get; set; }
        public string SessionKey { get; set; }
        public IList<LayoutPart> Templates { get; set; }
    }
}
