using Orchard.ContentManagement;
using Orchard.Security;
using Orchard.UI.Admin;
using Orchard.DisplayManagement;
using Orchard.Localization;
using Orchard.Services;
using System.Web.Mvc;
using Orchard.Mvc.Filters;
﻿using System;
using System.IO;
using System.IO.Packaging;
using Autofac;
using NUnit.Framework;
using Orchard.Environment;
using Orchard.Environment.Extensions.Models;
using Orchard.FileSystems.VirtualPath;
using Orchard.FileSystems.WebSite;
using Orchard.Packaging.Services;
using Orchard.Tests.Stubs;

namespace Orchard.Tests.Modules.Packaging.Services {
    [TestFixture]
    public class PackageBuilderTests : ContainerTestBase {
        private const string PackageIdentifier = "Hello.World";
        protected override void Register(ContainerBuilder builder) {
            builder.RegisterType<PackageBuilder>().As<IPackageBuilder>();
            builder.RegisterType<DefaultVirtualPathProvider>().As<IVirtualPathProvider>();
            builder.RegisterType<DefaultOrchardFrameworkAssemblies>().As<IOrchardFrameworkAssemblies>();
            builder.RegisterType<InMemoryWebSiteFolder>().As<IWebSiteFolder>()
                .As<InMemoryWebSiteFolder>().InstancePerLifetimeScope();
        }
        
        private Stream BuildHelloWorld(IPackageBuilder packageBuilder) {
            // add some content because NuGet requires it
            var folder = _container.Resolve<InMemoryWebSiteFolder>();
            using ( var sourceStream = GetType().Assembly.GetManifestResourceStream(GetType(), "Hello.World.csproj.txt") ) {
                folder.AddFile("~/Modules/Hello.World/Hello.World.csproj", new StreamReader(sourceStream).ReadToEnd());
            }
            
            return packageBuilder.BuildPackage(new ExtensionDescriptor {
                ExtensionType = DefaultExtensionTypes.Module,
                Id = PackageIdentifier,
                Version = "1.0",
                Description = "a",
                Author = "b"
            });
        [Test]
        public void PackageForModuleIsOpcPackage() {
            var packageBuilder = _container.Resolve<IPackageBuilder>();
            var stream = BuildHelloWorld(packageBuilder);
            var package = Package.Open(stream);
            Assert.That(package, Is.Not.Null);
            Assert.That(package.PackageProperties.Identifier, Is.EqualTo(PackageBuilder.BuildPackageId(PackageIdentifier, DefaultExtensionTypes.Module)));
        public void PropertiesPassThroughAsExpected() {
            Assert.That(package.PackageProperties.Description, Is.EqualTo("a"));
            Assert.That(package.PackageProperties.Creator, Is.EqualTo("b"));
            Assert.That(package.PackageProperties.Version, Is.EqualTo("1.0"));
        public void ProjectFileIsAdded() {
            string content;
                content = new StreamReader(sourceStream).ReadToEnd();
            var projectUri = PackUriHelper.CreatePartUri(new Uri("/Content/Modules/Hello.World/Hello.World.csproj", UriKind.Relative));
            var projectPart = package.GetPart(projectUri);
            using (var projectStream = projectPart.GetStream()) {
                var projectContent = new StreamReader(projectStream).ReadToEnd();
                Assert.That(projectContent, Is.EqualTo(content));
    }
}
