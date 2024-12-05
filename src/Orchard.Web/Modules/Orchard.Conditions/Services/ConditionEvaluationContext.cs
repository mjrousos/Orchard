using Orchard.ContentManagement;
using Orchard.Security;
using Orchard.UI.Admin;
using Orchard.DisplayManagement;
using Orchard.Localization;
using Orchard.Services;
using System.Web.Mvc;
using Orchard.Mvc.Filters;
﻿namespace Orchard.Conditions.Services {
    public class ConditionEvaluationContext {
        public string FunctionName { get; set; }
        public object[] Arguments { get; set; }
        public object Result { get; set; }
    }
}
