using Orchard.ContentManagement;
using Orchard.Security;
using Orchard.UI.Admin;
using Orchard.DisplayManagement;
using Orchard.Localization;
using Orchard.Services;
using System.Web.Mvc;
using Orchard.Mvc.Filters;
using System.Collections.Generic;
using System.Web;
using Orchard.Core.XmlRpc.Models;

namespace Orchard.Core.XmlRpc {
    public class XmlRpcContext {
        public ControllerContext ControllerContext { get; set; } 
        public HttpContextBase HttpContext { get; set; }
        public XRpcMethodCall Request { get; set; }
        public XRpcMethodResponse Response { get; set; }
        public ICollection<IXmlRpcDriver> _drivers = new List<IXmlRpcDriver>();
    }
}
