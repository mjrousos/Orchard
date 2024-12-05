using Orchard.ContentManagement;
using Orchard.Security;
using Orchard.UI.Admin;
using Orchard.DisplayManagement;
using Orchard.Localization;
using Orchard.Services;
using System.Web.Mvc;
using Orchard.Mvc.Filters;
using System.Collections.Generic;

namespace Orchard.DynamicForms.ViewModels {
    public class PartBindingSettings {
        public PartBindingSettings() {
            Bindings = new List<BindingSettings>();
            Fields = new List<FieldBindingSettings>();
        }
        public string Name { get; set; }
        public IList<BindingSettings> Bindings { get; set; }
        public IList<FieldBindingSettings> Fields { get; set; }
    }
}
