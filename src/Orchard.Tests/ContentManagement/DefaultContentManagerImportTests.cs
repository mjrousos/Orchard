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
using System.Xml.Linq;
using Autofac;
using Moq;
using NUnit.Framework;
using Orchard.Caching;
using Orchard.ContentManagement.Drivers;
using Orchard.ContentManagement.Drivers.Coordinators;
using Orchard.ContentManagement.Handlers;
using Orchard.ContentManagement.MetaData;
using Orchard.ContentManagement.Records;
using Orchard.Core.Common.Drivers;
using Orchard.Core.Common.Handlers;
using Orchard.Core.Common.Models;
using Orchard.Core.Common.Services;
using Orchard.Core.Title.Drivers;
using Orchard.Core.Title.Handlers;
using Orchard.Core.Title.Models;
using Orchard.Tests.ContentManagement.Handlers;
using Orchard.Tests.Stubs;

namespace Orchard.Tests.ContentManagement {
    [TestFixture]
    public class DefaultContentManagerImportTests : DatabaseEnabledTestsBase {
        private const string ContentTypeName = "Dummy";
        private IContentManager _contentManager;
        protected override IEnumerable<Type> DatabaseTypes {
            get {
                return new[] {
                    typeof (ContentTypeRecord),
                    typeof (ContentItemRecord),
                    typeof (ContentItemVersionRecord),
                    typeof (TitlePartRecord),
                    typeof (IdentityPartRecord)
                };
            }
        }
        public override void Register(ContainerBuilder builder) {
            builder.RegisterType<IdentifierResolverSelector>().As<IIdentityResolverSelector>();
            builder.RegisterType<DummyHandler>().As<IContentHandler>();
            builder.RegisterType<IdentityPartDriver>().As<IContentPartDriver>();
            builder.RegisterType<IdentityPartHandler>().As<IContentHandler>();
            builder.RegisterType<ContentPartDriverCoordinator>().As<IContentHandler>();
            builder.RegisterType<TitlePartHandler>().As<IContentHandler>();
            builder.RegisterType<TitlePartDriver>().As<IContentPartDriver>();
            builder.RegisterType<DefaultContentQuery>().As<IContentQuery>();
            builder.RegisterType<DefaultContentManager>().As<IContentManager>();
            builder.RegisterType<StubCacheManager>().As<ICacheManager>();
            builder.RegisterType<Signals>().As<ISignals>();
            builder.RegisterType<DefaultContentManagerSession>().As<IContentManagerSession>();
            builder.RegisterType<DefaultContentDisplay>().As<IContentDisplay>();
            builder.RegisterInstance(new Mock<IContentDefinitionManager>().Object);
        public override void Init() {
            base.Init();
            _contentManager = _container.Resolve<IContentManager>();
        [Test]
        public void ImportingDraftShouldCreateNewDraft() {
            // Create a draft element and import it.
            var element = CreateContentElement(version: "Draft");
            Import(element);
            // Assert that we have the one draft.
            var allContentItems = _contentManager.Query(VersionOptions.Latest).List().ToList();
            Assert.That(allContentItems.Count, Is.EqualTo(1));
            Assert.That(allContentItems[0].IsPublished(), Is.False);
            // Assert that the draft has been created with the imported values.
            var item = _contentManager.Get(allContentItems[0].Id, VersionOptions.Latest);
            Assert.That(item.As<TitlePart>().Title, Is.EqualTo("Dummy"));
        public void ImportingPublishedShouldCreateNewPublished() {
            // Create a published element and import it.
            var element = CreateContentElement(version: "Published");
            // Assert that we have the one published item.
            Assert.That(allContentItems[0].IsPublished(), Is.True);
            // Assert that the published item has been created with the imported values.
        public void ImportingDraftShouldUpdateExistingDraft() {
            // Create a draft and an export of it.
            var contentItem = _contentManager.New(ContentTypeName);
            contentItem.As<TitlePart>().Title = "Dummy";
            _contentManager.Create(contentItem, VersionOptions.Draft);
            var element = _contentManager.Export(contentItem);
            
            // Change the title and then import the element.
            element.Element("TitlePart").Attr("Title", "Smarty");
            // Assert that we still have the one draft.
            var updatedContentItem = allContentItems[0];
            Assert.That(updatedContentItem.As<IdentityPart>().Identifier, Is.EqualTo(contentItem.As<IdentityPart>().Identifier));
            // Assert that the draft has been updated with the imported change.
            Assert.That(updatedContentItem.As<TitlePart>().Title, Is.EqualTo("Smarty"));
        public void ImportingDraftShouldCreateNewDraftForExistingPublished() {
            contentItem.As<TitlePart>().Title = "Draft Dummy";
            // Change the title and publish the draft.
            contentItem.As<TitlePart>().Title = "Published Dummy";
            _contentManager.Publish(contentItem);
            // Import the element representing the draft.
            // Assert that version one is still the published one but no more the latest.
            var published = _contentManager.Get(contentItem.Id, VersionOptions.Number(1));
            Assert.That(published.VersionRecord.Published, Is.True);
            Assert.That(published.VersionRecord.Latest, Is.False);
            Assert.That(published.As<TitlePart>().Title, Is.EqualTo("Published Dummy"));
            // Assert that a new draft was created for the published item.
            var latest = _contentManager.Get(contentItem.Id, VersionOptions.Number(2));
            Assert.That(latest.VersionRecord.Published, Is.False);
            Assert.That(latest.VersionRecord.Latest, Is.True);
            Assert.That(latest.As<TitlePart>().Title, Is.EqualTo("Draft Dummy"));
        public void ImportingPublishedShouldUpdateAndPublishExistingDraft() {
            element.Element("TitlePart").Attr("Title", "Published Dummy");
            element.Attr("Status", "Published");
            // Import the element representing the published version.
            // Assert that no additional version was created.
            var allVersions = _contentManager.GetAllVersions(contentItem.Id).ToList();
            Assert.That(allVersions.Count, Is.EqualTo(1));
            // Assert that the item has been updated and published.
            Assert.That(published.VersionRecord.Latest, Is.True);
        public void ImportingPublishedShouldUpdateAndPublishExistingPublishedItem() {
            // Create a published item and an export of it.
            _contentManager.Create(contentItem, VersionOptions.Published);
            // Change the title and publish the item.
            element.Element("TitlePart").Attr("Title", "Published Smarty");
            // Import the element representing the updated published version.
            // Assert that an additional version was created.
            Assert.That(allVersions.Count, Is.EqualTo(2));
            // Assert that no additional item was created.
            var allItems = _contentManager.Query(VersionOptions.Latest).List().ToList();
            Assert.That(allItems.Count, Is.EqualTo(1));
            var published = _contentManager.Get(contentItem.Id, VersionOptions.Number(2));
            Assert.That(published.As<TitlePart>().Title, Is.EqualTo("Published Smarty"));
        private void Import(XElement element) {
            var importContentSession = new ImportContentSession(_contentManager);
            _contentManager.Import(element, importContentSession);
            _contentManager.CompleteImport(element, importContentSession);
        private XElement CreateContentElement(string title = "Dummy", string identity = "123456789012345678901234567890ab", string version = null) {
            var identifier = "/Identifier=" + identity;
            var element =
                new XElement("Dummy",
                    version != null ? new XAttribute("Status", version) : default(XAttribute),
                    new XAttribute("Id", identifier),
                    new XElement("IdentityPart",
                        new XAttribute("Identifier", identity)),
                    new XElement("TitlePart",
                        new XAttribute("Title", title)));
            return element;
    }
}
