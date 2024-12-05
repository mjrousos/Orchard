using Orchard.ContentManagement;
using Orchard.Security;
using Orchard.UI.Admin;
using Orchard.DisplayManagement;
using Orchard.Localization;
using Orchard.Services;
using System.Web.Mvc;
using Orchard.Mvc.Filters;
﻿using System;
using System.Linq;
using Autofac;
using NUnit.Framework;
using Orchard.Mvc;
using Orchard.Tests.Stubs;
using Orchard.UI.Resources;

namespace Orchard.Tests.UI.Resources {
    [TestFixture]
    public class ResourceManagerTests {
        private IContainer _container;
        private IResourceManager _resourceManager;
        private IResourceFileHashProvider _resourceFileHashProvider;
        private TestManifestProvider _testManifest;
        private readonly string _appPath = "/AppPath/";
        private class TestManifestProvider : IResourceManifestProvider {
            public Action<ResourceManifest> DefineManifest { get; set; }
            public TestManifestProvider() {
            }
            public void BuildManifests(ResourceManifestBuilder builder) {
                var manifest = builder.Add();
                if (DefineManifest != null) {
                    DefineManifest(manifest);
                }
        }
        private void VerifyPaths(string resourceType, RequireSettings defaultSettings, string expectedPaths) {
            defaultSettings = defaultSettings ?? new RequireSettings();
            var requiredResources = _resourceManager.BuildRequiredResources(resourceType);
            var renderedResources = string.Join(",", requiredResources.Select(context => context
                .GetResourceUrl(defaultSettings, _appPath, _resourceFileHashProvider)).ToArray());
            Assert.That(renderedResources, Is.EqualTo(expectedPaths));
        [SetUp]
        public void Init() {
            var builder = new ContainerBuilder();
            builder.RegisterType<StubWorkContextAccessor>().As<IWorkContextAccessor>();
            builder.RegisterType<StubHttpContextAccessor>().As<IHttpContextAccessor>();
            builder.RegisterType<ResourceManager>().As<IResourceManager>();
            builder.RegisterType<ResourceFileHashProvider>().As<IResourceFileHashProvider>();
            builder.RegisterType<TestManifestProvider>().As<IResourceManifestProvider>().SingleInstance();
            _container = builder.Build();
            _resourceManager = _container.Resolve<IResourceManager>();
            _resourceFileHashProvider = _container.Resolve<IResourceFileHashProvider>();
            _testManifest = _container.Resolve<IResourceManifestProvider>() as TestManifestProvider;
        [Test]
        public void ReleasePathIsTheDefaultPath() {
            _testManifest.DefineManifest = m => m.DefineResource("script", "Script1").SetUrl("script1.min.js", "script1.js");
            _resourceManager.Require("script", "Script1");
            VerifyPaths("script", null, "script1.min.js");
        public void DebugPathIsUsedWithDebugMode() {
            VerifyPaths("script", new RequireSettings { DebugMode = true }, "script1.js");
        public void ReleasePathIsUsedWhenNoDebugPath() {
            _testManifest.DefineManifest = m => m.DefineResource("script", "Script1").SetUrl("script1.min.js");
            VerifyPaths("script", new RequireSettings { DebugMode = true }, "script1.min.js");
        public void DefaultSettingsAreOverriddenByUseDebugMode() {
            _resourceManager.Require("script", "Script1").UseDebugMode();
            VerifyPaths("script", new RequireSettings { DebugMode = false }, "script1.js");
        public void CdnPathIsUsedInCdnMode() {
            _testManifest.DefineManifest = m => m
                .DefineResource("script", "Script1")
                .SetUrl("script1.js")
                .SetCdn("http://cdn/script1.min.js");
            VerifyPaths("script", new RequireSettings { CdnMode = true }, "http://cdn/script1.min.js");
        public void CdnSslPathIsUsedInCdnMode() {
                .SetCdn("https://cdn/script1.min.js");
            VerifyPaths("script", new RequireSettings { CdnMode = true }, "https://cdn/script1.min.js");
        public void CdnDebugPathIsUsedInCdnModeAndDebugMode() {
                .SetCdn("http://cdn/script1.min.js", "http://cdn/script1.js");
            VerifyPaths("script", new RequireSettings { CdnMode = true, DebugMode = true }, "http://cdn/script1.js");
        public void DebugPathIsUsedInCdnModeAndDebugModeAndThereIsNoCdnDebugPath() {
                .SetUrl("script1.min.js", "script1.js")
            VerifyPaths("script", new RequireSettings { CdnMode = true, DebugMode = true }, "script1.js");
        public void DependenciesAreAutoIncluded() {
            _testManifest.DefineManifest = m => {
                m.DefineResource("script", "Script1").SetUrl("script1.min.js");
                m.DefineResource("script", "Script2").SetUrl("script2.min.js").SetDependencies("Script1");
            };
            _resourceManager.Require("script", "Script2");
            VerifyPaths("script", null, "script1.min.js,script2.min.js");
        public void DependenciesAssumeTheirParentUseDebugModeSetting() {
                m.DefineResource("script", "Script1").SetUrl("script1.min.js", "script1.js");
                m.DefineResource("script", "Script2").SetUrl("script2.min.js", "script2.js").SetDependencies("Script1");
            _resourceManager.Require("script", "Script2").UseDebugMode();
            VerifyPaths("script", new RequireSettings { DebugMode = false }, "script1.js,script2.js");
    }
}
