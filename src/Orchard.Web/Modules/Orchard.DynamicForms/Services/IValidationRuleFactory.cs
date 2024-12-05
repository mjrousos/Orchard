using Orchard.ContentManagement;
using Orchard.Security;
using Orchard.UI.Admin;
using Orchard.DisplayManagement;
using Orchard.Localization;
using Orchard.Services;
using System.Web.Mvc;
using Orchard.Mvc.Filters;
﻿using System;

namespace Orchard.DynamicForms.Services {
    public interface IValidationRuleFactory : IDependency {
        T Create<T>(Action<T> setup = null) where T : ValidationRule, new();
        T Create<T>(string errorMessage = null, Action<T> setup = null) where T : ValidationRule, new();
    }
}
