using Orchard.ContentManagement;
using Orchard.Security;
using Orchard.UI.Admin;
using Orchard.DisplayManagement;
using Orchard.Localization;
using Orchard.Services;
using System.Web.Mvc;
using Orchard.Mvc.Filters;
﻿using System;

namespace Orchard.Mvc.Filters {
    public interface IFilterProvider : IDependency {
        [Obsolete]
        void AddFilters(FilterInfo filterInfo);
    }
    public abstract class FilterProvider : IFilterProvider {
        void IFilterProvider.AddFilters(FilterInfo filterInfo) {
            AddFilters(filterInfo);
        }
        protected virtual void AddFilters(FilterInfo filterInfo) {
            if (this is IAuthorizationFilter)
                filterInfo.AuthorizationFilters.Add(this as IAuthorizationFilter);
            if (this is IActionFilter)
                filterInfo.ActionFilters.Add(this as IActionFilter);
            if (this is IResultFilter)
                filterInfo.ResultFilters.Add(this as IResultFilter);
            if (this is IExceptionFilter)
                filterInfo.ExceptionFilters.Add(this as IExceptionFilter);
}
