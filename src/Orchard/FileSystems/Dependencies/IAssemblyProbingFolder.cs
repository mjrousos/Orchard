using Orchard.ContentManagement;
using Orchard.Security;
using Orchard.UI.Admin;
using Orchard.DisplayManagement;
using Orchard.Localization;
using Orchard.Services;
using System.Web.Mvc;
using Orchard.Mvc.Filters;
﻿using System;
using System.Reflection;
using Orchard.Caching;

namespace Orchard.FileSystems.Dependencies {
    /// <summary>
    /// Abstraction over the folder configued in web.config as an additional 
    /// location to load assemblies from. This assumes a local physical file system,
    /// since Orchard will need to store assembly files locally.
    /// </summary>
    public interface IAssemblyProbingFolder : IVolatileProvider {
        /// <summary>
        /// Return "true" if the assembly corresponding to "moduleName" is
        /// present in the folder.
        /// </summary>
        bool AssemblyExists(string moduleName);
        /// Return the last modification date of the assembly corresponding
        /// to "moduleName". The assembly must be exist on disk, otherwise an
        /// exception is thrown.
        DateTime GetAssemblyDateTimeUtc(string moduleName);
        /// Return the virtual path of the assembly (optional)
        string GetAssemblyVirtualPath(string moduleName);
        /// Load the assembly corresponding to "moduleName" if the assembly file
        /// is present in the folder.
        Assembly LoadAssembly(string moduleName);
        /// Ensure the assembly corresponding to "moduleName" is removed from the folder
        void DeleteAssembly(string moduleName);
        /// Store an assembly corresponding to "moduleName" from the given fileName
        void StoreAssembly(string moduleName, string fileName);
    }
}
