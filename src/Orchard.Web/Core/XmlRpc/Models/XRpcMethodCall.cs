using Orchard.ContentManagement;
using Orchard.Security;
using Orchard.UI.Admin;
using Orchard.DisplayManagement;
using Orchard.Localization;
using Orchard.Services;
using System.Web.Mvc;
using Orchard.Mvc.Filters;
﻿using System.Collections.Generic;

namespace Orchard.Core.XmlRpc.Models {
    public class XRpcMethodCall {
        public XRpcMethodCall() { Params = new List<XRpcData>(); }
        public string MethodName { get; set; }
        public IList<XRpcData> Params { get; set; }
    }
}
