using Orchard.ContentManagement;
using Orchard.Security;
using Orchard.UI.Admin;
using Orchard.DisplayManagement;
using Orchard.Localization;
using Orchard.Services;
using System.Web.Mvc;
using Orchard.Mvc.Filters;
﻿using System.Linq;
using System.Xml.Linq;
using NUnit.Framework;
using Orchard.ContentManagement.MetaData;
using Orchard.ContentManagement.MetaData.Builders;
using Orchard.ContentManagement.MetaData.Services;

namespace Orchard.Tests.ContentManagement.MetaData.Services {
    [TestFixture]
    public class ContentDefinitionReaderTests {
        private IContentDefinitionReader _reader;
        [SetUp]
        public void Init() {
            _reader = new ContentDefinitionReader(new SettingsFormatter());
        }
        [Test]
        public void ReadingElementSetsName() {
            var builder = new ContentTypeDefinitionBuilder();
            _reader.Merge(new XElement("foo"), builder);
            var type = builder.Build();
            Assert.That(type.Name, Is.EqualTo("foo"));
        public void AttributesAreAppliedAsSettings() {
            _reader.Merge(new XElement("foo", new XAttribute("x", "1")), builder);
            Assert.That(type.Settings["x"], Is.EqualTo("1"));
        public void ChildElementsAreAddedAsPartsWithSettings() {
            _reader.Merge(new XElement("foo", new XElement("bar", new XAttribute("y", "2"))), builder);
            Assert.That(type.Parts.Single().PartDefinition.Name, Is.EqualTo("bar"));
            Assert.That(type.Parts.Single().Settings["y"], Is.EqualTo("2"));
        public void PartsCanBeRemovedByNameWhenImporting() {
            const string partToBeRemoved = "alpha";
            _reader.Merge(new XElement("foo", 
                new XElement(partToBeRemoved),
                new XElement("remove", new XAttribute("name", partToBeRemoved))
                ), builder);
            Assert.That(type.Parts.FirstOrDefault(part => part.PartDefinition.Name == partToBeRemoved), Is.Null);
    }
}
