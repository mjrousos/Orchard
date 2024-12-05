using Orchard.ContentManagement;
using Orchard.Security;
using Orchard.UI.Admin;
using Orchard.DisplayManagement;
using Orchard.Localization;
using Orchard.Services;
using System.Web.Mvc;
using Orchard.Mvc.Filters;
using Orchard.Data.Conventions;

namespace Orchard.Tags.Models {
    public class ContentTagRecord {
        public virtual int Id { get; set; }
        [Aggregate]
        public virtual TagRecord TagRecord { get; set; }
        
        public virtual TagsPartRecord TagsPartRecord { get; set; }
    }
}
