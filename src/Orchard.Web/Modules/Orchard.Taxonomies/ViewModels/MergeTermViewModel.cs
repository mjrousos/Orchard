using Orchard.ContentManagement;
using Orchard.Security;
using Orchard.UI.Admin;
using Orchard.DisplayManagement;
using Orchard.Localization;
using Orchard.Services;
using System.Web.Mvc;
using Orchard.Mvc.Filters;
using System.Collections.Generic;
using Orchard.Taxonomies.Models;

namespace Orchard.Taxonomies.ViewModels {
    public class MergeTermViewModel {
        public IEnumerable<TermPart> Terms { get; set; }
        public int SelectedTermId { get; set; }
        public int TaxonomyId { get; set; }
        public TermPart[] TermsToMerge { get; set; }
        public bool ForcePublish { get; set; }
    }
}
