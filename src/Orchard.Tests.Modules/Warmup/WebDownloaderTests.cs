using Orchard.ContentManagement;
using Orchard.Security;
using Orchard.UI.Admin;
using Orchard.DisplayManagement;
using Orchard.Localization;
using Orchard.Services;
using System.Web.Mvc;
using Orchard.Mvc.Filters;
﻿using System;
using System.Net;
using NUnit.Framework;
using Orchard.Warmup.Services;

namespace Orchard.Tests.Modules.Warmup {
    public class WebDownloaderTests {
        private readonly IWebDownloader _webDownloader = new WebDownloader();
        [Test]
        public void ShouldReturnNullWhenUrlIsEmpty() {
            Assert.That(_webDownloader.Download(null), Is.Null);
            Assert.That(_webDownloader.Download(""), Is.Null);
            Assert.That(_webDownloader.Download(" "), Is.Null);
        }
        public void ShouldReturnNullWhenUrlIsInvalid() {
            Assert.That(_webDownloader.Download("froutfrout|yepyep"), Is.Null);
        public void StatusCodeShouldBe404ForUnexistingResources() {
            var download = _webDownloader.Download("https://orchardcore.net/" + Guid.NewGuid());
            Assert.That(download, Is.Not.Null);
            Assert.That(download.StatusCode, Is.EqualTo(HttpStatusCode.NotFound));
            Assert.That(download.Content, Is.Null);
        public void StatusCodeShouldBe200ForValidRequests() {
            var download = _webDownloader.Download("https://orchardcore.net/");
            Assert.That(download.StatusCode, Is.EqualTo(HttpStatusCode.OK));
            Assert.That(download.Content, Is.Not.Empty);
    }
}
