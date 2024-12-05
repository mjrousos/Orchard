using Orchard.ContentManagement;
using Orchard.Security;
using Orchard.UI.Admin;
using Orchard.DisplayManagement;
using Orchard.Localization;
using Orchard.Services;
using System.Web.Mvc;
using Orchard.Mvc.Filters;

namespace Orchard.Core.Navigation.ViewModels {
    public class CreateMenuItemViewModel  {
        public MenuItemEntry MenuItem { get; set; }
    }
}
