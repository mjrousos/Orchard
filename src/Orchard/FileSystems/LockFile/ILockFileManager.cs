using Orchard.ContentManagement;
using Orchard.Security;
using Orchard.UI.Admin;
using Orchard.DisplayManagement;
using Orchard.Localization;
using Orchard.Services;
using System.Web.Mvc;
using Orchard.Mvc.Filters;
﻿using Orchard.Caching;

namespace Orchard.FileSystems.LockFile {
    /// <summary>
    /// Abstraction for lock files creation.
    /// </summary>
    /// <remarks>
    /// All virtual paths passed in or returned are relative to "~/App_Data".
    /// </remarks>
    public interface ILockFileManager : IVolatileProvider {
        /// <summary>
        /// Attempts to acquire an exclusive lock file.
        /// </summary>
        /// <param name="path">The filename of the lock file to create.</param>
        /// <param name="lockFile">A reference to the lock file object if the lock is granted.</param>
        /// <returns><c>true</c> if the lock is granted; otherwise, <c>false</c>.</returns>
        bool TryAcquireLock(string path, ref ILockFile lockFile);
        /// Wether a lock file is already existing.
        /// <param name="path">The filename of the lock file to test.</param>
        /// <returns><c>true</c> if the lock file exists; otherwise, <c>false</c>.</returns>
        bool IsLocked(string path);
    }
}
