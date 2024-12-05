using Orchard.ContentManagement;
using Orchard.Security;
using Orchard.UI.Admin;
using Orchard.DisplayManagement;
using Orchard.Localization;
using Orchard.Services;
using System.Web.Mvc;
using Orchard.Mvc.Filters;
﻿using NUnit.Framework;
using Orchard.Data.Bags;
using Orchard.Data.Bags.Serialization;
using System.Collections.Generic;
using System.IO;

namespace Orchard.Tests.Data.Bags {
    [TestFixture]
    public class BagsTests {
        [Test]
        public void ShouldRemoveMember() {
            dynamic e = new Bag();
            e.Foo = "Bar";
            Assert.That(e, Is.Not.Empty);
            Assert.That(e.Foo, Is.EqualTo("Bar"));
            e.Foo = null;
            Assert.That(e, Is.Empty);
        }
        public void ShouldSupportFactoryInvocation() {
            var e = Bag.New();
            Assert.That(e["Foo"], Is.EqualTo("Bar"));
        public void ShouldAddDynamicProperties() {
        public void UnknownPropertiesShouldBeNull() {
            Assert.That((object)e["Foo"], Is.EqualTo(null));
            Assert.That((object)e.Foo, Is.EqualTo(null));
        public void ShouldAddDynamicObjects() {
            e.Address = new Bag();
            
            e.Address.Street = "One Microsoft Way";
            Assert.That(e["Address"]["Street"], Is.EqualTo("One Microsoft Way"));
            Assert.That(e.Address.Street, Is.EqualTo("One Microsoft Way"));
        public void ShouldAddArraysOfAnonymousObject() {
            e.Foos = new[] { new { Foo1 = "Bar1", Foo2 = "Bar2" } };
            Assert.That(e.Foos[0].Foo1, Is.EqualTo("Bar1"));
            Assert.That(e.Foos[0].Foo2, Is.EqualTo("Bar2"));
        public void ShouldAddAnonymousObject() {
            e.Foos = new { Foo1 = "Bar1", Foo2 = "Bar2" };
            Assert.That(e.Foos.Foo1, Is.EqualTo("Bar1"));
            Assert.That(e.Foos.Foo2, Is.EqualTo("Bar2"));
        public void ShouldAddArrays() {
            e.Owners = new[] { "Steve", "Bill" };
            Assert.That(e.Owners[0], Is.EqualTo("Steve"));
            Assert.That(e.Owners[1], Is.EqualTo("Bill"));
        public void ShouldBeEnumerable() {
            // IEnumerable
            Assert.That(e, Has.Some.Matches<KeyValuePair<string, object>>(x => x.Key == "Address"));
            Assert.That(e, Has.Some.Matches<KeyValuePair<string, object>>(x => x.Key == "Owners"));
            Assert.That(e, Has.Some.Matches<KeyValuePair<string, object>>(x => x.Key == "Foos"));
        public void ShouldSerializeAndDeserialize() {
            string xml1;
            var serializer = new XmlSettingsSerializer();
            using (var sw = new StringWriter()) {
                serializer.Serialize(sw, e);
                xml1 = sw.ToString();
            }
            dynamic clone;
            using (var sr = new StringReader(xml1)) {
                clone = serializer.Deserialize(sr);
            string xml2;
                serializer.Serialize(sw, clone);
                xml2 = sw.ToString();
            Assert.That(xml1, Is.EqualTo(xml2));
        public void MergeShouldOverwriteExistingProperties() {
            var o1 = Bag.New();
            o1.Foo = "Foo1";
            o1.Bar = "Bar1";
            var o2 = Bag.New();
            o2.Foo = "Foo2";
            o2.Baz = "Baz2";
            var o3 = o1 & o2;
            Assert.That(o3.Foo, Is.EqualTo("Foo2"));
            Assert.That(o3.Bar, Is.EqualTo("Bar1"));
            Assert.That(o3.Baz, Is.EqualTo("Baz2"));
        public void MergeShouldConcatenateArrays() {
            o1.Foo = new[] { "a", "b" };
            o2.Foo = new[] { "c", "d" };
            Assert.That(o3.Foo[0], Is.EqualTo("a"));
            Assert.That(o3.Foo[1], Is.EqualTo("b"));
            Assert.That(o3.Foo[2], Is.EqualTo("c"));
            Assert.That(o3.Foo[3], Is.EqualTo("d"));
    }
}
