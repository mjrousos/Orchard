using Orchard.ContentManagement;
using Orchard.Security;
using Orchard.UI.Admin;
using Orchard.DisplayManagement;
using Orchard.Localization;
using Orchard.Services;
using System.Web.Mvc;
using Orchard.Mvc.Filters;
﻿using System;
using Autofac;
using Autofac.Core;
using Autofac.Features.Metadata;
using Castle.DynamicProxy;
using NUnit.Framework;
using Orchard.Environment.AutofacUtil.DynamicProxy2;

namespace Orchard.Tests.Environment.AutofacUtil.DynamicProxy2 {
    [TestFixture]
    public class DynamicProxyTests {
        [Test]
        public void ContextAddedToMetadataWhenRegistered() {
            var context = new DynamicProxyContext();
            var builder = new ContainerBuilder();
            builder.RegisterType<SimpleComponent>().EnableDynamicProxy(context);
            var container = builder.Build();
            var meta = container.Resolve<Meta<SimpleComponent>>();
            Assert.That(meta.Metadata, Has.Some.Property("Key").EqualTo("Orchard.Environment.AutofacUtil.DynamicProxy2.DynamicProxyContext.ProxyContextKey"));
            Assert.That(meta.Metadata["Orchard.Environment.AutofacUtil.DynamicProxy2.DynamicProxyContext.ProxyContextKey"], Is.SameAs(context));
        }
        public void ProxyContextReturnsTrueIfTypeHasBeenProxied() {
            Type proxyType;
            Assert.That(context.TryGetProxy(typeof(SimpleComponent), out proxyType), Is.False);
            Assert.That(proxyType, Is.Null);
            context.AddProxy(typeof(SimpleComponent));
            Assert.That(context.TryGetProxy(typeof(SimpleComponent), out proxyType), Is.True);
            Assert.That(proxyType, Is.Not.Null);
        public void AddProxyCanBeCalledMoreThanOnce() {
            Type proxyType2;
            Assert.That(context.TryGetProxy(typeof(SimpleComponent), out proxyType2), Is.True);
            Assert.That(proxyType2, Is.SameAs(proxyType));
        public void InterceptorAddedToContextFromModules() {
            builder.RegisterModule(new SimpleInterceptorModule());
            builder.Build();
        public void ResolvedObjectIsSubclass() {
            var simpleComponent = container.Resolve<SimpleComponent>();
            Assert.That(simpleComponent, Is.InstanceOf<SimpleComponent>());
            Assert.That(simpleComponent, Is.Not.TypeOf<SimpleComponent>());
        public void InterceptorCatchesMethodCallOnlyFromContainerWithInterceptor() {
            var builder1 = new ContainerBuilder();
            builder1.RegisterType<SimpleComponent>().EnableDynamicProxy(context);
            builder1.RegisterModule(new SimpleInterceptorModule());
            var container1 = builder1.Build();
            var simple1 = container1.Resolve<SimpleComponent>();
            var builder2 = new ContainerBuilder();
            builder2.RegisterType<SimpleComponent>().EnableDynamicProxy(context);
            var container2 = builder2.Build();
            var simple2 = container2.Resolve<SimpleComponent>();
            Assert.That(simple2.SimpleMethod(), Is.EqualTo("default return value"));
            Assert.That(simple1.SimpleMethod(), Is.EqualTo("different return value"));
    }
    public class SimpleComponent {
        public virtual string SimpleMethod() {
            return "default return value";
    public class SimpleInterceptorModule : Module {
        protected override void Load(ContainerBuilder builder) {
            builder.RegisterType<SimpleInterceptor>();
            base.Load(builder);
        protected override void AttachToComponentRegistration(
            IComponentRegistry componentRegistry,
            IComponentRegistration registration) {
            if (DynamicProxyContext.From(registration) != null)
                registration.InterceptedBy<SimpleInterceptor>();
    public class SimpleInterceptor : IInterceptor {
        public void Intercept(IInvocation invocation) {
            if (invocation.Method.Name == "SimpleMethod") {
                invocation.ReturnValue = "different return value";
            }
            else {
                invocation.Proceed();
}
