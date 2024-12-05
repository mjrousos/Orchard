using Orchard.ContentManagement;
using Orchard.Security;
using Orchard.UI.Admin;
using Orchard.DisplayManagement;
using Orchard.Localization;
using Orchard.Services;
using System.Web.Mvc;
using Orchard.Mvc.Filters;
﻿using System;
using Autofac;
using NUnit.Framework;
using Orchard.Conditions.Providers;
using Orchard.Conditions.Services;
using Orchard.Environment.Configuration;
using Orchard.Mvc;
using Orchard.Tests.Stubs;

namespace Orchard.Tests.Modules.Conditions.Providers {
    [TestFixture]
    public class UrlRuleConditionTest {
        private IContainer _container;
        private IConditionProvider _urlCondition;
        private StubHttpContextAccessor _stubContextAccessor;
        private ShellSettings _shellSettings;
        [SetUp]
        public void Init() {
            var builder = new ContainerBuilder();
            _shellSettings = new ShellSettings { RequestUrlPrefix = String.Empty };
            builder.RegisterType<UrlCondition>().As<IConditionProvider>();
            builder.RegisterInstance(_shellSettings);
            _stubContextAccessor = new StubHttpContextAccessor();
            builder.RegisterInstance(_stubContextAccessor).As<IHttpContextAccessor>();
            _container = builder.Build();
            _urlCondition = _container.Resolve<IConditionProvider>();
        }
        [Test]
        public void UrlForHomePageMatchesHomePagePath() {
            _stubContextAccessor.Set(new StubHttpContext("~/"));
            var context = new ConditionEvaluationContext { FunctionName = "url", Arguments = new[] { "~/" } };
            _urlCondition.Evaluate(context);
            Assert.That(context.Result, Is.True);
        public void UrlForAboutPageMatchesAboutPagePath() {
            _stubContextAccessor.Set(new StubHttpContext("~/about"));
            var context = new ConditionEvaluationContext { FunctionName = "url", Arguments = new[] { "~/about" } };
        public void UrlForBlogWithEndingWildcardMatchesBlogPostPageInSaidBlog() {
            _stubContextAccessor.Set(new StubHttpContext("~/my-blog/my-blog-post"));
            var context = new ConditionEvaluationContext { FunctionName = "url", Arguments = new[] { "~/my-blog/*" } };
        public void UrlForHomePageDoesNotMatchAboutPagePath() {
            Assert.That(context.Result, Is.False);
        public void UrlForAboutPageMatchesDifferentCasedAboutPagePath() {
            _stubContextAccessor.Set(new StubHttpContext("~/About"));
        public void UrlForAboutPageWithEndingSlashMatchesAboutPagePath() {
            _stubContextAccessor.Set(new StubHttpContext("~/About/"));
        public void UrlForHomePageMatchesHomePagePathWithUrlPrefix() {
            _stubContextAccessor.Set(new StubHttpContext("~/site1"));
            _shellSettings.RequestUrlPrefix = "site1";
    }
}
