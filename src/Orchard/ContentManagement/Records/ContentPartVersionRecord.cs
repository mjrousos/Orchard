using Orchard.ContentManagement;
using Orchard.Security;
using Orchard.UI.Admin;
using Orchard.DisplayManagement;
using Orchard.Localization;
using Orchard.Services;
using System.Web.Mvc;
using Orchard.Mvc.Filters;
namespace Orchard.ContentManagement.Records {
    public abstract class ContentPartVersionRecord : ContentPartRecord {
        public virtual ContentItemVersionRecord ContentItemVersionRecord { get; set; }
    }
}
