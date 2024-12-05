using Orchard.ContentManagement;
using Orchard.Security;
using Orchard.UI.Admin;
using Orchard.DisplayManagement;
using Orchard.Localization;
using Orchard.Services;
using System.Web.Mvc;
using Orchard.Mvc.Filters;
﻿using System.Collections.Generic;

namespace Orchard.Scripting {
    public interface IGlobalMethodProvider {
        void Process(GlobalMethodContext context);
    }
    public class GlobalMethodContext {
        public string FunctionName { get; set; }
        public IList<object> Arguments { get; set; }
        public object Result { get; set; }
}
