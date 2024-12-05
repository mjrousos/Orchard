using Orchard.ContentManagement;
using Orchard.Security;
using Orchard.UI.Admin;
using Orchard.DisplayManagement;
using Orchard.Localization;
using Orchard.Services;
using System.Web.Mvc;
using Orchard.Mvc.Filters;
﻿using Orchard.FileSystems.VirtualPath;

namespace Orchard.Utility.Extensions {
    public static class VirtualPathProviderExtensions {
        public static string GetProjectReferenceVirtualPath(this IVirtualPathProvider virtualPathProvider, string projectPath, string referenceName, string hintPath) {
            string basePath = virtualPathProvider.GetDirectoryName(projectPath);
            string virtualPath = virtualPathProvider.GetReferenceVirtualPath(basePath, referenceName, hintPath);
            if (!string.IsNullOrEmpty(virtualPath)) {
                return virtualPathProvider.Combine(basePath, virtualPath);
            }
            return null;
        }
        public static string GetReferenceVirtualPath(this IVirtualPathProvider virtualPathProvider, string basePath, string referenceName, string hintPath) {
            // Check if hint path is valid
            if (!string.IsNullOrEmpty(hintPath)) {
                if (virtualPathProvider.TryFileExists(virtualPathProvider.Combine(basePath, hintPath)))
                    return hintPath;
            // Fall back to bin directory
            string relativePath = virtualPathProvider.Combine("bin", referenceName + ".dll");
            if (virtualPathProvider.TryFileExists(virtualPathProvider.Combine(basePath, relativePath)))
                return relativePath;
    }
}
