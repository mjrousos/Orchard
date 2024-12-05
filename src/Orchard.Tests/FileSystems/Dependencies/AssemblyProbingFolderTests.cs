using Orchard.ContentManagement;
using Orchard.Security;
using Orchard.UI.Admin;
using Orchard.DisplayManagement;
using Orchard.Localization;
using Orchard.Services;
using System.Web.Mvc;
using Orchard.Mvc.Filters;
﻿using System.Linq;
using NUnit.Framework;
using Orchard.Environment;
using Orchard.FileSystems.Dependencies;
using Orchard.Tests.Stubs;

namespace Orchard.Tests.FileSystems.Dependencies {
    [TestFixture]
    public class AssemblyProbingFolderTests {
        [Test]
        public void FolderShouldBeEmptyByDefault() {
            var clock = new StubClock();
            var appDataFolder = new StubAppDataFolder(clock);
            var dependenciesFolder = new DefaultAssemblyProbingFolder(appDataFolder, new DefaultAssemblyLoader(Enumerable.Empty<IAssemblyNameResolver>()));
            Assert.That(dependenciesFolder.AssemblyExists("foo"), Is.False);
        }
        public void LoadAssemblyShouldNotThrowIfAssemblyNotFound() {
            Assert.That(dependenciesFolder.LoadAssembly("foo"), Is.Null);
        public void GetAssemblyDateTimeUtcShouldThrowIfAssemblyNotFound() {
            Assert.That(() => dependenciesFolder.GetAssemblyDateTimeUtc("foo"), Throws.Exception);
        public void DeleteAssemblyShouldNotThrowIfAssemblyNotFound() {
            Assert.DoesNotThrow(() => dependenciesFolder.DeleteAssembly("foo"));
        public void StoreAssemblyShouldCopyFile() {
            var assembly = GetType().Assembly;
            var name = assembly.GetName().Name;
            {
                var dependenciesFolder = new DefaultAssemblyProbingFolder(appDataFolder, new DefaultAssemblyLoader(Enumerable.Empty<IAssemblyNameResolver>()));
                dependenciesFolder.StoreAssembly(name, assembly.Location);
            }
                Assert.That(dependenciesFolder.AssemblyExists(name), Is.True);
                Assert.That(dependenciesFolder.LoadAssembly(name), Is.SameAs(GetType().Assembly));
                Assert.DoesNotThrow(() => dependenciesFolder.DeleteAssembly(name));
                Assert.That(dependenciesFolder.LoadAssembly(name), Is.Null);
    }
}
