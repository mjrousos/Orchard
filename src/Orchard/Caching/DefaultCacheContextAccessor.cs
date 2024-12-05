using Orchard.ContentManagement;
using Orchard.Security;
using Orchard.UI.Admin;
using Orchard.DisplayManagement;
using Orchard.Localization;
using Orchard.Services;
using System.Web.Mvc;
using Orchard.Mvc.Filters;
﻿using System;
using System.Collections.Generic;
using System.Linq;

namespace Orchard.Caching {
    public class DefaultCacheContextAccessor : ICacheContextAccessor {
        [ThreadStatic]
        private static IAcquireContext _threadInstance;
        public static IAcquireContext ThreadInstance {
            get { return _threadInstance; }
            set { _threadInstance = value; }
        }
        public IAcquireContext Current {
            get { return ThreadInstance; }
            set { ThreadInstance = value; }
    }
}
