using Orchard.ContentManagement;
using Orchard.Security;
using Orchard.UI.Admin;
using Orchard.DisplayManagement;
using Orchard.Localization;
using Orchard.Services;
using System.Web.Mvc;
using Orchard.Mvc.Filters;
﻿namespace Orchard.Email.Models {
    /// <summary>
    /// Represents an enumeration for mail encryption methods.
    /// </summary>
    public enum SmtpEncryptionMethod {
        None = 0,
        SslTls = 1,
        StartTls = 2
    }
}
