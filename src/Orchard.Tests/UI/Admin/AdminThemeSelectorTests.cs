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
using Orchard.Tests.Stubs;

namespace Orchard.Tests.UI.Admin {
    [TestFixture]
    public class AdminThemeSelectorTests {
        [Test]
        public void IsAppliedShouldBeFalseByDefault() {
            var context = new RequestContext(new StubHttpContext(), new RouteData());
            var isApplied = AdminFilter.IsApplied(context);
            Assert.That(isApplied, Is.False);
        }
        public void IsAppliedShouldBeTrueAfterBeingApplied() {
            Assert.That(AdminFilter.IsApplied(context), Is.False);
            AdminFilter.Apply(context);
            Assert.That(AdminFilter.IsApplied(context), Is.True);
        public void IsAppliedIsFalseOnNewContext() {
            context = new RequestContext(new StubHttpContext(), new RouteData());
        public void ThemeResultShouldBeNullNormally() {
            var selector = new AdminThemeSelector();
            var result = selector.GetTheme(context);
            Assert.That(result, Is.Null);
        public void ThemeResultShouldBeTheAdminAt100AfterBeingSet() {
            Assert.That(result, Is.Not.Null);
            Assert.That(result.ThemeName, Is.EqualTo("TheAdmin"));
            Assert.That(result.Priority, Is.EqualTo(100));
    }
}
