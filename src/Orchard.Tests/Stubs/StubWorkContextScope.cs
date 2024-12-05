using Orchard.ContentManagement;
using Orchard.Security;
using Orchard.UI.Admin;
using Orchard.DisplayManagement;
using Orchard.Localization;
using Orchard.Services;
using System.Web.Mvc;
using Orchard.Mvc.Filters;
using Autofac;

namespace Orchard.Tests.Stubs {
    public class StubWorkContextScope : IWorkContextScope {
        private readonly ILifetimeScope _lifetimeScope;
        public StubWorkContextScope(WorkContext workContext, ILifetimeScope lifetimeScope) {
            _lifetimeScope = lifetimeScope;
            WorkContext = workContext;
        }
        public WorkContext WorkContext { get; private set; }
        public void Dispose() {
            _lifetimeScope.Dispose();
        public TService Resolve<TService>() {
            return WorkContext.Resolve<TService>();
        public bool TryResolve<TService>(out TService service) {
            return WorkContext.TryResolve(out service);
    }
}
