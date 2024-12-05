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
using System.Threading;
using NUnit.Framework;
using Orchard.FileSystems.AppData;
using Orchard.FileSystems.LockFile;
using Orchard.Tests.Stubs;

namespace Orchard.Tests.FileSystems.LockFile {
    [TestFixture]
    public class LockFileManagerTests {
        private string _tempFolder;
        private IAppDataFolder _appDataFolder;
        private ILockFileManager _lockFileManager;
        private StubClock _clock;
        public class StubAppDataFolderRoot : IAppDataFolderRoot {
            public string RootPath { get; set; }
            public string RootFolder { get; set; }
        }
        public static IAppDataFolder CreateAppDataFolder(string tempFolder) {
            var folderRoot = new StubAppDataFolderRoot {RootPath = "~/App_Data", RootFolder = tempFolder};
            var monitor = new StubVirtualPathMonitor();
            return new AppDataFolder(folderRoot, monitor);
        [SetUp]
        public void Init() {
            _tempFolder = Path.GetTempFileName();
            File.Delete(_tempFolder);
            _appDataFolder = CreateAppDataFolder(_tempFolder);
            _clock = new StubClock();
            _lockFileManager = new DefaultLockFileManager(_appDataFolder, _clock);
        [TearDown]
        public void Term() {
            Directory.Delete(_tempFolder, true);
        [Test]
        public void LockShouldBeGrantedWhenDoesNotExist() {
            ILockFile lockFile = null;
            var granted = _lockFileManager.TryAcquireLock("foo.txt.lock", ref lockFile);
            Assert.That(granted, Is.True);
            Assert.That(lockFile, Is.Not.Null);
            Assert.That(_lockFileManager.IsLocked("foo.txt.lock"), Is.True);
            Assert.That(_appDataFolder.ListFiles("").Count(), Is.EqualTo(1));
        public void ExistingLockFileShouldPreventGrants() {
            _lockFileManager.TryAcquireLock("foo.txt.lock", ref lockFile);
            
            Assert.That(_lockFileManager.TryAcquireLock("foo.txt.lock", ref lockFile), Is.False);
        public void ReleasingALockShouldAllowGranting() {
            using (lockFile) {
                Assert.That(_lockFileManager.IsLocked("foo.txt.lock"), Is.True);
                Assert.That(_appDataFolder.ListFiles("").Count(), Is.EqualTo(1));
            }
            Assert.That(_lockFileManager.IsLocked("foo.txt.lock"), Is.False);
            Assert.That(_appDataFolder.ListFiles("").Count(), Is.EqualTo(0));
        public void ReleasingAReleasedLockShouldWork() {
            lockFile.Release();
        public void DisposingLockShouldReleaseIt() {
        public void ExpiredLockShouldBeAvailable() {
            _clock.Advance(DefaultLockFileManager.Expiration);
        public void ShouldGrantExpiredLock() {
        private static int _lockCount;
        private static readonly object _synLock = new object();
        public void AcquiringLockShouldBeThreadSafe() {
            var threads = new List<Thread>();
            for(var i=0; i<10; i++) {
                var t = new Thread(PlayWithAcquire);
                t.Start();
                threads.Add(t);
            threads.ForEach(t => t.Join());
            Assert.That(_lockCount, Is.EqualTo(0));
        public void IsLockedShouldBeThreadSafe() {
            for (var i = 0; i < 10; i++)
            {
                var t = new Thread(PlayWithIsLocked);
        private void PlayWithAcquire() {
            var r = new Random(DateTime.Now.Millisecond); 
            // loop until the lock has been acquired
            for (;;) {
                if (!_lockFileManager.TryAcquireLock("foo.txt.lock", ref lockFile)) {
                    continue;
                }
                lock (_synLock) {
                    _lockCount++;
                    Assert.That(_lockCount, Is.EqualTo(1));
                // keep the lock for a certain time
                Thread.Sleep(r.Next(200));
                    _lockCount--;
                    Assert.That(_lockCount, Is.EqualTo(0));
                lockFile.Release();
                return;
        private void PlayWithIsLocked() {
            const string path = "foo.txt.lock";
                if(_lockFileManager.IsLocked(path)) {
                if (!_lockFileManager.TryAcquireLock(path, ref lockFile)) {
    }
}
