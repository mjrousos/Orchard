using Orchard.ContentManagement;
using Orchard.Security;
using Orchard.UI.Admin;
using Orchard.DisplayManagement;
using Orchard.Localization;
using Orchard.Services;
using System.Web.Mvc;
using Orchard.Mvc.Filters;
using Orchard.Data.Conventions;

namespace Orchard.Tests.Records {
    public class BigRecord {
        public virtual int Id { get; set; }
        [StringLengthMax]
        public virtual string Body { get; set; }
        public virtual byte[] Banner { get; set; }
    }
}
