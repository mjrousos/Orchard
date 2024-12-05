using Orchard.ContentManagement;
using Orchard.Security;
using Orchard.UI.Admin;
using Orchard.DisplayManagement;
using Orchard.Localization;
using Orchard.Services;
using System.Web.Mvc;
using Orchard.Mvc.Filters;
﻿using System;
using System.Diagnostics;
using System.IO;
using Path = Bleroy.FluentPath.Path;

namespace Orchard.Specs.Util {
    public static class PathExtensions {
        public static Path GetRelativePath(this Path path, Path basePath) {
            if (path.Equals(basePath))
                return Path.Get(".");
            if (path.Parent.Equals(basePath))
                return path.FileName;
            if (!path.IsDirectory && path.DirectoryName.Equals(basePath.DirectoryName))
            return path.Parent.GetRelativePath(basePath).Combine(path.FileName);
        }
        public static Path DeepCopy(this Path sourcePath, Path targetPath) {
            sourcePath
                .GetFiles("*", true /*recursive*/)
                .ForEach(file => FileCopy(sourcePath, targetPath, file));
            return sourcePath;
        public static Path DeepCopy(this Path sourcePath, string pattern, Path targetPath) {
                .GetFiles(pattern, true /*recursive*/)
        public static Path ShallowCopy(this Path sourcePath, string pattern, Path targetPath) {
                .GetFiles(pattern, false /*recursive*/)
        public static Path ShallowCopy(this Path sourcePath, Predicate<Path> predicatePath, Path targetPath) {
                .GetFiles(predicatePath, false /*recursive*/)
        private static void FileCopy(Path sourcePath, Path targetPath, Path sourceFile) {
            var targetFile = targetPath.Combine(sourceFile.GetRelativePath(sourcePath));
            targetFile.Parent.CreateDirectory();
            // Trace.WriteLine(string.Format("Copying file '{0}' to '{1}'", sourceFile, targetFile));
            File.Copy(sourceFile, targetFile, true /*overwrite*/);
    }
}
