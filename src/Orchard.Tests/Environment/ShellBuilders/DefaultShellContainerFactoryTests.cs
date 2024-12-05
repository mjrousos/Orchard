using Orchard.ContentManagement;
using Orchard.Security;
using Orchard.UI.Admin;
using Orchard.DisplayManagement;
using Orchard.Localization;
using Orchard.Services;
using System.Web.Mvc;
using Orchard.Mvc.Filters;
﻿using System.Collections.Generic;
using System.Linq;
using System.Web.Http.Controllers;
using Autofac;
using Autofac.Core;
using Autofac.Core.Lifetime;
using Autofac.Features.Indexed;
using Autofac.Features.Metadata;
using Castle.DynamicProxy;
using NUnit.Framework;
using Orchard.Environment;
using Orchard.Environment.AutofacUtil.DynamicProxy2;
using Orchard.Environment.Configuration;
using Orchard.Environment.Extensions.Models;
using Orchard.Environment.ShellBuilders;
using Orchard.Environment.Descriptor.Models;
using Orchard.Environment.ShellBuilders.Models;
using Orchard.Events;

namespace Orchard.Tests.Environment.ShellBuilders {
    [TestFixture]
    public class DefaultShellContainerFactoryTests {
        private IContainer _container;
        [SetUp]
        public void Init() {
            var builder = new ContainerBuilder();
            builder.RegisterType<ShellContainerFactory>().As<IShellContainerFactory>();
            builder.RegisterType<ShellContainerRegistrations>().As<IShellContainerRegistrations>();
            builder.RegisterType<ComponentForHostContainer>();
            builder.RegisterType<ControllerActionInvoker>().As<IActionInvoker>();
            _container = builder.Build();
        }
        ShellSettings CreateSettings() {
            return new ShellSettings { Name = ShellSettings.DefaultName };
        ShellBlueprint CreateBlueprint(params ShellBlueprintItem[] items) {
            return new ShellBlueprint {
                Dependencies = items.OfType<DependencyBlueprint>(),
                Controllers = items.OfType<ControllerBlueprint>().Where(bp => typeof(IController).IsAssignableFrom(bp.Type)),
                HttpControllers = items.OfType<ControllerBlueprint>().Where(bp => typeof(IHttpController).IsAssignableFrom(bp.Type)),
                Records = items.OfType<RecordBlueprint>(),
            };
        DependencyBlueprint WithModule<T>() {
            return new DependencyBlueprint { Type = typeof(T), Parameters = Enumerable.Empty<ShellParameter>() };
        ControllerBlueprint WithController<T>(string areaName, string controllerName) {
            return new ControllerBlueprint { Type = typeof(T), AreaName = areaName, ControllerName = controllerName };
        DependencyBlueprint WithDependency<T>() {
        [Test]
        public void ShouldReturnChildLifetimeScopeNamedShell() {
            var settings = CreateSettings();
            var blueprint = CreateBlueprint();
            var factory = _container.Resolve<IShellContainerFactory>();
            var shellContainer = factory.CreateContainer(settings, blueprint);
            Assert.That(shellContainer.Tag, Is.EqualTo("shell"));
            var scope = (LifetimeScope)shellContainer;
            Assert.That(scope.RootLifetimeScope, Is.SameAs(_container.Resolve<ILifetimeScope>()));
            Assert.That(scope.RootLifetimeScope, Is.Not.SameAs(shellContainer.Resolve<ILifetimeScope>()));
        public void ControllersAreRegisteredAsKeyedServices() {
            var blueprint = CreateBlueprint(
                WithModule<TestModule>(),
                WithController<TestController>("foo", "bar"));
            var controllers = shellContainer.Resolve<IIndex<string, IController>>();
            var controller = controllers["foo/bar"];
            Assert.That(controller, Is.Not.Null);
            Assert.That(controller, Is.InstanceOf<TestController>());
        public class TestController : Controller {
        public void ModulesAreResolvedAndRegistered() {
            var controllerMetas = shellContainer.Resolve<IIndex<string, Meta<IController>>>();
            var metadata = controllerMetas["foo/bar"].Metadata;
            Assert.That(metadata["Hello"], Is.EqualTo("World"));
        public class TestModule : Module {
            protected override void AttachToComponentRegistration(IComponentRegistry componentRegistry, IComponentRegistration registration) {
                registration.Metadata["Hello"] = "World";
            }
        public void ModulesMayResolveHostServices() {
                WithModule<ModuleUsingThatComponent>());
            Assert.That(shellContainer.Resolve<string>(), Is.EqualTo("Module was loaded"));
        public class ComponentForHostContainer {
        public class ModuleUsingThatComponent : Module {
            private readonly ComponentForHostContainer _di;
            public ModuleUsingThatComponent(ComponentForHostContainer di) {
                _di = di;
            protected override void Load(ContainerBuilder builder) {
                builder.RegisterInstance("Module was loaded");
        public void DependenciesAreResolvable() {
                WithDependency<TestDependency>());
            var testDependency = shellContainer.Resolve<ITestDependency>();
            Assert.That(testDependency, Is.Not.Null);
            Assert.That(testDependency, Is.InstanceOf<TestDependency>());
        public interface ITestDependency : IDependency {
        public class TestDependency : ITestDependency {
        public void ComponentsImplementingMultipleContractsAreResolvableOnce() {
                WithDependency<MultipleDependency>()
            );
            var multipleDependency1 = shellContainer.Resolve<IMultipleDependency1>();
            var multipleDependency2 = shellContainer.Resolve<IMultipleDependency2>();
            Assert.That(multipleDependency1, Is.Not.Null);
            Assert.That(multipleDependency2, Is.Not.Null);
            Assert.That(multipleDependency1, Is.InstanceOf<MultipleDependency>());
            Assert.That(multipleDependency2, Is.InstanceOf<MultipleDependency>());
            Assert.True(multipleDependency1 == multipleDependency2);
        public interface IMultipleDependency1 : IDependency {
        public interface IMultipleDependency2 : IDependency {
        public class MultipleDependency : IMultipleDependency1, IMultipleDependency2 {
        public void ExtraInformationCanDropIntoProperties() {
                          WithDependency<TestDependency2>());
            blueprint.Dependencies.Single().Feature =
                new Feature { Descriptor = new FeatureDescriptor { Id = "Hello" } };
            Assert.That(testDependency, Is.InstanceOf<TestDependency2>());
            var testDependency2 = (TestDependency2)testDependency;
            
            Assert.That(testDependency2.Feature.Descriptor, Is.Not.Null);
            Assert.That(testDependency2.Feature.Descriptor.Id, Is.EqualTo("Hello"));
        public class TestDependency2 : ITestDependency {
            public Feature Feature { get; set; }
        public void ParametersMayOrMayNotBeUsedAsPropertiesAndConstructorParameters() {
                WithDependency<TestDependency3>());
            blueprint.Dependencies.Single().Parameters =
                new[] {
                          new ShellParameter {Name = "alpha", Value = "-a-"},
                          new ShellParameter {Name = "Beta", Value = "-b-"},
                          new ShellParameter {Name = "Gamma", Value = "-g-"},
                      };
            Assert.That(testDependency, Is.InstanceOf<TestDependency3>());
            var testDependency3 = (TestDependency3)testDependency;
            Assert.That(testDependency3.GetAlpha(), Is.EqualTo("-a-"));
            Assert.That(testDependency3.Beta, Is.EqualTo("-b-"));
            Assert.That(testDependency3.Delta, Is.EqualTo("y"));
        public class TestDependency3 : ITestDependency {
            private readonly string _alpha;
            public TestDependency3(string alpha) {
                _alpha = alpha;
                Beta = "x";
                Delta = "y";
            public string Beta { get; set; }
            public string Delta { get; set; }
            public string GetAlpha() {
                return _alpha;
        public void DynamicProxyIsInEffect() {
                WithModule<ProxModule>(),
                WithDependency<ProxDependency>());
            var testDependency = shellContainer.Resolve<IProxDependency>();
            Assert.That(testDependency.Hello(), Is.EqualTo("Foo"));
            var blueprint2 = CreateBlueprint(
            var shellContainer2 = factory.CreateContainer(settings, blueprint2);
            var testDependency2 = shellContainer2.Resolve<IProxDependency>();
            Assert.That(testDependency2.Hello(), Is.EqualTo("World"));
        public interface IProxDependency : IDependency {
            string Hello();
        public class ProxDependency : IProxDependency {
            public virtual string Hello() {
                return "World";
        public class ProxIntercept : IInterceptor {
            public void Intercept(IInvocation invocation) {
                invocation.ReturnValue = "Foo";
        public class ProxModule : Module {
                builder.RegisterType<ProxIntercept>();
                if (registration.Activator.LimitType == typeof(ProxDependency)) {
                    registration.InterceptedBy<ProxIntercept>();
                }
        public void DynamicProxyAndShellSettingsAreResolvableToSameInstances() {
            var proxa = shellContainer.Resolve<DynamicProxyContext>();
            var proxb = shellContainer.Resolve<DynamicProxyContext>();
            var setta = shellContainer.Resolve<ShellSettings>();
            var settb = shellContainer.Resolve<ShellSettings>();
            Assert.That(proxa, Is.Not.Null);
            Assert.That(proxa, Is.SameAs(proxb));
            Assert.That(setta, Is.Not.Null);
            Assert.That(setta, Is.SameAs(settb));
            var settings2 = CreateSettings();
            var blueprint2 = CreateBlueprint();
            var shellContainer2 = factory.CreateContainer(settings2, blueprint2);
            var proxa2 = shellContainer2.Resolve<DynamicProxyContext>();
            var proxb2 = shellContainer2.Resolve<DynamicProxyContext>();
            var setta2 = shellContainer2.Resolve<ShellSettings>();
            var settb2 = shellContainer2.Resolve<ShellSettings>();
            Assert.That(proxa2, Is.Not.Null);
            Assert.That(proxa2, Is.SameAs(proxb2));
            Assert.That(setta2, Is.Not.Null);
            Assert.That(setta2, Is.SameAs(settb2));
            Assert.That(proxa, Is.Not.SameAs(proxa2));
            Assert.That(setta, Is.Not.SameAs(setta2));
        public interface IStubEventHandlerA : IEventHandler { }
        public interface IStubEventHandlerB : IEventHandler { }
        public class StubEventHandler1 : IStubEventHandlerA { }
        public class StubEventHandler2 : IStubEventHandlerA { }
        public class StubEventHandler3 : IStubEventHandlerB { }
        public void EventHandlersAreNamedAndResolvedCorrectly() {
                WithDependency<StubEventHandler1>(),
                WithDependency<StubEventHandler2>(),
                WithDependency<StubEventHandler3>()
                );
            var eventHandlers = shellContainer.ResolveNamed<IEnumerable<IEventHandler>>(typeof(IStubEventHandlerA).Name).ToArray();
            Assert.That(eventHandlers, Is.Not.Null);
            Assert.That(eventHandlers.Count(), Is.EqualTo(2));
            Assert.That(eventHandlers[0], Is.InstanceOf<StubEventHandler2>());
            Assert.That(eventHandlers[1], Is.InstanceOf<StubEventHandler1>());
        public interface ITestDecorator : IDependency { ITestDecorator DecoratedService { get; } }
        public class TestDecoratorImpl1 : ITestDecorator { public ITestDecorator DecoratedService => null; }
        public class TestDecoratorImpl2 : ITestDecorator { public ITestDecorator DecoratedService => null; }
        public class TestDecoratorImpl3 : ITestDecorator { public ITestDecorator DecoratedService => null; }
        public class TestDecorator1 : IDecorator<ITestDecorator>, ITestDecorator {
            public TestDecorator1(ITestDecorator decoratedService) {
                DecoratedService = decoratedService;
            public ITestDecorator DecoratedService { get; }
        public class TestDecorator2 : IDecorator<ITestDecorator>, ITestDecorator {
            public TestDecorator2(ITestDecorator decoratedService) {
        public class TestDecorator3 : IDecorator<ITestDecorator>, ITestDecorator {
            public TestDecorator3(ITestDecorator decoratedService) {
        public void DecoratedComponentsAreResolvedToTheDecorator() {
                WithDependency<TestDecoratorImpl1>(),
                WithDependency<TestDecorator1>()
            var decorator = shellContainer.Resolve<ITestDecorator>();
            Assert.That(decorator, Is.Not.Null);
            Assert.That(decorator, Is.InstanceOf<TestDecorator1>());
            Assert.That(decorator.DecoratedService, Is.InstanceOf<TestDecoratorImpl1>());
        public void DecoratedComponentsAreResolvedToTheDecoratorWhenTheDecoratorIsRegisteredFirst() {
                WithDependency<TestDecorator1>(),
                WithDependency<TestDecoratorImpl1>()
        public void DecoratedComponentsAreNeverResolved() {
            var services = shellContainer.Resolve<IEnumerable<ITestDecorator>>();
            Assert.That(services, Is.Not.Null);
            Assert.That(services.Count(), Is.EqualTo(1));
            Assert.That(services.First(), Is.InstanceOf<TestDecorator1>());
            Assert.That(services.First().DecoratedService, Is.InstanceOf<TestDecoratorImpl1>());
        public void MultipleComponentsCanBeDecoratedWithASingleDecorator() {
                WithDependency<TestDecoratorImpl2>(),
                WithDependency<TestDecoratorImpl3>(),
            var services = shellContainer.Resolve<IEnumerable<ITestDecorator>>().ToArray();
            Assert.That(services.Count(), Is.EqualTo(3));
            foreach (var service in services)
            {
                Assert.That(service, Is.InstanceOf<TestDecorator1>());
            Assert.That(services[0].DecoratedService, Is.InstanceOf<TestDecoratorImpl1>());
            Assert.That(services[1].DecoratedService, Is.InstanceOf<TestDecoratorImpl2>());
            Assert.That(services[2].DecoratedService, Is.InstanceOf<TestDecoratorImpl3>());
        public void ASingleComponentCanBeDecoratedWithMultipleDecorators() {
                WithDependency<TestDecorator2>(),
                WithDependency<TestDecorator3>()
            var service = services[0];
            Assert.That(service, Is.InstanceOf<TestDecorator3>());
            Assert.That(service.DecoratedService, Is.InstanceOf<TestDecorator2>());
            Assert.That(service.DecoratedService.DecoratedService, Is.InstanceOf<TestDecorator1>());
            Assert.That(service.DecoratedService.DecoratedService.DecoratedService, Is.InstanceOf<TestDecoratorImpl1>());
        public void MultipleComponentsCanBeDecoratedWithMultipleDecorators() {
                    WithDependency<TestDecoratorImpl1>(),
                    WithDependency<TestDecoratorImpl2>(),
                    WithDependency<TestDecoratorImpl3>(),
                    WithDependency<TestDecorator1>(),
                    WithDependency<TestDecorator2>(),
                    WithDependency<TestDecorator3>()
                Assert.That(service, Is.InstanceOf<TestDecorator3>());
                Assert.That(service.DecoratedService, Is.InstanceOf<TestDecorator2>());
                Assert.That(service.DecoratedService.DecoratedService, Is.InstanceOf<TestDecorator1>());
            Assert.That(services[0].DecoratedService.DecoratedService.DecoratedService, Is.InstanceOf<TestDecoratorImpl1>());
            Assert.That(services[1].DecoratedService.DecoratedService.DecoratedService, Is.InstanceOf<TestDecoratorImpl2>());
            Assert.That(services[2].DecoratedService.DecoratedService.DecoratedService, Is.InstanceOf<TestDecoratorImpl3>());
        public void RegisteringDecoratorsWithoutConcreteThrowsFatalException() {
            Assert.Throws<OrchardFatalException>(delegate {
                factory.CreateContainer(settings, blueprint);
            });
    }
}
