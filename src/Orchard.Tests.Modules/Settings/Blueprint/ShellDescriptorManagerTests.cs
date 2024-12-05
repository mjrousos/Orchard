using Orchard.ContentManagement;
using Orchard.Security;
using Orchard.UI.Admin;
using Orchard.DisplayManagement;
using Orchard.Localization;
using Orchard.Services;
using System.Web.Mvc;
using Orchard.Mvc.Filters;
﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Autofac;
using NUnit.Framework;
using Orchard.Core.Settings.State;
using Orchard.Core.Settings.Descriptor;
using Orchard.Core.Settings.Descriptor.Records;
using Orchard.Environment.Configuration;
using Orchard.Environment.State;
using Orchard.Environment.Descriptor;
using Orchard.Environment.Descriptor.Models;
using Orchard.Events;
using Orchard.Caching;
using Orchard.Core.Settings.State.Records;
using Orchard.Locking;

namespace Orchard.Tests.Modules.Settings.Blueprint {
    [TestFixture]
    public class ShellDescriptorManagerTests : DatabaseEnabledTestsBase {
        public override void Register(ContainerBuilder builder) {
            builder.RegisterInstance(new ShellSettings { Name = "Default" });
            builder.RegisterModule(new CacheModule());
            builder.RegisterType<DefaultCacheManager>().As<ICacheManager>();
            builder.RegisterType<DefaultCacheHolder>().As<ICacheHolder>().SingleInstance();
            builder.RegisterType<DefaultCacheContextAccessor>().As<ICacheContextAccessor>();
            builder.RegisterType<LockingProvider>().As<ILockingProvider>();
            builder.RegisterType<Signals>().As<ISignals>().SingleInstance();
            builder.RegisterType<ShellDescriptorManager>().As<IShellDescriptorManager>().SingleInstance();
            builder.RegisterType<ShellStateManager>().As<IShellStateManager>().SingleInstance();
            builder.RegisterType<StubEventBus>().As<IEventBus>().SingleInstance();
            builder.RegisterSource(new EventsRegistrationSource());
        }
        public class StubEventBus : IEventBus {
            public string LastMessageName { get; set; }
            public IDictionary<string, object> LastEventData { get; set; }
            public IEnumerable Notify(string messageName, IDictionary<string, object> eventData) {
                LastMessageName = messageName;
                LastEventData = eventData;
                return new object[0];
            }
        protected override IEnumerable<Type> DatabaseTypes {
            get {
                return new[] {
                                typeof (ShellStateRecord),
                                typeof (ShellFeatureStateRecord),
                                 typeof (ShellDescriptorRecord),
                                 typeof (ShellFeatureRecord),
                                 typeof (ShellParameterRecord),
                             };
        [Test]
        public void BlueprintShouldBeNullWhenItsNotInitialized() {
            var manager = _container.Resolve<IShellDescriptorManager>();
            var descriptor = manager.GetShellDescriptor();
            Assert.That(descriptor, Is.Null);
        public void PriorSerialNumberOfZeroIsAcceptableForInitialUpdateAndSerialNumberIsNonzeroAfterwards() {
            manager.UpdateShellDescriptor(
                0,
                Enumerable.Empty<ShellFeature>(),
                Enumerable.Empty<ShellParameter>());
            Assert.That(descriptor, Is.Not.Null);
            Assert.That(descriptor.SerialNumber, Is.Not.EqualTo(0));
        public void NonZeroInitialUpdateThrowsInvalidOperationException() {
            Assert.Throws<InvalidOperationException>(() => manager.UpdateShellDescriptor(
                1,
                Enumerable.Empty<ShellParameter>()));
        public void OnlyCorrectSerialNumberOnLaterUpdatesDoesNotThrowException() {
                                               0,
                                               Enumerable.Empty<ShellFeature>(),
                                               Enumerable.Empty<ShellParameter>()));
                                               descriptor.SerialNumber + 665321,
                descriptor.SerialNumber,
            var descriptor2 = manager.GetShellDescriptor();
            Assert.That(descriptor2.SerialNumber, Is.Not.EqualTo(0));
            Assert.That(descriptor2.SerialNumber, Is.Not.EqualTo(descriptor.SerialNumber));
                                               descriptor.SerialNumber,
                descriptor2.SerialNumber,
                                               descriptor2.SerialNumber,
        public void SuccessfulUpdateRaisesAnEvent() {
            var eventBus = _container.Resolve<IEventBus>() as StubEventBus;
            Assert.That(eventBus.LastMessageName, Is.Null);
                                               5,
            Assert.That(eventBus.LastMessageName, Is.EqualTo("IShellDescriptorManagerEventHandler.Changed"));
        public void ManagerReturnsStateForFeaturesInDescriptor() {
            var descriptorManager = _container.Resolve<IShellDescriptorManager>();
            var stateManager = _container.Resolve<IShellStateManager>();
            var state = stateManager.GetShellState();
            Assert.That(state.Features.Count(), Is.EqualTo(0));
            descriptorManager.UpdateShellDescriptor(
                0, 
                new[]{new ShellFeature{ Name="Foo"}},
            var state2 = stateManager.GetShellState();
            Assert.That(state2.Features.Count(), Is.EqualTo(1));
            Assert.That(state2.Features, Has.Some.Property("Name").EqualTo("Foo"));
    }
}
