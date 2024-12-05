using Orchard.ContentManagement;
using Orchard.Security;
using Orchard.UI.Admin;
using Orchard.DisplayManagement;
using Orchard.Localization;
using Orchard.Services;
using System.Web.Mvc;
using Orchard.Mvc.Filters;
using System.Collections.Generic;

namespace Orchard.Core.XmlRpc.Models {
    public class XRpcMethodResponse {
        public XRpcMethodResponse() { Params = new List<XRpcData>(); }
        public IList<XRpcData> Params { get; set; }
        public XRpcFault Fault { get; set; }
        public XRpcMethodResponse Add<T>(T value) {
            Params.Add(XRpcData.For(value));
            return this;
        }
    }
}
