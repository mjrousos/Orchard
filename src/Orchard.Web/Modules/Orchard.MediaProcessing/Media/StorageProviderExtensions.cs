using Orchard.ContentManagement;
using Orchard.Security;
using Orchard.UI.Admin;
using Orchard.DisplayManagement;
using Orchard.Localization;
using Orchard.Services;
using System.Web.Mvc;
using Orchard.Mvc.Filters;
﻿using Orchard.FileSystems.Media;

namespace Orchard.MediaProcessing.Media {
    public static class StorageProviderExtensions {
        public static void TryDeleteFolder(this IStorageProvider storageProvider, string path) {
            try {
                if (storageProvider.FolderExists(path)) {
                    storageProvider.DeleteFolder(path);
                }
            }
            catch {}
        }
        public static IStorageFile OpenOrCreate(this IStorageProvider storageProvider, string path) {
            if (!storageProvider.FileExists(path)) {
                return storageProvider.CreateFile(path);
            return storageProvider.GetFile(path);
    }
}
