using Orchard.ContentManagement;
using Orchard.Security;
using Orchard.UI.Admin;
using Orchard.DisplayManagement;
using Orchard.Localization;
using Orchard.Services;
using System.Web.Mvc;
using Orchard.Mvc.Filters;
namespace Orchard.DynamicForms.ViewModels {
    public class BindingSettings {
        public string Name { get; set; }
        public bool Enabled { get; set; }
    }
}
