using Orchard.ContentManagement;
using Orchard.Security;
using Orchard.UI.Admin;
using Orchard.DisplayManagement;
using Orchard.Localization;
using Orchard.Services;
using System.Web.Mvc;
using Orchard.Mvc.Filters;
﻿using System;
using System.IO;

namespace Orchard.FileSystems.Media {
    public interface IStorageFile {
        string GetPath();
        string GetName();
        long GetSize();
        DateTime GetLastUpdated();
        string GetFileType();
        
        /// <summary>
        /// Creates a stream for reading from the file.
        /// </summary>
        Stream OpenRead();
        /// Creates a stream for writing to the file.
        Stream OpenWrite();
        /// Creates a stream for writing to the file, and truncates the existing content.
        Stream CreateFile();
    }
}
