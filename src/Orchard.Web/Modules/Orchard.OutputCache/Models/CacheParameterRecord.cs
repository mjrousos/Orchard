using Orchard.ContentManagement;
using Orchard.Security;
using Orchard.UI.Admin;
using Orchard.DisplayManagement;
using Orchard.Localization;
using Orchard.Services;
using System.Web.Mvc;
using Orchard.Mvc.Filters;
namespace Orchard.OutputCache.Models {
    public class CacheParameterRecord {
        public virtual int Id { get; set; }
        public virtual string RouteKey { get; set; }
        public virtual int? Duration { get; set; }
        public virtual int? GraceTime { get; set; }
    }
}
