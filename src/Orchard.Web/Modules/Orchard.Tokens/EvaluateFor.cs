using Orchard.ContentManagement;
using Orchard.Security;
using Orchard.UI.Admin;
using Orchard.DisplayManagement;
using Orchard.Localization;
using Orchard.Services;
using System.Web.Mvc;
using Orchard.Mvc.Filters;
﻿using System;

namespace Orchard.Tokens {
    public abstract class EvaluateFor<TData> {
        public abstract TData Data { get; }
        public abstract EvaluateFor<TData> Token(string token, Func<TData, object> tokenValue);
        public abstract EvaluateFor<TData> Chain(string token, string chainTarget, Func<TData, object> chainValue);
        public abstract EvaluateFor<TData> Token(Func<string, TData, object> tokenValue);
        public abstract EvaluateFor<TData> Token(Func<string, string> filter, Func<string, TData, object> tokenValue);
        public abstract EvaluateFor<TData> Chain(Func<string, Tuple<string, string>> filter, string chainTarget, Func<string, TData, object> chainValue);
    }
}
