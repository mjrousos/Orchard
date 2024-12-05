using Orchard.ContentManagement;
using Orchard.Security;
using Orchard.UI.Admin;
using Orchard.DisplayManagement;
using Orchard.Localization;
using Orchard.Services;
using System.Web.Mvc;
using Orchard.Mvc.Filters;
﻿using NUnit.Framework;
using Orchard.Core.Common.Services;

namespace Orchard.Core.Tests.Common {
    [TestFixture]
    public class BbcodeFilterTests {
        private readonly BbcodeFilter _filter = new BbcodeFilter();
        [Test]
        public void ShouldIgnoreText() {
            const string text = "foo bar baz";
            var processed = _filter.ProcessContent(text, null);
            Assert.That(processed, Is.EqualTo(text));
        }
        public void ShouldReplaceUrl() {
            const string text = "foo [url]bar[/url] baz";
            Assert.That(processed, Is.EqualTo("foo <a href=\"bar\">bar</a> baz"));
        public void ShouldReplaceImg() {
            const string text = "foo [img]bar[/img] baz";
            Assert.That(processed, Is.EqualTo("foo <img src=\"bar\" /> baz"));
        public void ShouldReplaceUrlWithTitle() {
            const string text = "foo [url=alink]bar[/url] baz";
            Assert.That(processed, Is.EqualTo("foo <a href=\"alink\">bar</a> baz"));
        public void ShouldIgnoreMalformedUrl() {
            const string text = "foo [url]bar baz";
            Assert.That(processed, Is.EqualTo("foo [url]bar baz"));
        public void ShouldIgnoreMalformedUrlWithTitle() {
            const string text = "foo [url=alink]bar baz";
            Assert.That(processed, Is.EqualTo("foo [url=alink]bar baz"));
        public void ShouldIgnoreMalformedImg() {
            const string text = "foo [img]bar baz";
            Assert.That(processed, Is.EqualTo("foo [img]bar baz"));
    }
}
