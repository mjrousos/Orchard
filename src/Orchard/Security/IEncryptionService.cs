using Orchard.ContentManagement;
using Orchard.Security;
using Orchard.UI.Admin;
using Orchard.DisplayManagement;
using Orchard.Localization;
using Orchard.Services;
using System.Web.Mvc;
using Orchard.Mvc.Filters;
﻿namespace Orchard.Security {
    /// <summary>
    /// Provides encryption services adapted to securing tenant level information
    /// </summary>
    public interface IEncryptionService : ISingletonDependency {
        /// <summary>
        /// Decodes data that has been encrypted.
        /// </summary>
        /// <param name="encodedData">The encrypted data to decrypt.</param>
        /// <returns>A Byte[] array that represents the decrypted data.</returns>
        byte[] Decode(byte[] encodedData);

        /// Encrypts data.
        /// <param name="data">The data to encrypt.</param>
        /// <returns>The encrypted value.</returns>
        byte[] Encode(byte[] data);
    }
}
