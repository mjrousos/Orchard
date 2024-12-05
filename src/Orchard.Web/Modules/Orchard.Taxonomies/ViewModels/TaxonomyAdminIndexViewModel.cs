using Orchard.ContentManagement;
using Orchard.Security;
using Orchard.UI.Admin;
using Orchard.DisplayManagement;
using Orchard.Localization;
using Orchard.Services;
using System.Web.Mvc;
using Orchard.Mvc.Filters;
﻿using System.Collections.Generic;

namespace Orchard.Taxonomies.ViewModels {
    public class TaxonomyAdminIndexViewModel {
        public IList<TaxonomyEntry> Taxonomies { get; set; }
        public TaxonomiesAdminIndexBulkAction BulkAction { get; set; }
        public dynamic Pager { get; set; }
    }
    public class TaxonomyEntry {
        public int Id { get; set; }
        public bool IsInternal { get; set; }
        public string Name { get; set; }
        public ContentItem ContentItem { get; set; }
        public bool IsChecked { get; set; }
        public bool HasDraft { get; set; }
    public enum TaxonomiesAdminIndexBulkAction {
        None,
        Delete,
}
