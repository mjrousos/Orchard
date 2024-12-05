using Orchard.ContentManagement;
using Orchard.Security;
using Orchard.UI.Admin;
using Orchard.DisplayManagement;
using Orchard.Localization;
using Orchard.Services;
using System.Web.Mvc;
using Orchard.Mvc.Filters;
﻿using System.ComponentModel.DataAnnotations;
using System.Linq;
using Autofac;
using Moq;
using NUnit.Framework;
using Orchard.ContentManagement.Drivers;
using Orchard.ContentManagement.Drivers.Coordinators;
using Orchard.ContentManagement.Handlers;
using Orchard.ContentManagement.MetaData;
using Orchard.DisplayManagement.Implementation;

namespace Orchard.Tests.ContentManagement.Handlers.Coordinators {
    [TestFixture]
    public class ContentPartDriverCoordinatorTests {
        private IContainer _container;
        [SetUp]
        public void Init() {
            var builder = new ContainerBuilder();
            //builder.RegisterModule(new ImplicitCollectionSupportModule());
            builder.RegisterType<ContentPartDriverCoordinator>().As<IContentHandler>();
            builder.RegisterType<DefaultShapeFactory>().As<IShapeFactory>();
            builder.RegisterInstance(new Mock<IContentDefinitionManager>().Object);
            _container = builder.Build();
        }
        [Test]
        public void DriverHandlerShouldNotThrowException() {
            var contentHandler = _container.Resolve<IContentHandler>();
            contentHandler.BuildDisplay(null);
        public void AllDriversShouldBeCalled() {
            var driver1 = new Mock<IContentPartDriver>();
            var driver2 = new Mock<IContentPartDriver>();
            builder.RegisterInstance(driver1.Object);
            builder.RegisterInstance(driver2.Object);
            builder.Update(_container);
            var contentItem = new ContentItem();
            var context = new BuildDisplayContext(null, contentItem, "", "", new Mock<IShapeFactory>().Object);
            driver1.Verify(x => x.BuildDisplay(context), Times.Never());
            driver2.Verify(x => x.BuildDisplay(context), Times.Never());
            contentHandler.BuildDisplay(context);
            driver1.Verify(x => x.BuildDisplay(context));
            driver2.Verify(x => x.BuildDisplay(context));
        [Test, Ignore("no implementation for IZoneCollection")]
        public void TestDriverCanAddDisplay() {
            var driver = new StubPartDriver();
            builder.RegisterInstance(driver).As<IContentPartDriver>();
            dynamic shapeFactory = _container.Resolve<IShapeFactory>();
            contentItem.Weld(new StubPart { Foo = new[] { "a", "b", "c" } });
            var ctx = new BuildDisplayContext(null, null, "", "", null);
            var context = shapeFactory.Context(ctx);
            Assert.That(context.TopMeta, Is.Null);
            contentHandler.BuildDisplay(ctx);
            Assert.That(context.TopMeta, Is.Not.Null);
            Assert.That(context.TopMeta.Count == 1);
        public class StubPartDriver : ContentPartDriver<StubPart> {
            protected override string Prefix {
                get { return "Stub"; }
            }
            protected override DriverResult Display(StubPart part, string displayType, dynamic shapeHelper) {
                var stub = shapeHelper.Stub(Foo: string.Join(",", part.Foo));
                if (!string.IsNullOrWhiteSpace(displayType))
                    stub.Metadata.Type = string.Format("{0}.{1}", stub.Metadata.Type, displayType);
                return ContentShape(stub).Location("TopMeta");
                
                //var viewModel = new StubViewModel { Foo = string.Join(",", part.Foo) };
                //if (displayType.StartsWith("Summary"))
                //    return ContentPartTemplate(viewModel, "StubViewModelTerse").Location("TopMeta");
                //return ContentPartTemplate(viewModel).Location("TopMeta");
            protected override DriverResult Editor(StubPart part, dynamic shapeHelper) {
                var viewModel = new StubViewModel { Foo = string.Join(",", part.Foo) };
                return new ContentTemplateResult(viewModel, null, Prefix).Location("last", "10");
            protected override DriverResult Editor(StubPart part, IUpdateModel updater, dynamic shapeHelper) {
                updater.TryUpdateModel(viewModel, Prefix, null, null);
                part.Foo = viewModel.Foo.Split(new[] { ',' }).Select(x => x.Trim()).ToArray();
        public class StubPart : ContentPart {
            public string[] Foo { get; set; }
        public class StubViewModel {
            [Required]
            public string Foo { get; set; }
    }
}
