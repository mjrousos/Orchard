using Orchard.ContentManagement;
using Orchard.Security;
using Orchard.UI.Admin;
using Orchard.DisplayManagement;
using Orchard.Localization;
using Orchard.Services;
using System.Web.Mvc;
using Orchard.Mvc.Filters;
﻿using System;
using System.Linq;
using System.Threading;
using System.Web.Routing;
using Autofac;
using NUnit.Framework;
using Orchard.Environment;
using Orchard.Environment.Configuration;
using Orchard.Mvc.Routes;
using Orchard.Tests.Utility;

namespace Orchard.Tests.Mvc {
    [TestFixture]
    public class RouteCollectionPublisherTests {
        private IContainer _container;
        private RouteCollection _routes;
        static RouteDescriptor Desc(string name, string url) {
            return new RouteDescriptor { Name = name, Route = new Route(url, new MvcRouteHandler()) };
        }
        [SetUp]
        public void Init() {
            _routes = new RouteCollection();
            var builder = new ContainerBuilder();
            builder.RegisterType<RoutePublisher>().As<IRoutePublisher>();
            builder.RegisterType<ShellRoute>().InstancePerDependency();
            builder.Register(ctx => _routes);
            builder.Register(ctx => new ShellSettings { Name = ShellSettings.DefaultName });
            builder.RegisterAutoMocking();
            _container = builder.Build();
        [Test]
        public void RoutesCanHaveNullOrEmptyNames() {
            _routes.MapRoute("foo", "{controller}");
            var publisher = _container.Resolve<IRoutePublisher>();
            publisher.Publish(new[] { Desc(null, "bar"), Desc(string.Empty, "quux") });
            Assert.That(_routes.Count(), Is.EqualTo(3));
        [ExpectedException(typeof(ArgumentException))]
        public void SameNameTwiceCausesExplosion() {
            publisher.Publish(new[] { Desc("yarg", "bar"), Desc("yarg", "quux") });
            Assert.That(_routes.Count(), Is.EqualTo(2));
        public void ExplosionLeavesOriginalRoutesIntact() {
            try {
                publisher.Publish(new[] { Desc("yarg", "bar"), Desc("yarg", "quux") });
            }
            catch (ArgumentException) {
                Assert.That(_routes.Count(), Is.EqualTo(1));
                Assert.That(_routes.OfType<Route>().Single().Url, Is.EqualTo("{controller}"));
        public void WriteBlocksWhileReadIsInEffect() {
            var readLock = _routes.GetReadLock();
            string where = "init";
            var action = new Action(() => {
                where = "before";
                publisher.Publish(new[] { Desc("barname", "bar"), Desc("quuxname", "quux") });
                where = "after";
            });
            Assert.That(where, Is.EqualTo("init"));
            var asyncResult = action.BeginInvoke(null, null);
            Thread.Sleep(75);
            Assert.That(where, Is.EqualTo("before"));
            readLock.Dispose();
            Assert.That(where, Is.EqualTo("after"));
            action.EndInvoke(asyncResult);
        public void RouteDescriptorWithNameCreatesNamedRouteInCollection() {
            var routeDescriptor = Desc("yarg", "bar");
            publisher.Publish(new[] { routeDescriptor });
            Assert.That(_routes["yarg"], Is.Not.Null);
    }
}
