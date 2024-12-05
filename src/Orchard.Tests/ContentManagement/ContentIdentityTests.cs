using Orchard.ContentManagement;
using Orchard.Security;
using Orchard.UI.Admin;
using Orchard.DisplayManagement;
using Orchard.Localization;
using Orchard.Services;
using System.Web.Mvc;
using Orchard.Mvc.Filters;
﻿using System;
using NUnit.Framework;

namespace Orchard.Tests.ContentManagement {
    [TestFixture]
    public class ContentIdentityTests {
        [Test]
        public void ContentIdentityParsesIdentities() {
            var identity1 = new ContentIdentity("/foo=bar");
            Assert.That(identity1.Get("foo"), Is.EqualTo("bar"));
            var identity2 = new ContentIdentity("/foo=");
            Assert.That(identity2.Get("foo"), Is.EqualTo(String.Empty));
            var identity3 = new ContentIdentity("foo");
            Assert.That(identity3.Get("foo"), Is.Null);
        }
        public void ContentIdentitiesAreEncodedWhenOutput() {
            Assert.That(identity1.ToString(), Is.EqualTo("/foo=bar"));
            var identity2 = new ContentIdentity(@"/foo=bar/abaz=quux\/fr\\ed=foo/yarg=yiu=foo");
            Assert.That(identity2.Get("foo"), Is.EqualTo("bar"));
            Assert.That(identity2.Get("abaz"), Is.EqualTo(@"quux/fr\ed=foo"));
            Assert.That(identity2.Get("yarg"), Is.EqualTo("yiu=foo"));
            Assert.That(identity2.ToString(), Is.EqualTo(@"/abaz=quux\/fr\\ed=foo/foo=bar/yarg=yiu=foo"));
        public void ContentIdentitiesWithKeysAddedInDifferentOrderAreEqual() {
            var comparer = new ContentIdentity.ContentIdentityEqualityComparer();
            Assert.That(comparer.Equals(identity1, new ContentIdentity(identity1.ToString())));
            Assert.That(comparer.Equals(identity2, new ContentIdentity(identity2.ToString())));
        public void ContentIdentityCanSeePartialMatchesAreEquivalent() {
            var identity1 = new ContentIdentity("/bar=baz/a=b");
            var identity2 = new ContentIdentity(@"/foo=bar/bar=baz/glop=glop");
            Assert.That(ContentIdentity.ContentIdentityEqualityComparer.AreEquivalent(identity1, identity2));
            Assert.That(ContentIdentity.ContentIdentityEqualityComparer.AreEquivalent(identity2, identity1));
        public void ContentIdentityCanSeeFullMatchesAreEquivalent() {
            var identity1 = new ContentIdentity(@"/foo=bar/bar=baz/glop=glop");
        public void ContentIdentityCanSeeNonMatchesAreNotEquivalent() {
            var identity1 = new ContentIdentity(@"/a=b/foo=baz");
            Assert.IsFalse(ContentIdentity.ContentIdentityEqualityComparer.AreEquivalent(identity1, identity2));
            Assert.IsFalse(ContentIdentity.ContentIdentityEqualityComparer.AreEquivalent(identity2, identity1));
    }
}
