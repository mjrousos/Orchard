using Orchard.ContentManagement;
using Orchard.Security;
using Orchard.UI.Admin;
using Orchard.DisplayManagement;
using Orchard.Localization;
using Orchard.Services;
using System.Web.Mvc;
using Orchard.Mvc.Filters;
﻿using System.IO;

namespace Orchard.MediaLibrary.Factories {
    public interface IMediaFactorySelector : IDependency {
        MediaFactorySelectorResult GetMediaFactory(Stream stream, string mimeType, string contentType);
    }
}
