using Orchard.ContentManagement;
using Orchard.Security;
using Orchard.UI.Admin;
using Orchard.DisplayManagement;
using Orchard.Localization;
using Orchard.Services;
using System.Web.Mvc;
using Orchard.Mvc.Filters;
namespace Orchard.Tests.Records {
    public class BarRecord {
        public virtual int Id { get; set; }
        public virtual decimal Height { get; set; }
        public virtual decimal Width { get; set; }
    }
}
