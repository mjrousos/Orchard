using Orchard.ContentManagement;
using Orchard.Security;
using Orchard.UI.Admin;
using Orchard.DisplayManagement;
using Orchard.Localization;
using Orchard.Services;
using System.Web.Mvc;
using Orchard.Mvc.Filters;
﻿using Autofac;
using NUnit.Framework;

namespace Orchard.Tests {
    public class ContainerTestBase {
        protected IContainer _container;
        [SetUp]
        public virtual void Init() {
            var builder = new ContainerBuilder();
            Register(builder);
            _container = builder.Build();
            Resolve(_container);
        }
        [TearDown]
        public void Cleanup() {
            if (_container != null)
                _container.Dispose();
#if false
        // technically more accurate, and doesn't work
            var hostBuilder = new ContainerBuilder();
            var hostContainer = hostBuilder.Build();
            var shellContainer = hostContainer.BeginLifetimeScope("shell", shellBuilder => Register(shellBuilder));
            var workContainer = shellContainer.BeginLifetimeScope("work");
            _container = workContainer;
#endif
        protected virtual void Register(ContainerBuilder builder) { }
        protected virtual void Resolve(ILifetimeScope container) { }
    }
}
