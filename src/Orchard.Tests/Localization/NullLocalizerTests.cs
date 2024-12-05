using Orchard.ContentManagement;
using Orchard.Security;
using Orchard.UI.Admin;
using Orchard.DisplayManagement;
using Orchard.Localization;
using Orchard.Services;
using System.Web.Mvc;
using Orchard.Mvc.Filters;
﻿using NUnit.Framework;

namespace Orchard.Tests.Localization {
    [TestFixture]
    public class NullLocalizerTests {
        [Test]
        public void StringsShouldPassThrough() {
            var result = NullLocalizer.Instance("hello world");
            Assert.That(result.ToString(), Is.EqualTo("hello world"));
        }
        public void StringsShouldFormatIfArgumentsArePassedIn() {
            var result = NullLocalizer.Instance("hello {0} world", "!");
            Assert.That(result.ToString(), Is.EqualTo("hello ! world"));
        public void StringsShouldNotFormatWithoutAnyArguments() {
            var result = NullLocalizer.Instance("hello {0} world");
            Assert.That(result.ToString(), Is.EqualTo("hello {0} world"));
    }
}
