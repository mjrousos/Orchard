using Orchard.ContentManagement;
using Orchard.Security;
using Orchard.UI.Admin;
using Orchard.DisplayManagement;
using Orchard.Localization;
using Orchard.Services;
using System.Web.Mvc;
using Orchard.Mvc.Filters;
﻿using Orchard.Events;

namespace Orchard.Tokens {
    public interface ITokenProvider : IEventHandler {
        void Describe(DescribeContext context);
        void Evaluate(EvaluateContext context);
    }
}
