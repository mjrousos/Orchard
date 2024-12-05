using Orchard.ContentManagement;
using Orchard.Security;
using Orchard.UI.Admin;
using Orchard.DisplayManagement;
using Orchard.Localization;
using Orchard.Services;
using System.Web.Mvc;
using Orchard.Mvc.Filters;
﻿using System.Xml.Linq;

namespace Orchard.Core.XmlRpc {
    public interface IXmlRpcHandler : IDependency {
        void SetCapabilities(XElement element);
        void Process(XmlRpcContext context);
    }
}
