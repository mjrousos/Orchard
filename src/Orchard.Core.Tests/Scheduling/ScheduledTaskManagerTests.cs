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
using System.Linq;
using Autofac;
using Moq;
using NUnit.Framework;
using Orchard.Caching;
using Orchard.ContentManagement.MetaData;
using Orchard.ContentManagement.Records;
using Orchard.Core.Scheduling.Models;
using Orchard.Core.Scheduling.Services;
using Orchard.Data;
using Orchard.DisplayManagement.Descriptors;
using Orchard.DisplayManagement.Implementation;
using Orchard.Environment.Extensions;
using Orchard.Tasks.Scheduling;
using Orchard.Tests.Modules;
using Orchard.Tests.Stubs;
using Orchard.UI.PageClass;

namespace Orchard.Core.Tests.Scheduling {
    [TestFixture]
    public class ScheduledTaskManagerTests : DatabaseEnabledTestsBase {
        private IRepository<ScheduledTaskRecord> _repository;
        private IScheduledTaskManager _scheduledTaskManager;
        private IContentManager _contentManager;
        private Mock<IOrchardServices> _mockServices;
        public override void Init() {
            _mockServices = new Mock<IOrchardServices>();
            base.Init();
            _repository = _container.Resolve<IRepository<ScheduledTaskRecord>>();
            _scheduledTaskManager = _container.Resolve<IScheduledTaskManager>();
            _contentManager = _container.Resolve<IContentManager>();
            _mockServices.SetupGet(x => x.ContentManager).Returns(_contentManager);
        }
        public override void Register(ContainerBuilder builder) {
            builder.RegisterInstance(_mockServices.Object);
            builder.RegisterType<DefaultContentManager>().As<IContentManager>();
            builder.RegisterType<Signals>().As<ISignals>();
            builder.RegisterType<StubCacheManager>().As<ICacheManager>();
            builder.RegisterType<DefaultContentManagerSession>().As<IContentManagerSession>();
            builder.RegisterType<DefaultShapeTableManager>().As<IShapeTableManager>();
            builder.RegisterType<ShapeTableLocator>().As<IShapeTableLocator>();
            builder.RegisterType<DefaultShapeFactory>().As<IShapeFactory>();
            builder.RegisterInstance(new Mock<IContentDefinitionManager>().Object);
            builder.RegisterInstance(new Mock<IContentDisplay>().Object);
            builder.RegisterType<ScheduledTaskManager>().As<IScheduledTaskManager>();
            builder.RegisterType<StubExtensionManager>().As<IExtensionManager>();
            builder.RegisterInstance(new Mock<IPageClassBuilder>().Object); 
            builder.RegisterType<DefaultContentDisplay>().As<IContentDisplay>();
        protected override IEnumerable<Type> DatabaseTypes {
            get {
                return new[] {
                                 typeof(ContentTypeRecord), 
                                 typeof(ContentItemRecord), 
                                 typeof(ContentItemVersionRecord), 
                                 typeof(ScheduledTaskRecord),
                             };
            }
        [Test]
        public void TestFixtureShouldBeAbleToCreateContentItem() {
            var hello = _contentManager.New("hello");
            _contentManager.Create(hello);
            _session.Flush();
            _session.Clear();
            var hello2 = _contentManager.Get(hello.Id);
            Assert.That(hello2, Is.Not.Null);
            Assert.That(hello2.Record, Is.Not.SameAs(hello.Record));
            Assert.That(hello2.Id, Is.EqualTo(hello.Id));
        public void TaskManagerShouldCreateTaskRecordsWithOrWithoutContentItem() {
            _scheduledTaskManager.CreateTask("Ignore", _clock.UtcNow.AddHours(1), null);
            _scheduledTaskManager.CreateTask("Ignore", _clock.UtcNow.AddHours(2), hello);
            var tasks = _repository.Fetch(x => x != null);
            Assert.That(tasks.Count(), Is.EqualTo(2));
            Assert.That(tasks, Has.All.Property("TaskType").EqualTo("Ignore"));
            var noContentItemTask = tasks.Single(x => x.ContentItemVersionRecord == null);
            Assert.That(noContentItemTask.ScheduledUtc, Is.EqualTo(_clock.UtcNow.AddHours(1)));
            Assert.That(noContentItemTask.ContentItemVersionRecord, Is.Null);
            var hasContentItemTask = tasks.Single(x => x.ContentItemVersionRecord != null);
            Assert.That(hasContentItemTask.ContentItemVersionRecord.ContentItemRecord.Id, Is.EqualTo(hello.Id));
            Assert.That(hasContentItemTask.ContentItemVersionRecord.Id, Is.EqualTo(hello.VersionRecord.Id));
        public void TasksForAllVersionsOfContenItemShouldBeReturned() {
            var hello1 = _contentManager.New("hello");
            _contentManager.Create(hello1);
            var hello2 = _contentManager.GetDraftRequired(hello1.Id);
            Assert.That(hello1.Version, Is.EqualTo(1));
            Assert.That(hello2.Version, Is.EqualTo(2));
            _scheduledTaskManager.CreateTask("First", _clock.UtcNow.AddHours(1), hello1);
            _scheduledTaskManager.CreateTask("Second", _clock.UtcNow.AddHours(2), hello2);
            _scheduledTaskManager.CreateTask("Third", _clock.UtcNow.AddHours(3), null);
            var hello = _contentManager.Get(hello1.Id);
            var tasks = _scheduledTaskManager.GetTasks(hello);
            var firstTask = tasks.Single(x => x.TaskType == "First");
            Assert.That(firstTask.ContentItem.Version, Is.EqualTo(1));
            var secondTask = tasks.Single(x => x.TaskType == "Second");
            Assert.That(secondTask.ContentItem.Version, Is.EqualTo(2));
        public void ShouldGetTasksByType() {
            _scheduledTaskManager.CreateTask("First", _clock.UtcNow, null);
            _scheduledTaskManager.CreateTask("Second", _clock.UtcNow, null);
            _scheduledTaskManager.CreateTask("Third", _clock.UtcNow, null);
            Assert.That(_scheduledTaskManager.GetTasks("First").Count(), Is.EqualTo(3));
            Assert.That(_scheduledTaskManager.GetTasks("Second").Count(), Is.EqualTo(2));
            Assert.That(_scheduledTaskManager.GetTasks("Third").Count(), Is.EqualTo(1));
            Assert.That(_scheduledTaskManager.GetTasks("Fourth").Count(), Is.EqualTo(0));
        public void ShouldGetTasksByTypeAndScheduledDate() {
            _scheduledTaskManager.CreateTask("First", _clock.UtcNow.AddHours(1), null);
            _scheduledTaskManager.CreateTask("First", _clock.UtcNow.AddHours(2), null);
            Assert.That(_scheduledTaskManager.GetTasks("Foo", _clock.UtcNow.AddHours(5)).Count(), Is.EqualTo(0));
            Assert.That(_scheduledTaskManager.GetTasks("First", _clock.UtcNow.AddMinutes(-1)).Count(), Is.EqualTo(0));
            Assert.That(_scheduledTaskManager.GetTasks("First", _clock.UtcNow.AddMinutes(1)).Count(), Is.EqualTo(1));
            Assert.That(_scheduledTaskManager.GetTasks("First", _clock.UtcNow.AddHours(1)).Count(), Is.EqualTo(2));
            Assert.That(_scheduledTaskManager.GetTasks("First", _clock.UtcNow.AddHours(2)).Count(), Is.EqualTo(3));
    }
}
