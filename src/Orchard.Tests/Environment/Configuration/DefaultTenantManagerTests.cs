using Orchard.ContentManagement;
using Orchard.Security;
using Orchard.UI.Admin;
using Orchard.DisplayManagement;
using Orchard.Localization;
using Orchard.Services;
using System.Web.Mvc;
using Orchard.Mvc.Filters;
﻿using System.Linq;
using Moq;
using NUnit.Framework;
using Orchard.Environment;
using Orchard.Environment.Configuration;
using Orchard.Tests.Stubs;

namespace Orchard.Tests.Environment.Configuration {
    [TestFixture]
    public class DefaultTenantManagerTests {
        private StubAppDataFolder _appDataFolder;
        [SetUp]
        public void Init() {
            var clock = new StubClock();
            _appDataFolder = new StubAppDataFolder(clock);
        }
        [Test]
        public void SingleSettingsFileShouldComeBackAsExpected() {
            _appDataFolder.CreateFile("Sites\\Default\\Settings.txt", "Name: Default\r\nDataProvider: SqlCe\r\nDataConnectionString: something else");
            IShellSettingsManager loader = new ShellSettingsManager(_appDataFolder, new Mock<IShellSettingsManagerEventHandler>().Object);
            var settings = loader.LoadSettings().Single();
            Assert.That(settings, Is.Not.Null);
            Assert.That(settings.Name, Is.EqualTo(ShellSettings.DefaultName));
            Assert.That(settings.DataProvider, Is.EqualTo("SqlCe"));
            Assert.That(settings.DataConnectionString, Is.EqualTo("something else"));
        public void MultipleFilesCanBeDetected() {
            _appDataFolder.CreateFile("Sites\\Another\\Settings.txt", "Name: Another\r\nDataProvider: SqlCe2\r\nDataConnectionString: something else2");
            var settings = loader.LoadSettings();
            Assert.That(settings.Count(), Is.EqualTo(2));
            var def = settings.Single(x => x.Name == ShellSettings.DefaultName);
            Assert.That(def.Name, Is.EqualTo(ShellSettings.DefaultName));
            Assert.That(def.DataProvider, Is.EqualTo("SqlCe"));
            Assert.That(def.DataConnectionString, Is.EqualTo("something else"));
            var alt = settings.Single(x => x.Name == "Another");
            Assert.That(alt.Name, Is.EqualTo("Another"));
            Assert.That(alt.DataProvider, Is.EqualTo("SqlCe2"));
            Assert.That(alt.DataConnectionString, Is.EqualTo("something else2"));
        public void NewSettingsCanBeStored() {
            var foo = new ShellSettings {Name = "Foo", DataProvider = "Bar", DataConnectionString = "Quux"};
            Assert.That(loader.LoadSettings().Count(), Is.EqualTo(1));
            loader.SaveSettings(foo);
            Assert.That(loader.LoadSettings().Count(), Is.EqualTo(2));
            var text = _appDataFolder.ReadFile("Sites\\Foo\\Settings.txt");
            Assert.That(text, Is.StringContaining("Foo"));
            Assert.That(text, Is.StringContaining("Bar"));
            Assert.That(text, Is.StringContaining("Quux"));
        public void CustomSettingsCanBeRetrieved() {
            _appDataFolder.CreateFile("Sites\\Default\\Settings.txt", "Name: Default\r\nProperty1: Foo\r\nProperty2: Bar");
            var settings = loader.LoadSettings().First();
            Assert.That(settings.Name, Is.EqualTo("Default"));
            Assert.That(settings["Property1"], Is.EqualTo("Foo"));
            Assert.That(settings["Property2"], Is.EqualTo("Bar"));
        public void CustomSettingsCanBeStoredAndRetrieved() {
            var foo = new ShellSettings { Name = "Default" };
            foo["Property1"] = "Foo";
            foo["Property2"] = "Bar";
        public void EncryptionSettingsAreStoredAndReadable() {
            var foo = new ShellSettings { Name = "Foo", DataProvider = "Bar", DataConnectionString = "Quux", EncryptionAlgorithm = "AES", EncryptionKey = "ABCDEFG", HashAlgorithm = "HMACSHA256", HashKey = "HIJKLMN" };
            Assert.That(settings.EncryptionAlgorithm, Is.EqualTo("AES"));
            Assert.That(settings.EncryptionKey, Is.EqualTo("ABCDEFG"));
            Assert.That(settings.HashAlgorithm, Is.EqualTo("HMACSHA256"));
            Assert.That(settings.HashKey, Is.EqualTo("HIJKLMN"));
        public void SettingsDontLoseTenantState() {
            foo.State = TenantState.Disabled;
            Assert.That(settings.State, Is.EqualTo(TenantState.Disabled));
    }
}
