using Orchard.ContentManagement;
using Orchard.Security;
using Orchard.UI.Admin;
using Orchard.DisplayManagement;
using Orchard.Localization;
using Orchard.Services;
using System.Web.Mvc;
using Orchard.Mvc.Filters;
using Orchard.Data.Conventions;

namespace Orchard.Tests.ContentManagement.Records {
    public class MegaRecord {
        public virtual int Id { get; set; }
        [StringLengthMax]
        public virtual string BigStuff { get; set; }
        public virtual string SmallStuff { get; set; }
    }
}
