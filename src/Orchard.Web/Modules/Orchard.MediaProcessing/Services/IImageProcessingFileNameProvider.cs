using Orchard.ContentManagement;
using Orchard.Security;
using Orchard.UI.Admin;
using Orchard.DisplayManagement;
using Orchard.Localization;
using Orchard.Services;
using System.Web.Mvc;
using Orchard.Mvc.Filters;
﻿namespace Orchard.MediaProcessing.Services {
    public interface IImageProcessingFileNameProvider : IDependency {
        string GetFileName(string profile, string path);
        void UpdateFileName(string profile, string path, string fileName);
    }
}
