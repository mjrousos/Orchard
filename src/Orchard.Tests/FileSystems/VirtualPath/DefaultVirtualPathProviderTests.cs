using Orchard.ContentManagement;
using Orchard.Security;
using Orchard.UI.Admin;
using Orchard.DisplayManagement;
using Orchard.Localization;
using Orchard.Services;
using System.Web.Mvc;
using Orchard.Mvc.Filters;
﻿using Moq;
using NUnit.Framework;
using Orchard.FileSystems.VirtualPath;

namespace Orchard.Tests.FileSystems.VirtualPath {
    [TestFixture]
    public class DefaultVirtualPathProviderTests {
        [Test]
        public void TryFileExistsTest() {
            StubDefaultVirtualPathProvider defaultVirtualPathProvider = new StubDefaultVirtualPathProvider();
            Assert.That(defaultVirtualPathProvider.TryFileExists("~/a.txt"), Is.True);
            Assert.That(defaultVirtualPathProvider.TryFileExists("~/../a.txt"), Is.False);
            Assert.That(defaultVirtualPathProvider.TryFileExists("~/a/../a.txt"), Is.True);
            Assert.That(defaultVirtualPathProvider.TryFileExists("~/a/b/../a.txt"), Is.True);
            Assert.That(defaultVirtualPathProvider.TryFileExists("~/a/b/../../a.txt"), Is.True);
            Assert.That(defaultVirtualPathProvider.TryFileExists("~/a/b/../../../a.txt"), Is.False);
            Assert.That(defaultVirtualPathProvider.TryFileExists("~/a/../../b/c.txt"), Is.False);
        }
        public void RejectMalformedVirtualPathTests() {
            Assert.That(defaultVirtualPathProvider.IsMalformedVirtualPath("~/a.txt"), Is.False);
            Assert.That(defaultVirtualPathProvider.IsMalformedVirtualPath("/a.txt"), Is.False);
            Assert.That(defaultVirtualPathProvider.IsMalformedVirtualPath("~/../a.txt"), Is.True);
            Assert.That(defaultVirtualPathProvider.IsMalformedVirtualPath("/../a.txt"), Is.True);
            Assert.That(defaultVirtualPathProvider.IsMalformedVirtualPath("~/a/../a.txt"), Is.False);
            Assert.That(defaultVirtualPathProvider.IsMalformedVirtualPath("/a/../a.txt"), Is.False);
            Assert.That(defaultVirtualPathProvider.IsMalformedVirtualPath("~/a/b/../a.txt"), Is.False);
            Assert.That(defaultVirtualPathProvider.IsMalformedVirtualPath("/a/b/../a.txt"), Is.False);
            Assert.That(defaultVirtualPathProvider.IsMalformedVirtualPath("~/a/b/../../a.txt"), Is.False);
            Assert.That(defaultVirtualPathProvider.IsMalformedVirtualPath("/a/b/../../a.txt"), Is.False);
            Assert.That(defaultVirtualPathProvider.IsMalformedVirtualPath("~/a/b/../../../a.txt"), Is.True);
            Assert.That(defaultVirtualPathProvider.IsMalformedVirtualPath("/a/b/../../../a.txt"), Is.True);
            Assert.That(defaultVirtualPathProvider.IsMalformedVirtualPath("~/a/../../b//.txt"), Is.True);
            Assert.That(defaultVirtualPathProvider.IsMalformedVirtualPath("/a/../../b//.txt"), Is.True);
    }
    internal class StubDefaultVirtualPathProvider : DefaultVirtualPathProvider {
        public override bool FileExists(string path) {
            return true;
}
