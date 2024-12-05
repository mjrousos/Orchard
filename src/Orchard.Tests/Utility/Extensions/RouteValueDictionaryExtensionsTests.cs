using Orchard.ContentManagement;
using Orchard.Security;
using Orchard.UI.Admin;
using Orchard.DisplayManagement;
using Orchard.Localization;
using Orchard.Services;
using System.Web.Mvc;
using Orchard.Mvc.Filters;
﻿using System.Web.Routing;
using NUnit.Framework;
using Orchard.Utility.Extensions;

namespace Orchard.Tests.Utility.Extensions {
    [TestFixture]
    class RouteValueDictionaryExtensionsTests {
        [Test]
        public void IdenticalRouteValueDictionariesShouldMatch() {
            Assert.IsTrue(new RouteValueDictionary { { "controller", "foo" }, { "action", "bar" } }
                .Match(new RouteValueDictionary { { "controller", "foo" }, { "action", "bar" } }));
        }
        public void CasedRouteValueDictionariesShouldMatch() {
            Assert.IsTrue(new RouteValueDictionary { { "controller", "foo" }, { "action", "BAR" } }
        
        public void RouteValueDictionariesWithDifferentNumbersOfValuesShouldNotMatch() {
            Assert.IsFalse(new RouteValueDictionary { { "controller", "foo" }, { "action", "bar" } }
                .Match(new RouteValueDictionary { { "controller", "foo" }, { "action", "bar" }, { "area", "baz" } }));
        public void RouteValueDictionariesWithDifferentValuesShouldMatch() {
                .Match(new RouteValueDictionary { { "controller", "foo" }, { "action", "baz" } }));
    }
}
