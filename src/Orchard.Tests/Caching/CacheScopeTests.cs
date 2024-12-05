using Orchard.ContentManagement;
using Orchard.Security;
using Orchard.UI.Admin;
using Orchard.DisplayManagement;
using Orchard.Localization;
using Orchard.Services;
using System.Web.Mvc;
using Orchard.Mvc.Filters;
﻿using NUnit.Framework;
using Orchard.Caching;
using Orchard.Environment;
using Autofac;
using Orchard.FileSystems.AppData;
using Orchard.FileSystems.WebSite;

namespace Orchard.Tests.Caching {
    [TestFixture]
    public class CacheScopeTests {
        private IContainer _hostContainer;
        [SetUp]
        public void Init() {
            _hostContainer = OrchardStarter.CreateHostContainer(builder => {
                builder.RegisterType<Alpha>().InstancePerDependency();
            });
        }
        public class Alpha {
            public ICacheManager CacheManager { get; set; }
            public Alpha(ICacheManager cacheManager) {
                CacheManager = cacheManager;
            }
        [Test]
        public void ComponentsAtHostLevelHaveAccessToCache() {
            var alpha = _hostContainer.Resolve<Alpha>();
            Assert.That(alpha.CacheManager, Is.Not.Null);
        public void HostLevelHasAccessToGlobalVolatileProviders() {
            Assert.That(_hostContainer.Resolve<IWebSiteFolder>(), Is.Not.Null);
            Assert.That(_hostContainer.Resolve<IAppDataFolder>(), Is.Not.Null);
            Assert.That(_hostContainer.Resolve<IClock>(), Is.Not.Null);
    }
}
