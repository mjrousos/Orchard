using Orchard.ContentManagement;
using Orchard.Security;
using Orchard.UI.Admin;
using Orchard.DisplayManagement;
using Orchard.Localization;
using Orchard.Services;
using System.Web.Mvc;
using Orchard.Mvc.Filters;
﻿using System.Web.Mvc;
using System.Web.Routing;
using Moq;
using NUnit.Framework;
using Orchard.Tests.Stubs;

namespace Orchard.Tests.UI.Admin {
    [TestFixture]
    public class AdminAuthorizationFilterTests {
        private static AuthorizationContext GetAuthorizationContext<TController>() where TController : ControllerBase, new() {
            var controllerDescriptor = new ReflectedControllerDescriptor(typeof(TController));
            var controllerContext = new ControllerContext(new StubHttpContext(), new RouteData(), new TController());
            return new AuthorizationContext(
                controllerContext,
                controllerDescriptor.FindAction(controllerContext, "Index"));
        }
        private static IAuthorizer GetAuthorizer(bool result) {
            var authorizer = new Mock<IAuthorizer>();
            authorizer
                .Setup(x => x.Authorize(StandardPermissions.AccessAdminPanel, It.IsAny<LocalizedString>())).
                Returns(result);
            return authorizer.Object;
        [Test]
        public void NormalRequestShouldNotBeAffected() {
            var authorizationContext = GetAuthorizationContext<NormalController>();
            var filter = new AdminFilter(GetAuthorizer(false));
            filter.OnAuthorization(authorizationContext);
            Assert.That(authorizationContext.Result, Is.Null);
        private static void TestActionThatShouldRequirePermission<TController>() where TController : ControllerBase, new() {
            var authorizationContext = GetAuthorizationContext<TController>();
            Assert.That(authorizationContext.Result, Is.InstanceOf<HttpUnauthorizedResult>());
            Assert.That(AdminFilter.IsApplied(authorizationContext.RequestContext), Is.True);
            var authorizationContext2 = GetAuthorizationContext<TController>();
            var filter2 = new AdminFilter(GetAuthorizer(true));
            filter2.OnAuthorization(authorizationContext2);
            Assert.That(authorizationContext2.Result, Is.Null);
            Assert.That(AdminFilter.IsApplied(authorizationContext2.RequestContext), Is.True);
        public void AdminRequestShouldRequirePermission() {
            TestActionThatShouldRequirePermission<AdminController>();
        public void NormalWithAttribRequestShouldRequirePermission() {
            TestActionThatShouldRequirePermission<NormalWithAttribController>();
        public void NormalWithActionAttribRequestShouldRequirePermission() {
            TestActionThatShouldRequirePermission<NormalWithActionAttribController>();
        public void InheritedAttribRequestShouldRequirePermission() {
            TestActionThatShouldRequirePermission<InheritedAttribController>();
    }
    public class NormalController : Controller {
        public ActionResult Index() {
            return View();
    public class AdminController : Controller {
    [Admin]
    public class NormalWithAttribController : Controller {
    public class NormalWithActionAttribController : Controller {
        [Admin]
    public class BaseWithAttribController : Controller {
        public ActionResult Something() {
    public class InheritedAttribController : BaseWithAttribController {
}
