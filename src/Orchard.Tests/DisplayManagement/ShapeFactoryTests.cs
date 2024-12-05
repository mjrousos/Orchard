using Orchard.ContentManagement;
using Orchard.Security;
using Orchard.UI.Admin;
using Orchard.DisplayManagement;
using Orchard.Localization;
using Orchard.Services;
using System.Web.Mvc;
using Orchard.Mvc.Filters;
﻿using System.Collections.Generic;
using Autofac;
using NUnit.Framework;
using Orchard.Caching;
using Orchard.DisplayManagement.Descriptors;
using Orchard.DisplayManagement.Implementation;
using Orchard.DisplayManagement.Shapes;
using Orchard.Environment.Extensions;
using Orchard.Tests.Stubs;

namespace Orchard.Tests.DisplayManagement {
    [TestFixture]
    public class ShapeFactoryTests {
        private IContainer _container;
        [SetUp]
        public void Init() {
            var builder = new ContainerBuilder();
            builder.RegisterType<DefaultShapeFactory>().As<IShapeFactory>();
            builder.RegisterInstance(new Orchard.Environment.Work<IEnumerable<IShapeTableEventHandler>>(resolve => _container.Resolve<IEnumerable<IShapeTableEventHandler>>())).AsSelf();
            builder.RegisterType<DefaultShapeTableManager>().As<IShapeTableManager>();
            builder.RegisterType<ShapeTableLocator>().As<IShapeTableLocator>();
            builder.RegisterType<StubExtensionManager>().As<IExtensionManager>();
            builder.RegisterType<StubCacheManager>().As<ICacheManager>();
            builder.RegisterType<StubParallelCacheContext>().As<IParallelCacheContext>();
            _container = builder.Build();
        }
        
        [Test]
        public void ShapeHasAttributesType() {
            var factory = _container.Resolve<IShapeFactory>();
            dynamic foo = factory.Create("Foo", ArgsUtility.Empty());
            ShapeMetadata metadata = foo.Metadata;
            Assert.That(metadata.Type, Is.EqualTo("Foo"));
        public void CreateShapeWithNamedArguments() {
            dynamic foo = factory.Create("Foo", ArgsUtility.Named(new { one = 1, two = "dos" }));
            Assert.That(foo.one, Is.EqualTo(1));
            Assert.That(foo.two, Is.EqualTo("dos"));
        public void CallSyntax() {
            dynamic factory = _container.Resolve<IShapeFactory>();
            var foo = factory.Foo();
        public void CallInitializer() {
            var bar = new {One = 1, Two = "two"};
            var foo = factory.Foo(bar);
            Assert.That(foo.One, Is.EqualTo(1));
            Assert.That(foo.Two, Is.EqualTo("two"));
        public void CallInitializerWithBaseType() {
            var bar = new { One = 1, Two = "two" };
            var foo = factory.Foo(typeof(MyShape), bar);
            Assert.That(foo, Is.InstanceOf<MyShape>());
        public class MyShape : Shape {
            public string Kind { get; set; }
    }
}
