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

namespace Orchard.Tokens {
    public abstract class EvaluateContext {
        public abstract string Target { get; }
        public abstract IDictionary<string, string> Tokens { get; }
        public abstract IDictionary<string, object> Data { get; }
        public abstract IDictionary<string, object> Values { get; }
        public abstract EvaluateFor<TData> For<TData>(string target);
        public abstract EvaluateFor<TData> For<TData>(string target, TData defaultData);
        public abstract EvaluateFor<TData> For<TData>(string target, Func<TData> defaultData);
    }
}
