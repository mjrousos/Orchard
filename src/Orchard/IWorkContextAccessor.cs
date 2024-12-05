using Orchard.ContentManagement;
using Orchard.Security;
using Orchard.UI.Admin;
using Orchard.DisplayManagement;
using Orchard.Localization;
using Orchard.Services;
using System.Web.Mvc;
using Orchard.Mvc.Filters;
﻿using System;
using System.Web;

namespace Orchard {
    public interface IWorkContextAccessor {
        WorkContext GetContext(HttpContextBase httpContext);
        IWorkContextScope CreateWorkContextScope(HttpContextBase httpContext);
        WorkContext GetContext();
        IWorkContextScope CreateWorkContextScope();
    }
    public interface ILogicalWorkContextAccessor: IWorkContextAccessor {
        WorkContext GetLogicalContext();
    public interface IWorkContextStateProvider : IDependency {
        Func<WorkContext, T> Get<T>(string name);
    public interface IWorkContextScope : IDisposable {
        WorkContext WorkContext { get; }
        TService Resolve<TService>();
        bool TryResolve<TService>(out TService service);
}
