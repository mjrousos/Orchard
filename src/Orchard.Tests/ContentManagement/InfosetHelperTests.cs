using Orchard.ContentManagement;
using Orchard.Security;
using Orchard.UI.Admin;
using Orchard.DisplayManagement;
using Orchard.Localization;
using Orchard.Services;
using System.Web.Mvc;
using Orchard.Mvc.Filters;
﻿using NUnit.Framework;
using Orchard.ContentManagement.FieldStorage.InfosetStorage;
using Orchard.ContentManagement.Records;

namespace Orchard.Tests.ContentManagement {
    public class InfosetHelperTests {
        [Test]
        public void StoreByNameSavesIntoInfoset() {
            var part = new TestPart();
            ContentHelpers.PreparePart(part, "Test");
            part.Foo = 42;
            var infosetXml = part.As<InfosetPart>().Infoset.Element;
            var testPartElement = infosetXml.Element(typeof (TestPart).Name);
            Assert.That(testPartElement, Is.Not.Null);
            var fooAttribute = testPartElement.Attr<int>("Foo");
            Assert.That(part.Foo, Is.EqualTo(42));
            Assert.That(fooAttribute, Is.EqualTo(42));
        }
        public void RetrieveSavesIntoInfoset() {
            var part = new TestPartWithRecord();
            ContentHelpers.PreparePart<TestPartWithRecord, TestPartWithRecordRecord>(part, "Test");
            part.Record.Foo = 42;
            var testPartElement = infosetXml.Element(typeof (TestPartWithRecord).Name);
            Assert.That(testPartElement, Is.Null);
            var foo = part.Foo;
            testPartElement = infosetXml.Element(typeof(TestPartWithRecord).Name);
            Assert.That(foo, Is.EqualTo(42));
        public class TestPart : ContentPart {
            public int Foo {
                get { return this.Retrieve<int>("Foo"); }
                set { this.Store("Foo", value); }
            }
        public class TestPartWithRecordRecord : ContentPartRecord {
            public virtual int Foo { get; set; }
        public class TestPartWithRecord : ContentPart<TestPartWithRecordRecord> {
                get { return Retrieve(r => r.Foo); }
                set { Store(r => r.Foo, value); }
    }
}
