using Orchard.ContentManagement;
using Orchard.Security;
using Orchard.UI.Admin;
using Orchard.DisplayManagement;
using Orchard.Localization;
using Orchard.Services;
using System.Web.Mvc;
using Orchard.Mvc.Filters;
﻿using System;
using System.Security.Cryptography;
using System.Text;
using Autofac;
using NUnit.Framework;
using Orchard.Environment.Configuration;
using Orchard.Security.Providers;
using Orchard.Utility.Extensions;

namespace Orchard.Tests.Security {
    [TestFixture]
    public class DefaultEncryptionServiceTests {
        private IContainer _container;
        [SetUp]
        public void Init() {
            const string encryptionAlgorithm = "AES";
            const string hashAlgorithm = "HMACSHA256";
            var shellSettings = new ShellSettings {
                Name = "Foo",
                DataProvider = "Bar",
                DataConnectionString = "Quux",
                EncryptionAlgorithm = encryptionAlgorithm,
                EncryptionKey = SymmetricAlgorithm.Create(encryptionAlgorithm).Key.ToHexString(),
                HashAlgorithm = hashAlgorithm,
                HashKey = HMAC.Create(hashAlgorithm).Key.ToHexString()
            };
            var builder = new ContainerBuilder();
            builder.RegisterInstance(shellSettings);
            builder.RegisterType<DefaultEncryptionService>().As<IEncryptionService>();
            _container = builder.Build();
        }
        [Test]
        public void CanEncodeAndDecodeData() {
            var encryptionService = _container.Resolve<IEncryptionService>();
            var secretData = Encoding.Unicode.GetBytes("this is secret data");
            var encrypted = encryptionService.Encode(secretData);
            var decrypted = encryptionService.Decode(encrypted);
            Assert.That(encrypted, Is.Not.EqualTo(decrypted));
            Assert.That(decrypted, Is.EqualTo(secretData));
        public void ShouldDetectTamperedData() {
            try {
                // tamper the data
                encrypted[encrypted.Length - 1] ^= 66;
                var decrypted = encryptionService.Decode(encrypted);
            }
            catch {
                return;
            Assert.Fail();
        public void SuccessiveEncodeCallsShouldNotReturnTheSameData() {
            byte[] previousEncrypted = null;
            for (int i = 0; i < 10; i++) {
                var encrypted = encryptionService.Encode(secretData);
                Assert.That(encrypted, Is.Not.EqualTo(decrypted));
                Assert.That(decrypted, Is.EqualTo(secretData));
                if(previousEncrypted != null) {
                    Assert.That(encrypted, Is.Not.EqualTo(previousEncrypted));
                }
                previousEncrypted = encrypted;
    }
}
