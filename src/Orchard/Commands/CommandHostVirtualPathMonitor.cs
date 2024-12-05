using Orchard.ContentManagement;
using Orchard.Security;
using Orchard.UI.Admin;
using Orchard.DisplayManagement;
using Orchard.Localization;
using Orchard.Services;
using System.Web.Mvc;
using Orchard.Mvc.Filters;
using System;
using System.IO;
using Orchard.Caching;
using Orchard.FileSystems.VirtualPath;

namespace Orchard.Commands {
    /// <summary>
    /// Command line specific virtual path monitor.
    /// Note that we make this class "internal" so that it's not auto-registered
    /// by the Orchard Framework (it is registered explicitly by the command
    /// line host).
    /// </summary>
    internal class CommandHostVirtualPathMonitor : IVirtualPathMonitor {
        private readonly IVirtualPathProvider _virtualPathProvider;
        public CommandHostVirtualPathMonitor(IVirtualPathProvider virtualPathProvider) {
            _virtualPathProvider = virtualPathProvider;
        }
        public IVolatileToken WhenPathChanges(string virtualPath) {
            var filename = _virtualPathProvider.MapPath(virtualPath);
            if (File.Exists(filename)) {
                return new FileToken(filename);
            }
            if (Directory.Exists(filename)) {
                return new DirectoryToken(filename);
            return new EmptyVolativeToken(filename);
        public class EmptyVolativeToken : IVolatileToken {
            private readonly string _filename;
            public EmptyVolativeToken(string filename) {
                _filename = filename;
            public bool IsCurrent {
                get {
                    if (Directory.Exists(_filename)) {
                        return false;
                    }
                    if (File.Exists(_filename)) {
                    return true;
                }
        public class FileToken : IVolatileToken {
            private readonly DateTime _lastWriteTimeUtc;
            public FileToken(string filename) {
                _lastWriteTimeUtc = File.GetLastWriteTimeUtc(filename);
                    try {
                        if (_lastWriteTimeUtc != File.GetLastWriteTimeUtc(_filename))
                            return false;
                    catch {
        public class DirectoryToken : IVolatileToken {
            public DirectoryToken(string filename) {
                _lastWriteTimeUtc = Directory.GetLastWriteTimeUtc(filename);
                        if (_lastWriteTimeUtc != Directory.GetLastWriteTimeUtc(_filename))
    }
}
