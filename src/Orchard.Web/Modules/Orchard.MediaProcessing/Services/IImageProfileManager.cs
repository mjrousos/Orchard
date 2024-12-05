using Orchard.ContentManagement;
using Orchard.Security;
using Orchard.UI.Admin;
using Orchard.DisplayManagement;
using Orchard.Localization;
using Orchard.Services;
using System.Web.Mvc;
using Orchard.Mvc.Filters;
﻿using Orchard.ContentManagement;
using Orchard.MediaProcessing.Models;

namespace Orchard.MediaProcessing.Services {
    public interface IImageProfileManager : IDependency {
        string GetImageProfileUrl(string path, string profileName);
        string GetImageProfileUrl(string path, string profileName, ContentItem contentItem);
        string GetImageProfileUrl(string path, string profileName, FilterRecord customFilter);
        string GetImageProfileUrl(string path, string profileName, FilterRecord customFilter, ContentItem contentItem);
        string GetImageProfileUrl(string path, string profileName, ContentItem contentItem, params FilterRecord[] customFilters);
    }
}
