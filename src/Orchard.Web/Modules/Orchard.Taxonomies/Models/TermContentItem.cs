using Orchard.ContentManagement;
using Orchard.Security;
using Orchard.UI.Admin;
using Orchard.DisplayManagement;
using Orchard.Localization;
using Orchard.Services;
using System.Web.Mvc;
using Orchard.Mvc.Filters;
using Orchard.Data.Conventions;

namespace Orchard.Taxonomies.Models {
    /// <summary>
    /// Represents a relationship between a Term and a Content Item
    /// </summary>
    public class TermContentItem {
        public virtual int Id { get; set; }
        public virtual string Field { get; set; }
        public virtual TermPartRecord TermRecord { get; set; }
        [CascadeAllDeleteOrphan]
        public virtual TermsPartRecord TermsPartRecord { get; set; }
    }
}
