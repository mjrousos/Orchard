using Orchard.ContentManagement;
using Orchard.Security;
using Orchard.UI.Admin;
using Orchard.DisplayManagement;
using Orchard.Localization;
using Orchard.Services;
using System.Web.Mvc;
using Orchard.Mvc.Filters;
﻿using System;
using System.Collections.Generic;
using System.Web;
using Autofac;
using Autofac.Integration.Web;
using NUnit.Framework;
using Orchard.DisplayManagement.Descriptors;
using Orchard.DisplayManagement.Implementation;
using Orchard.DisplayManagement.Shapes;
using Orchard.Environment.Extensions.Models;
using Orchard.Mvc;
using Orchard.Tests.Stubs;

namespace Orchard.Tests.DisplayManagement {
    [TestFixture]
    public class DefaultDisplayManagerTests : ContainerTestBase {
        ShapeTable _defaultShapeTable;
        WorkContext _workContext;
        protected override void Register(Autofac.ContainerBuilder builder) {
            _defaultShapeTable = new ShapeTable {
                Descriptors = new Dictionary<string, ShapeDescriptor>(StringComparer.OrdinalIgnoreCase),
                Bindings = new Dictionary<string, ShapeBinding>(StringComparer.OrdinalIgnoreCase)
            };
            _workContext = new TestWorkContext {
                CurrentTheme = new ExtensionDescriptor { Id = "Hello" }
            builder.RegisterType<StubHttpContextAccessor>().As<IHttpContextAccessor>();
            builder.RegisterType<DefaultDisplayManager>().As<IDisplayManager>();
            builder.RegisterType<TestShapeTableManager>().As<IShapeTableManager>();
            builder.RegisterType<ShapeTableLocator>().As<IShapeTableLocator>();
            builder.RegisterType<TestWorkContextAccessor>().As<IWorkContextAccessor>();
            builder.RegisterType<TestDisplayEvents>().As<IShapeDisplayEvents>()
                .As<TestDisplayEvents>()
                .InstancePerLifetimeScope();
            builder.Register(ctx => _defaultShapeTable);
            builder.Register(ctx => _workContext);
        }
        class TestDisplayEvents : IShapeDisplayEvents {
            public Action<ShapeDisplayingContext> Displaying = ctx => { };
            public Action<ShapeDisplayedContext> Displayed = ctx => { };
            void IShapeDisplayEvents.Displaying(ShapeDisplayingContext context) { Displaying(context); }
            void IShapeDisplayEvents.Displayed(ShapeDisplayedContext context) { Displayed(context); }
        public class TestShapeTableManager : IShapeTableManager {
            private readonly ShapeTable _defaultShapeTable;
            public TestShapeTableManager(ShapeTable defaultShapeTable) {
                _defaultShapeTable = defaultShapeTable;
            }
            public ShapeTable GetShapeTable(string themeName) {
                return _defaultShapeTable;
        public class TestWorkContextAccessor : IWorkContextAccessor {
            private readonly WorkContext _workContext;
            public TestWorkContextAccessor(WorkContext workContext) {
                _workContext = workContext;
            public WorkContext GetContext(HttpContextBase httpContext) {
                return _workContext;
            public IWorkContextScope CreateWorkContextScope(HttpContextBase httpContext) {
                throw new NotImplementedException();
            public WorkContext GetContext() {
            public IWorkContextScope CreateWorkContextScope() {
        public class TestWorkContext : WorkContext {
            readonly IDictionary<string, object> _state = new Dictionary<string, object>();
            public IContainerProvider ContainerProvider { get; set; }
            public override T Resolve<T>() {
                if (typeof(T) == typeof(ILifetimeScope)) {
                    return (T)ContainerProvider.RequestLifetime;
                }
            public override object Resolve(Type serviceType) {
            public override bool TryResolve<T>(out T service) {
            public override bool TryResolve(Type serviceType, out object service) {
            public override T GetState<T>(string name) {
                object value;
                return _state.TryGetValue(name, out value) ? (T)value : default(T);
            public override void SetState<T>(string name, T value) {
                _state[name] = value;
        void AddShapeDescriptor(ShapeDescriptor shapeDescriptor) {
            _defaultShapeTable.Descriptors[shapeDescriptor.ShapeType] = shapeDescriptor;
            foreach (var binding in shapeDescriptor.Bindings) {
                binding.Value.ShapeDescriptor = shapeDescriptor;
                _defaultShapeTable.Bindings[binding.Key] = binding.Value;
        static DisplayContext CreateDisplayContext(Shape shape) {
            return new DisplayContext {
                Value = shape,
                ViewContext = new ViewContext()
        [Test]
        public void RenderSimpleShape() {
            var displayManager = _container.Resolve<IDisplayManager>();
            var shape = new Shape {
                Metadata = new ShapeMetadata {
                    Type = "Foo"
            var descriptor = new ShapeDescriptor {
                ShapeType = "Foo",
            descriptor.Bindings["Foo"] = new ShapeBinding {
                BindingName = "Foo",
                Binding = ctx => new HtmlString("Hi there!"),
            AddShapeDescriptor(descriptor);
            var result = displayManager.Execute(CreateDisplayContext(shape));
            Assert.That(result.ToString(), Is.EqualTo("Hi there!"));
        public void RenderPreCalculatedShape() {
            shape.Metadata.OnDisplaying(
                context => {
                    context.ChildContent = new HtmlString("Bar");
                });
            Assert.That(result.ToString(), Is.EqualTo("Bar"));
        public void RenderFallbackShape() {
                    Type = "Foo__2"
        public void RenderAlternateShapeExplicitly() {
            descriptor.Bindings["Foo__2"] = new ShapeBinding {
                BindingName = "Foo__2",
                Binding = ctx => new HtmlString("Hello again!"),
            Assert.That(result.ToString(), Is.EqualTo("Hello again!"));
        public void RenderAlternateShapeByMostRecentlyAddedMatchingAlternate() {
            shape.Metadata.Alternates.Add("Foo__1");
            shape.Metadata.Alternates.Add("Foo__2");
            shape.Metadata.Alternates.Add("Foo__3");
            AddBinding(descriptor, "Foo", ctx => new HtmlString("Hi there!"));
            AddBinding(descriptor, "Foo__1", ctx => new HtmlString("Hello (1)!"));
            AddBinding(descriptor, "Foo__2", ctx => new HtmlString("Hello (2)!"));
            Assert.That(result.ToString(), Is.EqualTo("Hello (2)!"));
        private static void AddBinding(ShapeDescriptor descriptor, string bindingName, Func<DisplayContext, IHtmlString> binding) {
            descriptor.Bindings[bindingName] = new ShapeBinding {
                BindingName = bindingName,
                Binding = binding,
        public void IShapeDisplayEventsIsCalled() {
            AddBinding(descriptor, "Foo", ctx => new HtmlString("yarg"));
            var displayingEventCount = 0;
            var displayedEventCount = 0;
            _container.Resolve<TestDisplayEvents>().Displaying = ctx => { ++displayingEventCount; };
            _container.Resolve<TestDisplayEvents>().Displayed = ctx => { ++displayedEventCount; ctx.ChildContent = new HtmlString("[" + ctx.ChildContent.ToHtmlString() + "]"); };
            Assert.That(displayingEventCount, Is.EqualTo(1));
            Assert.That(displayedEventCount, Is.EqualTo(1));
            Assert.That(result.ToString(), Is.EqualTo("[yarg]"));
        public void ShapeDescriptorDisplayingAndDisplayedAreCalled() {
            descriptor.Displaying = new Action<ShapeDisplayingContext>[] { ctx => { ++displayingEventCount; } };
            descriptor.Displayed = new Action<ShapeDisplayedContext>[] { ctx => { ++displayedEventCount; ctx.ChildContent = new HtmlString("[" + ctx.ChildContent.ToHtmlString() + "]"); } };
        public void DisplayingEventFiresEarlyEnoughToAddAlternateShapeBindingNames() {
            var shapeFoo = new Shape {
            var descriptorFoo = new ShapeDescriptor {
            AddBinding(descriptorFoo, "Foo", ctx => new HtmlString("alpha"));
            AddShapeDescriptor(descriptorFoo);
            var descriptorBar = new ShapeDescriptor {
                ShapeType = "Bar",
            AddBinding(descriptorBar, "Bar", ctx => new HtmlString("beta"));
            AddShapeDescriptor(descriptorBar);
            var resultNormally = displayManager.Execute(CreateDisplayContext(shapeFoo));
            descriptorFoo.Displaying = new Action<ShapeDisplayingContext>[] { ctx => ctx.ShapeMetadata.Alternates.Add("Bar") };
            var resultWithOverride = displayManager.Execute(CreateDisplayContext(shapeFoo));
            Assert.That(resultNormally.ToString(), Is.EqualTo("alpha"));
            Assert.That(resultWithOverride.ToString(), Is.EqualTo("beta"));
        public void ShapeTypeAndBindingNamesAreNotCaseSensitive() {
                    Type = "foo"
            var result = displayManager.Execute(CreateDisplayContext(shapeFoo));
            Assert.That(result.ToString(), Is.EqualTo("alpha"));            
    }
}
