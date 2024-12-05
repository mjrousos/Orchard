using Orchard.ContentManagement;
using Orchard.Security;
using Orchard.UI.Admin;
using Orchard.DisplayManagement;
using Orchard.Localization;
using Orchard.Services;
using System.Web.Mvc;
using Orchard.Mvc.Filters;
using Orchard.ContentManagement.Records;
using Orchard.Data.Conventions;

namespace Orchard.Core.Common.Models {
    public class BodyPartRecord : ContentPartVersionRecord {
        [StringLengthMax]
        public virtual string Text { get; set; }
        public virtual string Format { get; set; }
    }
}
