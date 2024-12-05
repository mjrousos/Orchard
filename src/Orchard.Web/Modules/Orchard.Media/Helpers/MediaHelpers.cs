using Orchard.ContentManagement;
using Orchard.Security;
using Orchard.UI.Admin;
using Orchard.DisplayManagement;
using Orchard.Localization;
using Orchard.Services;
using System.Web.Mvc;
using Orchard.Mvc.Filters;
﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Orchard.Media.Models;

namespace Orchard.Media.Helpers {
    public static class MediaHelpers {
        public static IEnumerable<FolderNavigation> GetFolderNavigationHierarchy(string mediaPath) {
            List<FolderNavigation> navigations = new List<FolderNavigation>();
            if (String.IsNullOrEmpty(mediaPath)) {
                return navigations;
            }
            if ( !mediaPath.Contains(Path.DirectorySeparatorChar.ToString()) && !mediaPath.Contains(Path.AltDirectorySeparatorChar.ToString()) ) {
                navigations.Add(new FolderNavigation { FolderName = mediaPath, FolderPath = mediaPath });
            string[] navigationParts = mediaPath.Split(new[] { Path.DirectorySeparatorChar, Path.AltDirectorySeparatorChar}, StringSplitOptions.RemoveEmptyEntries);
            string currentPath = String.Empty;
            foreach (string navigationPart in navigationParts) {
                currentPath = (string.IsNullOrEmpty(currentPath) ? navigationPart : currentPath + "\\" + navigationPart);
                navigations.Add(new FolderNavigation { FolderName = navigationPart, FolderPath = currentPath });
            return navigations;
        }
        public static bool IsPicture(this HtmlHelper htmlHelper, string path) {
            return new[] {".png", ".jpg", ".jpeg", ".gif", ".bmp", ".ico"}
                .Contains((Path.GetExtension(path) ?? "").ToLowerInvariant());
    }
}
