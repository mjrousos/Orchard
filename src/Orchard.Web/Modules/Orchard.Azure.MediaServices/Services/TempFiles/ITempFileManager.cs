using Orchard.ContentManagement;
using Orchard.Security;
using Orchard.UI.Admin;
using Orchard.DisplayManagement;
using Orchard.Localization;
using Orchard.Services;
using System.Web.Mvc;
using Orchard.Mvc.Filters;
using System.IO;
using Orchard;

namespace Orchard.Azure.MediaServices.Services.TempFiles {
    /// <summary>
    /// Provides an abstraction of temporary file management.
    /// </summary>
    public interface ITempFileManager : IDependency {
        string GetPhysicalFilePath(string tempFileName);
        string CreateNewFileName(string extension);
        bool FileExists(string tempFileName);
        Stream LoadFile(string tempFileName);
        void SaveFile(string tempFileName, Stream stream);
        void DeleteFile(string tempFileName);
    }
}
