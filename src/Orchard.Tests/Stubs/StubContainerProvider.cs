using Orchard.ContentManagement;
using Orchard.Security;
using Orchard.UI.Admin;
using Orchard.DisplayManagement;
using Orchard.Localization;
using Orchard.Services;
using System.Web.Mvc;
using Orchard.Mvc.Filters;
using Autofac;
using Autofac.Integration.Web;

namespace Orchard.Tests.Stubs {
    public class StubContainerProvider : IContainerProvider {
        public StubContainerProvider(IContainer applicationContainer, ILifetimeScope requestContainer) {
            ApplicationContainer = applicationContainer;
            RequestLifetime = requestContainer;
        }
        public void EndRequestLifetime() {
            RequestLifetime.Dispose();
        public ILifetimeScope ApplicationContainer { get; set; }
        public ILifetimeScope RequestLifetime { get; set; }
    }
}
