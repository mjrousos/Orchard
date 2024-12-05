using Orchard.ContentManagement;
using Orchard.Security;
using Orchard.UI.Admin;
using Orchard.DisplayManagement;
using Orchard.Localization;
using Orchard.Services;
using System.Web.Mvc;
using Orchard.Mvc.Filters;
﻿using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Orchard.ContentManagement.MetaData.Models;
using Orchard.Core.Containers.Services;

namespace Orchard.Core.Containers.ViewModels {
    public class ContainerTypePartSettingsViewModel {
        public bool? ItemsShownDefault { get; set; }
        public int? PageSizeDefault { get; set; }
        public bool? PaginatedDefault { get; set; }
        public bool RestrictItemContentTypes { get; set; }
        public IList<string> RestrictedItemContentTypes { get; set; }
        public IList<ContentTypeDefinition> AvailableItemContentTypes { get; set; }
        public IList<IListViewProvider> ListViewProviders { get; set; }
        public bool? EnablePositioning { get; set; }
        [UIHint("ListViewPicker")]
        public string AdminListViewName { get; set; }
        public bool DisplayContainerEditor { get; set; }
    }
}
