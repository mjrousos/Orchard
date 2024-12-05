using Orchard.ContentManagement;
using Orchard.Security;
using Orchard.UI.Admin;
using Orchard.DisplayManagement;
using Orchard.Localization;
using Orchard.Services;
using System.Web.Mvc;
using Orchard.Mvc.Filters;
﻿using System.Web.Hosting;

namespace Orchard.FileSystems.AppData {
    /// <summary>
    /// Abstraction over the root location of "~/App_Data", mainly to enable
    /// unit testing of AppDataFolder.
    /// </summary>
    public interface IAppDataFolderRoot : ISingletonDependency {
        /// <summary>
        /// Virtual path of root ("~/App_Data")
        /// </summary>
        string RootPath { get; }
        /// Physical path of root (typically: MapPath(RootPath))
        string RootFolder { get; }
    }
    public class AppDataFolderRoot : IAppDataFolderRoot {
        public string RootPath {
            get { return "~/App_Data"; }
        }
        public string RootFolder {
            get { return HostingEnvironment.MapPath(RootPath); }
}
