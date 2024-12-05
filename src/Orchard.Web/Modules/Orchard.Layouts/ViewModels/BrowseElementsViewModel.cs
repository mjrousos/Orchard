using Orchard.ContentManagement;
using Orchard.Security;
using Orchard.UI.Admin;
using Orchard.DisplayManagement;
using Orchard.Localization;
using Orchard.Services;
using System.Web.Mvc;
using Orchard.Mvc.Filters;
using System.Collections.Generic;
using Orchard.Layouts.Framework.Elements;

namespace Orchard.Layouts.ViewModels {
    public class BrowseElementsViewModel {
        public IList<CategoryDescriptor> Categories { get; set; }
        public int? ContentId { get; set; }
        public string ContentType { get; set; }
        public string Session { get; set; }
    }
}
