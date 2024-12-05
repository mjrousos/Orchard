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
using System.Text;
using NUnit.Framework;
using Orchard.ContentManagement.MetaData.Models;

namespace Orchard.Tests.ContentManagement {
    [TestFixture]
    public class DynamicContentItemTests {
        [Test]
        public void ContentItemProjectsPartNamesAsProperties() {
            var contentItem = new ContentItem();
            var testingPart = new ContentPart { TypePartDefinition = new ContentTypePartDefinition(new ContentPartDefinition("TestingPart"), new SettingsDictionary()) };
            contentItem.Weld(testingPart);
            dynamic contentItemDynamic = contentItem;
            dynamic testingPartDynamic  = contentItemDynamic.TestingPart;
            Assert.That((object)testingPartDynamic, Is.SameAs(testingPart));
        }
        
        public void ContentPartsAlsoProjectPartNamesAsProperties() {
            var anotherPart = new ContentPart { TypePartDefinition = new ContentTypePartDefinition(new ContentPartDefinition("AnotherPart"), new SettingsDictionary()) };
            contentItem.Weld(anotherPart);
            dynamic anotherPartDynamic  = contentItemDynamic.AnotherPart;
            dynamic testingPartDynamic2  = testingPartDynamic.TestingPart;
            dynamic anotherPartDynamic2  = testingPartDynamic.AnotherPart;
            Assert.That((object)anotherPartDynamic, Is.SameAs(anotherPart));
            Assert.That((object)testingPartDynamic2, Is.SameAs(testingPart));
            Assert.That((object)anotherPartDynamic2, Is.SameAs(anotherPart));
        public void ContentItemPropertyOnPartRootsYou() {
            dynamic contentItemDynamic1  = testingPartDynamic.ContentItem;
            dynamic contentItemDynamic2  = anotherPartDynamic.ContentItem;
            Assert.That((object)contentItemDynamic1, Is.SameAs(contentItem));
            Assert.That((object)contentItemDynamic2, Is.SameAs(contentItem));
        public void ActualPropertiesTakePriority() {
            var testingPart = new ContentPart { TypePartDefinition = new ContentTypePartDefinition(new ContentPartDefinition("Parts"), new SettingsDictionary()) };
            dynamic testingPartDynamic  = contentItemDynamic.Parts;
            Assert.That((object)testingPartDynamic, Is.AssignableTo<IEnumerable<ContentPart>>());
        public void NullCheckingCanBeDoneOnProperties() {
            var contentPart = new ContentPart { TypePartDefinition = new ContentTypePartDefinition(new ContentPartDefinition("FooPart"), new SettingsDictionary()) };
            var contentField = new ContentField { PartFieldDefinition = new ContentPartFieldDefinition(new ContentFieldDefinition("FooType"), "FooField", new SettingsDictionary()) };
            dynamic item = contentItem;
            dynamic part = contentPart;
            Assert.That(item.FooPart == null, Is.True);
            Assert.That(item.FooPart != null, Is.False);
            contentItem.Weld(contentPart);
            Assert.That(item.FooPart == null, Is.False);
            Assert.That(item.FooPart != null, Is.True);
            Assert.That(item.FooPart, Is.SameAs(contentPart));
            Assert.That(part.FooField == null, Is.True);
            Assert.That(part.FooField != null, Is.False);
            Assert.That(item.FooPart.FooField == null, Is.True);
            Assert.That(item.FooPart.FooField != null, Is.False);
            contentPart.Weld(contentField);
            Assert.That(part.FooField == null, Is.False);
            Assert.That(part.FooField != null, Is.True);
            Assert.That(item.FooPart.FooField == null, Is.False);
            Assert.That(item.FooPart.FooField != null, Is.True);
            Assert.That(part.FooField, Is.SameAs(contentField));
            Assert.That(item.FooPart.FooField, Is.SameAs(contentField));
    }
}
