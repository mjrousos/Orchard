using Orchard.ContentManagement;
using Orchard.Security;
using Orchard.UI.Admin;
using Orchard.DisplayManagement;
using Orchard.Localization;
using Orchard.Services;
using System.Web.Mvc;
using Orchard.Mvc.Filters;

namespace Orchard.Layouts.Services {
    public class DescribeElementsContext {
        public IContent Content { get; set; }
        public string CacheVaryParam { get; set; }
        public bool IsHarvesting { get; set; }
        public static readonly DescribeElementsContext Empty = new DescribeElementsContext();
    }
}
