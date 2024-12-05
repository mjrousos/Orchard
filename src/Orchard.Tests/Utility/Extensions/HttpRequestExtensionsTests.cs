using Orchard.ContentManagement;
using Orchard.Security;
using Orchard.UI.Admin;
using Orchard.DisplayManagement;
using Orchard.Localization;
using Orchard.Services;
using System.Web.Mvc;
using Orchard.Mvc.Filters;
﻿using System.Collections.Specialized;
using System.Web;
using NUnit.Framework;
using Orchard.Utility.Extensions;

namespace Orchard.Tests.Utility.Extensions {
    [TestFixture]
    public class HttpRequestExtensionsTests {
        [Test]
        public void IsLocalUrlShouldReturnFalseWhenUrlIsNullOrEmpty() {
            var request = new StubHttpRequest();
            Assert.That(request.IsLocalUrl(null), Is.False);
            Assert.That(request.IsLocalUrl("   "), Is.False);
            Assert.That(request.IsLocalUrl(""), Is.False);
        }
        public void IsLocalUrlShouldReturnFalseWhenUrlStartsWithDoubleSlash() {
            Assert.That(request.IsLocalUrl("//"), Is.False);
            Assert.That(request.IsLocalUrl("  //"), Is.False);
        public void IsLocalUrlShouldReturnFalseWhenUrlStartsWithForwardBackwardSlash() {
            Assert.That(request.IsLocalUrl("/\\"), Is.False);
            Assert.That(request.IsLocalUrl(" /\\"), Is.False);
        public void IsLocalUrlShouldReturnTrueWhenUrlStartsWithSlashAndAnythingElse() {
            Assert.That(request.IsLocalUrl("/"), Is.True);
            Assert.That(request.IsLocalUrl("\t/"), Is.True);
            Assert.That(request.IsLocalUrl("/контакты"), Is.True);
            Assert.That(request.IsLocalUrl("/  "), Is.True);
            Assert.That(request.IsLocalUrl("/abc-def"), Is.True);
        public void IsLocalUrlShouldReturnTrueWhenAuthoritiesMatch() {
            request.Headers.Add("Host", "localhost");
            Assert.That(request.IsLocalUrl("http://localhost"), Is.True);
            Assert.That(request.IsLocalUrl("https://localhost"), Is.True);
        public void IsLocalUrlShouldReturnFalseForNonHttpSchemes() {
            Assert.That(request.IsLocalUrl("httpx://localhost"), Is.False);
            Assert.That(request.IsLocalUrl("foo://localhost"), Is.False);
            Assert.That(request.IsLocalUrl("data://localhost"), Is.False);
            Assert.That(request.IsLocalUrl("mailto://localhost"), Is.False);
        public void IsLocalUrlShouldReturnFalseWhenAuthoritiesDiffer() {
            Assert.That(request.IsLocalUrl("http://somedomain"), Is.False);
            Assert.That(request.IsLocalUrl("http://localhost:8080"), Is.False);
        public void IsLocalUrlShouldReturnFalseForEverythingElse() {
            Assert.That(request.IsLocalUrl("abc"), Is.False);
    }
    class StubHttpRequest : HttpRequestBase {
        private readonly NameValueCollection _headers = new NameValueCollection();
        public override NameValueCollection Headers {
            get {
                return _headers;
            }
}
