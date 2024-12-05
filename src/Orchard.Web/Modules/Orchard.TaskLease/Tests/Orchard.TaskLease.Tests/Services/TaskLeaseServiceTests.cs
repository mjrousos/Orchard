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
using Autofac;
using Moq;
using NUnit.Framework;
using Orchard.TaskLease.Models;
using Orchard.TaskLease.Services;
using Orchard.Tests.Modules;

namespace Orchard.TaskLease.Tests.Services
{
    [TestFixture]
    public class TaskLeaseServiceTests : DatabaseEnabledTestsBase
    {
        private ITaskLeaseService _service;
        private Mock<IMachineNameProvider> _machineNameProvider;
        protected override IEnumerable<Type> DatabaseTypes
        {
            get
            {
                return new[] {
                    typeof (TaskLeaseRecord)
                };
            }
        }
        public override void Register(ContainerBuilder builder)
            builder.RegisterType<TaskLeaseService>().As<ITaskLeaseService>();
            builder.RegisterInstance((_machineNameProvider = new Mock<IMachineNameProvider>()).Object);
            _machineNameProvider.Setup(x => x.GetMachineName()).Returns("SkyNet");
        public override void Init()
            base.Init();
            _service = _container.Resolve<ITaskLeaseService>();
        [Test]
        public void AcquireShouldSucceedIfNoTask()
            var state = _service.Acquire("Foo", _clock.UtcNow.AddDays(1));
            Assert.That(state, Is.EqualTo(String.Empty));
        public void AcquireShouldSucceedIfTaskBySameMachine()
            state = _service.Acquire("Foo", _clock.UtcNow.AddDays(1));
        public void AcquireShouldNotSucceedIfTaskByOtherMachine()
            _machineNameProvider.Setup(x => x.GetMachineName()).Returns("TheMatrix");
            Assert.That(state, Is.EqualTo(null));
        public void ShouldUpdateTask()
            _service.Update("Foo", "Other");
            Assert.That(state, Is.EqualTo("Other"));
        public void AcquireShouldSucceedIfTaskByOtherMachineAndExpired()
            _clock.Advance(new TimeSpan(2,0,0,0));
    }
}
