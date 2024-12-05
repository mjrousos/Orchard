using Orchard.ContentManagement;
using Orchard.Security;
using Orchard.UI.Admin;
using Orchard.DisplayManagement;
using Orchard.Localization;
using Orchard.Services;
using System.Web.Mvc;
using Orchard.Mvc.Filters;
﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Autofac;
using Moq;
using NUnit.Framework;
using Orchard.DisplayManagement.Descriptors;
using Orchard.DisplayManagement.Descriptors.ResourceBindingStrategy;
using Orchard.DisplayManagement.Descriptors.ShapeTemplateStrategy;
using Orchard.Environment;
using Orchard.Environment.Descriptor.Models;
using Orchard.Environment.Extensions;
using Orchard.Environment.Extensions.Models;
using Orchard.FileSystems.VirtualPath;
using Orchard.Tests.Localization;
using Orchard.UI.Resources;

namespace Orchard.Tests.DisplayManagement.Descriptors {
    [TestFixture]
    public class StylesheetBindingStrategyTests : ContainerTestBase {
        private ShellDescriptor _descriptor;
        private IList<FeatureDescriptor> _features;
        private TestViewEngine _testViewEngine;
        private TestVirtualPathProvider _testVirtualPathProvider;
        protected override void Register(Autofac.ContainerBuilder builder) {
            _descriptor = new ShellDescriptor { };
            _testViewEngine = new TestViewEngine();
            _testVirtualPathProvider = new TestVirtualPathProvider { TestViewEngine = _testViewEngine };
            builder.Register(ctx => _descriptor);
            builder.RegisterType<StylesheetBindingStrategy>().As<IShapeTableProvider>();
            builder.RegisterType<ResourceFileHashProvider>().As<IResourceFileHashProvider>();
            builder.RegisterInstance(_testViewEngine).As<IShapeTemplateViewEngine>();
            builder.RegisterInstance(_testVirtualPathProvider).As<IVirtualPathProvider>();
            builder.RegisterInstance(new Work<WorkContext>(resolve => new StubWorkContext())).AsSelf();
            var extensionManager = new Mock<IExtensionManager>();
            builder.Register(ctx => extensionManager);
            builder.Register(ctx => extensionManager.Object);
        }
        public class TestViewEngine : Dictionary<string, object>, IShapeTemplateViewEngine {
            public IEnumerable<string> DetectTemplateFileNames(IEnumerable<string> fileNames) {
                return fileNames;
            }
        public class TestVirtualPathProvider : IVirtualPathProvider {
            public TestViewEngine TestViewEngine { get; set; }
            public string Combine(params string[] paths) {
                throw new NotImplementedException();
            public string ToAppRelative(string virtualPath) {
            public string MapPath(string virtualPath) {
            public bool FileExists(string virtualPath) {
            public Stream OpenFile(string virtualPath) {
            public StreamWriter CreateText(string virtualPath) {
            public Stream CreateFile(string virtualPath) {
            public DateTime GetFileLastWriteTimeUtc(string virtualPath) {
            public string GetFileHash(string virtualPath) {
            public string GetFileHash(string virtualPath, IEnumerable<string> dependencies) {
            public void DeleteFile(string virtualPath) {
            public bool DirectoryExists(string virtualPath) {
            public void CreateDirectory(string virtualPath) {
            public string GetDirectoryName(string virtualPath) {
            public void DeleteDirectory(string virtualPath) {
            public IEnumerable<string> ListFiles(string path) {
                return TestViewEngine.Keys.Select(o => o.ToString());
            public IEnumerable<string> ListDirectories(string path) {
            public bool TryFileExists(string virtualPath) {
        protected override void Resolve(ILifetimeScope container) {
            _features = new List<FeatureDescriptor>();
            container.Resolve<Mock<IExtensionManager>>()
                .Setup(em => em.AvailableFeatures())
                .Returns(_features);
        void AddFeature(string name, params string[] dependencies) {
            var featureDescriptor = new FeatureDescriptor {
                Id = name,
                Dependencies = dependencies,
                Extension = new ExtensionDescriptor {
                    Id = name,
                    Location = "~/Modules"
                }
            };
            featureDescriptor.Extension.Features = new[] { featureDescriptor };
            _features.Add(featureDescriptor);
        void AddEnabledFeature(string name, params string[] dependencies) {
            AddFeature(name, dependencies);
            _descriptor.Features = _descriptor.Features.Concat(new[] { new ShellFeature { Name = name } });
        [Test]
        public void TemplateResolutionWorks() {
            AddEnabledFeature("Alpha");
            _testViewEngine.Add("~/Modules/Alpha/Styles/AlphaShape.css", null);
            _testViewEngine.Add("~/Modules/Alpha/Styles/alpha-shape.css", null);
            var strategy = _container.Resolve<IShapeTableProvider>();
            var builder = new ShapeTableBuilder(null);
            strategy.Discover(builder);
            var alterations = builder.BuildAlterations();
            Assert.That(alterations.Any(alteration => alteration.ShapeType == "Style"));
            var descriptor = new ShapeDescriptor { ShapeType = "Style" };
            alterations.Aggregate(descriptor, (d, alteration) => {
                alteration.Alter(d);
                return d;
            });
            var keys = descriptor.Bindings.Select(b => b.Key);
            Assert.That(keys.Count() == keys.Select(k => k.ToLowerInvariant()).Distinct().Count(), "Descriptors should never vary by case only.");
    }
}
