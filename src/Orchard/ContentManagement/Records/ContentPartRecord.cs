using Orchard.ContentManagement;
using Orchard.Security;
using Orchard.UI.Admin;
using Orchard.DisplayManagement;
using Orchard.Localization;
using Orchard.Services;
using System.Web.Mvc;
using Orchard.Mvc.Filters;
using Orchard.Data.Conventions;

namespace Orchard.ContentManagement.Records {
    public abstract class ContentPartRecord {
        public virtual int Id { get; set; }
        [CascadeAllDeleteOrphan]
        public virtual ContentItemRecord ContentItemRecord { get; set; }
    }
}
