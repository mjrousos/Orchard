using Orchard.ContentManagement;
using Orchard.Security;
using Orchard.UI.Admin;
using Orchard.DisplayManagement;
using Orchard.Localization;
using Orchard.Services;
using System.Web.Mvc;
using Orchard.Mvc.Filters;
using System.Collections.Generic;
using Orchard.Layouts.Framework.Drivers;
using Orchard.Layouts.Framework.Elements;

namespace Orchard.Layouts.ViewModels {
    public class EditElementBlueprintViewModel {
        public EditElementBlueprintViewModel() {
            Tabs = new List<string>();
        }
        public EditorResult EditorResult { get; set; }
        public string TypeName { get; set; }
        public LocalizedString DisplayText { get; set; }
        public LocalizedString Description { get; set; }
        public string ElementData { get; set; }
        public IList<string> Tabs { get; set; }
        public CreateElementBlueprintViewModel Blueprint { get; set; }
        public Element BaseElement { get; set; }
    }
}
