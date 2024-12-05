using Orchard.ContentManagement;
using Orchard.Security;
using Orchard.UI.Admin;
using Orchard.DisplayManagement;
using Orchard.Localization;
using Orchard.Services;
using System.Web.Mvc;
using Orchard.Mvc.Filters;
﻿using NUnit.Framework;
using Orchard.Mvc.Routes;

namespace Orchard.Tests.Mvc.Routes {
    [TestFixture]
    public class UrlPrefixTests {
        [Test]
        public void RemoveLeadingSegmentsOnlyMatchesFullSegment() {
            var prefix = new UrlPrefix("foo");
            Assert.That(prefix.RemoveLeadingSegments("~/foo/bar"), Is.EqualTo("~/bar"));
            Assert.That(prefix.RemoveLeadingSegments("~/fooo/bar"), Is.EqualTo("~/fooo/bar"));
            Assert.That(prefix.RemoveLeadingSegments("~/fo/bar"), Is.EqualTo("~/fo/bar"));
        }
        public void RemoveLeadingSegmentsMayContainSlash() {
            var prefix = new UrlPrefix("foo/quux");
            Assert.That(prefix.RemoveLeadingSegments("~/foo/quux/bar"), Is.EqualTo("~/bar"));
            Assert.That(prefix.RemoveLeadingSegments("~/foo/bar"), Is.EqualTo("~/foo/bar"));
            Assert.That(prefix.RemoveLeadingSegments("~/quux/bar"), Is.EqualTo("~/quux/bar"));
        public void RemoveLeadingSegmentsCanMatchEntireUrl() {
            Assert.That(prefix.RemoveLeadingSegments("~/foo/"), Is.EqualTo("~/"));
            Assert.That(prefix.RemoveLeadingSegments("~/foo"), Is.EqualTo("~/"));
        public void RemoveLeadingSegmentsIsCaseInsensitive() {
            var prefix = new UrlPrefix("Foo");
            Assert.That(prefix.RemoveLeadingSegments("~/FOO/BAR"), Is.EqualTo("~/BAR"));
        public void RemoveLeadingSegmentsIgnoreLeadingAndTrailingCharactersOnInput() {
            var prefix2 = new UrlPrefix("~/foo");
            Assert.That(prefix2.RemoveLeadingSegments("~/foo/bar"), Is.EqualTo("~/bar"));
            var prefix3 = new UrlPrefix("foo/");
            Assert.That(prefix3.RemoveLeadingSegments("~/foo/bar"), Is.EqualTo("~/bar"));
        public void PrependLeadingSegmentsInsertsBeforeNormalVirtualPath() {
            Assert.That(prefix.PrependLeadingSegments("~/bar"), Is.EqualTo("~/foo/bar"));
        public void PrependLeadingSegmentsPreservesNatureOfIncomingPath() {
            Assert.That(prefix.PrependLeadingSegments("/bar"), Is.EqualTo("/foo/bar"));
            Assert.That(prefix.PrependLeadingSegments("bar"), Is.EqualTo("foo/bar"));
        public void PrependLeadingSegmentsHandlesShortUrlConditionsAppropriately() {
            Assert.That(prefix.PrependLeadingSegments("~/"), Is.EqualTo("~/foo/"));
            Assert.That(prefix.PrependLeadingSegments("/"), Is.EqualTo("/foo/"));
            Assert.That(prefix.PrependLeadingSegments("~"), Is.EqualTo("~/foo/"));
            Assert.That(prefix.PrependLeadingSegments(""), Is.EqualTo("foo/"));
    }
}
