using Orchard.ContentManagement;
using Orchard.Security;
using Orchard.UI.Admin;
using Orchard.DisplayManagement;
using Orchard.Localization;
using Orchard.Services;
using System.Web.Mvc;
using Orchard.Mvc.Filters;
using System.Collections.Generic;
using Orchard.Collections;

namespace Orchard.AuditTrail.ViewModels {
    public class RecycleBinViewModel {
        public RecycleBinViewModel() {
            SelectedContentItems = new List<RemovedContentItemViewModel>(0);
        }
        public RecycleBinCommand? RecycleBinCommand { get; set; }
        public IList<RemovedContentItemViewModel> SelectedContentItems { get; set; }
        public IPageOfItems<ContentItem> ContentItems { get; set; }
        public dynamic Pager { get; set; }
    }
}
