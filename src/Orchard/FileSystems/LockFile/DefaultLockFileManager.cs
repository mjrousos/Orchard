using Orchard.ContentManagement;
using Orchard.Security;
using Orchard.UI.Admin;
using Orchard.DisplayManagement;
using Orchard.Localization;
using Orchard.Services;
using System.Web.Mvc;
using Orchard.Mvc.Filters;
﻿using System;
using System.Globalization;
using System.Threading;
using Orchard.FileSystems.AppData;

namespace Orchard.FileSystems.LockFile {
    public class DefaultLockFileManager : ILockFileManager {
        private readonly IAppDataFolder _appDataFolder;
        private readonly IClock _clock;
        private readonly ReaderWriterLockSlim _rwLock = new ReaderWriterLockSlim();
        public static TimeSpan Expiration { get; private set; }
        public DefaultLockFileManager(IAppDataFolder appDataFolder, IClock clock) {
            _appDataFolder = appDataFolder;
            _clock = clock;
            Expiration = TimeSpan.FromMinutes(10);
        }
        public bool TryAcquireLock(string path, ref ILockFile lockFile) {
            if (!_rwLock.TryEnterWriteLock(0)) {
                return false;
            }
            try {
                if (IsLockedImpl(path)) {
                    return false;
                }
                lockFile = new LockFile(_appDataFolder, path, _clock.UtcNow.ToString("u"), _rwLock);
                return true;
            catch {
                // an error occurred while reading/creating the lock file
            finally {
                _rwLock.ExitWriteLock();
        public bool IsLocked(string path) {
            _rwLock.EnterWriteLock();
                return IsLockedImpl(path);
                // an error occurred while reading the file
        private bool IsLockedImpl(string path) {
            if (_appDataFolder.FileExists(path)) {
                var content = _appDataFolder.ReadFile(path);
                DateTime creationUtc;
                if (DateTime.TryParse(content, CultureInfo.InvariantCulture, DateTimeStyles.AssumeUniversal, out creationUtc)) {
                    // if expired the file is not removed
                    // it should be automatically as there is a finalizer in LockFile
                    // or the next taker can do it, unless it also fails, again
                    return creationUtc.ToUniversalTime().Add(Expiration) > _clock.UtcNow;
            return false;
    }
}
