using Orchard.ContentManagement;
using Orchard.Security;
using Orchard.UI.Admin;
using Orchard.DisplayManagement;
using Orchard.Localization;
using Orchard.Services;
using System.Web.Mvc;
using Orchard.Mvc.Filters;
using Orchard.ContentPicker.Models;

namespace Orchard.ContentPicker.ViewModels {
    public class ContentMenuItemEditViewModel  {
        public int ContentItemId { get; set; }
        public ContentMenuItemPart Part { get; set; }
    }
}
