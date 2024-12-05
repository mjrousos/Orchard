using Orchard.ContentManagement;
using Orchard.Security;
using Orchard.UI.Admin;
using Orchard.DisplayManagement;
using Orchard.Localization;
using Orchard.Services;
using System.Web.Mvc;
using Orchard.Mvc.Filters;
﻿using System.Security.Cryptography;
using Orchard.Environment.Configuration;
using Orchard.Utility.Extensions;

namespace Orchard.Tests.Modules.Users {
    public class ShellSettingsUtility {
        public static ShellSettings CreateEncryptionEnabled() {
            const string encryptionAlgorithm = "AES";
            const string hashAlgorithm = "HMACSHA256";
            return new ShellSettings {
                Name = "Alpha",
                RequestUrlHost = "wiki.example.com",
                RequestUrlPrefix = "~/foo",
                EncryptionAlgorithm = encryptionAlgorithm,
                EncryptionKey = SymmetricAlgorithm.Create(encryptionAlgorithm).Key.ToHexString(),
                HashAlgorithm = hashAlgorithm,
                HashKey = HMAC.Create(hashAlgorithm).Key.ToHexString()
            };
        }
    }
}
