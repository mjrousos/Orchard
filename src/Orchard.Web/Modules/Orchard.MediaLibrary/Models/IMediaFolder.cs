using Orchard.ContentManagement;
using Orchard.Security;
using Orchard.UI.Admin;
using Orchard.DisplayManagement;
using Orchard.Localization;
using Orchard.Services;
using System.Web.Mvc;
using Orchard.Mvc.Filters;
﻿using System;

namespace Orchard.MediaLibrary.Models {
    public interface IMediaFolder {
        string Name { get; }
        string MediaPath { get; }
        string User { get; }
        DateTime LastUpdated { get; }
        long Size { get; }
    }
}
