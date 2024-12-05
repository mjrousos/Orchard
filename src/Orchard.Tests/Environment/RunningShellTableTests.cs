using Orchard.ContentManagement;
using Orchard.Security;
using Orchard.UI.Admin;
using Orchard.DisplayManagement;
using Orchard.Localization;
using Orchard.Services;
using System.Web.Mvc;
using Orchard.Mvc.Filters;
﻿using System.Collections.Generic;
using NUnit.Framework;
using Orchard.Environment;
using Orchard.Environment.Configuration;
using Orchard.Tests.Stubs;

namespace Orchard.Tests.Environment {
    [TestFixture]
    public class RunningShellTableTests {
        [Test]
        public void NoShellsGiveNoMatch() {
            var table = new RunningShellTable();
            var match = table.Match(new StubHttpContext());
            Assert.That(match, Is.Null);
        }
        public void DefaultShellMatchesByDefault() {
            var table = (IRunningShellTable)new RunningShellTable();
            var settings = new ShellSettings { Name = ShellSettings.DefaultName };
            table.Add(settings);
            Assert.That(match, Is.EqualTo(settings).Using(new ShellComparer()));
        public void AnotherShellMatchesByHostHeader() {
            var settingsA = new ShellSettings { Name = "Alpha", RequestUrlHost = "a.example.com" };
            table.Add(settingsA);
            var match = table.Match(new StubHttpContext("~/foo/bar", "a.example.com"));
            Assert.That(match, Is.EqualTo(settingsA).Using(new ShellComparer()));
        public void DefaultStillCatchesWhenOtherShellsMiss() {
            var match = table.Match(new StubHttpContext("~/foo/bar", "b.example.com"));
        public void DefaultWontFallbackIfItHasCriteria() {
            var settings = new ShellSettings { Name = ShellSettings.DefaultName, RequestUrlHost = "www.example.com" };
        public void DefaultWillCatchRequestsIfItMatchesCriteria() {
            var match = table.Match(new StubHttpContext("~/foo/bar", "www.example.com"));
        public void NonDefaultCatchallWillFallbackIfNothingElseMatches() {
            var settingsA = new ShellSettings { Name = "Alpha" };
        public void DefaultCatchallIsFallbackEvenWhenOthersAreUnqualified() {
            var settingsB = new ShellSettings { Name = "Beta", RequestUrlHost = "b.example.com" };
            var settingsG = new ShellSettings { Name = "Gamma" };
            table.Add(settingsB);
            table.Add(settingsG);
        public void ThereIsNoFallbackIfMultipleSitesAreUnqualifiedButDefaultIsNotOneOfThem() {
        public void PathAlsoCausesMatch() {
            var settingsA = new ShellSettings { Name = "Alpha", RequestUrlPrefix = "foo" };
        public void PathAndHostMustBothMatch() {
            var settings = new ShellSettings { Name = ShellSettings.DefaultName, RequestUrlHost = "www.example.com", };
            var settingsA = new ShellSettings { Name = "Alpha", RequestUrlHost = "wiki.example.com", RequestUrlPrefix = "foo" };
            var settingsB = new ShellSettings { Name = "Beta", RequestUrlHost = "wiki.example.com", RequestUrlPrefix = "bar" };
            var settingsG = new ShellSettings { Name = "Gamma", RequestUrlHost = "wiki.example.com" };
            var settingsD = new ShellSettings { Name = "Delta", RequestUrlPrefix = "Quux" };
            // add this shell first, because the order the shells where processed used to matter
            table.Add(settingsD);
            Assert.That(table.Match(new StubHttpContext("~/foo/bar", "wiki.example.com")), Is.EqualTo(settingsA).Using(new ShellComparer()));
            Assert.That(table.Match(new StubHttpContext("~/bar/foo", "wiki.example.com")), Is.EqualTo(settingsB).Using(new ShellComparer()));
            Assert.That(table.Match(new StubHttpContext("~/", "wiki.example.com")), Is.EqualTo(settingsG).Using(new ShellComparer()));
            Assert.That(table.Match(new StubHttpContext("~/baaz", "wiki.example.com")), Is.EqualTo(settingsG).Using(new ShellComparer()));
            Assert.That(table.Match(new StubHttpContext("~/foo/bar", "www.example.com")), Is.EqualTo(settings).Using(new ShellComparer()));
            Assert.That(table.Match(new StubHttpContext("~/bar/foo", "www.example.com")), Is.EqualTo(settings).Using(new ShellComparer()));
            Assert.That(table.Match(new StubHttpContext("~/baaz", "www.example.com")), Is.EqualTo(settings).Using(new ShellComparer()));
            Assert.That(table.Match(new StubHttpContext("~/foo/bar", "a.example.com")), Is.Null);
            Assert.That(table.Match(new StubHttpContext("~/quux/quad", "wiki.example.com")), Is.EqualTo(settingsG).Using(new ShellComparer()));
            Assert.That(table.Match(new StubHttpContext("~/quux/quad", "www.example.com")), Is.EqualTo(settings).Using(new ShellComparer()));
            Assert.That(table.Match(new StubHttpContext("~/quux/quad", "a.example.com")), Is.EqualTo(settingsD).Using(new ShellComparer()));
            Assert.That(table.Match(new StubHttpContext("~/yarg", "wiki.example.com")), Is.EqualTo(settingsG).Using(new ShellComparer()));
            Assert.That(table.Match(new StubHttpContext("~/yarg", "www.example.com")), Is.EqualTo(settings).Using(new ShellComparer()));
            Assert.That(table.Match(new StubHttpContext("~/yarg", "a.example.com")), Is.Null);
        public void PathAndHostMustMatchOnFullUrl() {
            Assert.That(table.Match(new StubHttpContext("~/barbaz", "wiki.example.com")), Is.EqualTo(settingsG).Using(new ShellComparer()));
        public void PathAloneWillMatch() {
            Assert.That(table.Match(new StubHttpContext("~/bar/foo", "wiki.example.com")), Is.Null);
        public void HostNameMatchesRightmostIfRequestIsLonger() {
            var table = (IRunningShellTable) new RunningShellTable();
            var settingsA = new ShellSettings { Name = "Alpha", RequestUrlHost = "example.com" };
            Assert.That(table.Match(new StubHttpContext("~/foo/bar", "wiki.example.com")), Is.EqualTo(settings).Using(new ShellComparer()));
            Assert.That(table.Match(new StubHttpContext("~/foo/bar", "example.com")), Is.EqualTo(settingsA).Using(new ShellComparer()));
            Assert.That(table.Match(new StubHttpContext("~/foo/bar", "localhost")), Is.EqualTo(settings).Using(new ShellComparer()));
        public void HostNameMatchesRightmostIfStar() {
            var settingsA = new ShellSettings { Name = "Alpha", RequestUrlHost = "*.example.com" };
            Assert.That(table.Match(new StubHttpContext("~/foo/bar", "www.example.com")), Is.EqualTo(settingsA).Using(new ShellComparer()));
        public void LongestMatchingHostHasPriority() {
            var settingsA = new ShellSettings { Name = "Alpha", RequestUrlHost = "www.example.com" };
            var settingsB = new ShellSettings { Name = "Beta", RequestUrlHost = "*.example.com" };
            Assert.That(table.Match(new StubHttpContext("~/foo/bar", "wiki.example.com")), Is.EqualTo(settingsG).Using(new ShellComparer()));
            Assert.That(table.Match(new StubHttpContext("~/foo/bar", "username.example.com")), Is.EqualTo(settingsB).Using(new ShellComparer()));
        public void ShellNameUsedToDistinctThingsAsTheyAreAdded() {
            var settingsA = new ShellSettings { Name = "Alpha", RequestUrlHost = "removed.example.com" };
            var settingsB = new ShellSettings { Name = "Alpha", RequestUrlHost = "added.example.com" };
            Assert.That(table.Match(new StubHttpContext("~/foo/bar", "removed.example.com")), Is.EqualTo(settings).Using(new ShellComparer()));
            Assert.That(table.Match(new StubHttpContext("~/foo/bar", "added.example.com")), Is.EqualTo(settingsB).Using(new ShellComparer()));
        public void MultipleHostsOnShellAreAdded() {
            var settingsAlpha = new ShellSettings { Name = "Alpha", RequestUrlHost = "a.example.com,b.example.com" };
            var settingsB = new ShellSettings { Name = "Alpha", RequestUrlHost = "b.example.com" };
            var settingsBeta = new ShellSettings { Name = "Beta", RequestUrlHost = "c.example.com,d.example.com,e.example.com" };
            var settingsC = new ShellSettings { Name = "Beta", RequestUrlHost = "c.example.com" };
            var settingsD = new ShellSettings { Name = "Beta", RequestUrlHost = "d.example.com" };
            var settingsE = new ShellSettings { Name = "Beta", RequestUrlHost = "e.example.com" };
            table.Add(settingsAlpha);
            table.Add(settingsBeta);
            Assert.That(table.Match(new StubHttpContext("~/foo/bar", "a.example.com")), Is.EqualTo(settingsA).Using(new ShellComparer()));
            Assert.That(table.Match(new StubHttpContext("~/foo/bar", "b.example.com")), Is.EqualTo(settingsB).Using(new ShellComparer()));
            Assert.That(table.Match(new StubHttpContext("~/foo/bar", "c.example.com")), Is.EqualTo(settingsC).Using(new ShellComparer()));
            Assert.That(table.Match(new StubHttpContext("~/foo/bar", "d.example.com")), Is.EqualTo(settingsD).Using(new ShellComparer()));
            Assert.That(table.Match(new StubHttpContext("~/foo/bar", "e.example.com")), Is.EqualTo(settingsE).Using(new ShellComparer()));
        public class ShellComparer : IEqualityComparer<ShellSettings> {
            public bool Equals(ShellSettings x, ShellSettings y) {
                return x == y || (
                    x != null && y != null &&
                    x.DataConnectionString == y.DataConnectionString &&
                    x.DataProvider == y.DataProvider &&
                    x.DataTablePrefix == y.DataTablePrefix &&
                    x.EncryptionAlgorithm == y.EncryptionAlgorithm &&
                    x.EncryptionKey == y.EncryptionKey &&
                    x.HashAlgorithm == y.HashAlgorithm &&
                    x.HashKey == y.HashKey &&
                    x.Name == y.Name &&
                    x.RequestUrlHost == y.RequestUrlHost &&
                    x.RequestUrlPrefix == y.RequestUrlPrefix &&
                    x.State == y.State
                    );
            }
            public int GetHashCode(ShellSettings obj) {
                return obj.DataConnectionString.GetHashCode() ^
                       obj.DataProvider.GetHashCode() ^
                       obj.DataTablePrefix.GetHashCode() ^
                       obj.EncryptionAlgorithm.GetHashCode() ^
                       obj.EncryptionKey.GetHashCode() ^
                       obj.HashAlgorithm.GetHashCode() ^
                       obj.HashKey.GetHashCode() ^
                       obj.Name.GetHashCode() ^
                       obj.RequestUrlHost.GetHashCode() ^
                       obj.RequestUrlPrefix.GetHashCode() ^
                       obj.State.GetHashCode();
    }
}
