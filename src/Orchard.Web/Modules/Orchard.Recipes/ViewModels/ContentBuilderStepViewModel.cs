using Orchard.ContentManagement;
using Orchard.Security;
using Orchard.UI.Admin;
using Orchard.DisplayManagement;
using Orchard.Localization;
using Orchard.Services;
using System.Web.Mvc;
using Orchard.Mvc.Filters;
using System.Collections.Generic;
using Orchard.Recipes.Models;

namespace Orchard.Recipes.ViewModels {
    public class ContentBuilderStepViewModel {
        public ContentBuilderStepViewModel() {
            ContentTypes = new List<ContentTypeEntry>();
        }
        public IList<ContentTypeEntry> ContentTypes { get; set; }
        public VersionHistoryOptions VersionHistoryOptions { get; set; }
    }
}
