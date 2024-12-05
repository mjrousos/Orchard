using Orchard.ContentManagement;
using Orchard.Security;
using Orchard.UI.Admin;
using Orchard.DisplayManagement;
using Orchard.Localization;
using Orchard.Services;
using System.Web.Mvc;
using Orchard.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.IO;
using System.Web;
using Orchard.Media.Models;

namespace Orchard.Media.Services {
    public interface IMediaService : IDependency {
        /// <summary>
        /// Retrieves the public path based on the relative path within the media directory.
        /// </summary>
        /// <example>
        /// "/Media/Default/InnerDirectory/Test.txt" based on the input "InnerDirectory/Test.txt"
        /// </example>
        /// <param name="relativePath">The relative path within the media directory.</param>
        /// <returns>The public path relative to the application url.</returns>
        string GetPublicUrl(string relativePath);
        /// Returns the public URL for a media file.
        /// <param name="mediaPath">The relative path of the media folder containing the media.</param>
        /// <param name="fileName">The media file name.</param>
        /// <returns>The public URL for the media.</returns>
        string GetMediaPublicUrl(string mediaPath, string fileName);
        /// Retrieves the media folders within a given relative path.
        /// <param name="relativePath">The path where to retrieve the media folder from. null means root.</param>
        /// <returns>The media folder in the given path.</returns>
        IEnumerable<MediaFolder> GetMediaFolders(string relativePath);
        /// Retrieves the media files within a given relative path.
        /// <param name="relativePath">The path where to retrieve the media files from. null means root.</param>
        /// <returns>The media files in the given path.</returns>
        IEnumerable<MediaFile> GetMediaFiles(string relativePath);
        /// Creates a media folder.
        /// <param name="relativePath">The path where to create the new folder. null means root.</param>
        /// <param name="folderName">The name of the folder to be created.</param>
        void CreateFolder(string relativePath, string folderName);
        /// Deletes a media folder.
        /// <param name="folderPath">The path to the folder to be deleted.</param>
        void DeleteFolder(string folderPath);
        /// Renames a media folder.
        /// <param name="folderPath">The path to the folder to be renamed.</param>
        /// <param name="newFolderName">The new folder name.</param>
        void RenameFolder(string folderPath, string newFolderName);
        /// Deletes a media file.
        /// <param name="folderPath">The folder path.</param>
        /// <param name="fileName">The file name.</param>
        void DeleteFile(string folderPath, string fileName);
        /// Renames a media file.
        /// <param name="folderPath">The path to the file's parent folder.</param>
        /// <param name="currentFileName">The current file name.</param>
        /// <param name="newFileName">The new file name.</param>
        void RenameFile(string folderPath, string currentFileName, string newFileName);
        /// Moves a media file.
        /// <param name="currentPath">The path to the file's parent folder.</param>
        /// <param name="newPath">The path where the file will be moved to.</param>
        void MoveFile(string fileName, string currentPath, string newPath);
        /// Uploads a media file based on a posted file.
        /// <param name="folderPath">The path to the folder where to upload the file.</param>
        /// <param name="postedFile">The file to upload.</param>
        /// <param name="extractZip">Boolean value indicating weather zip files should be extracted.</param>
        /// <returns>The path to the uploaded file.</returns>
        string UploadMediaFile(string folderPath, HttpPostedFileBase postedFile, bool extractZip);
        /// Uploads a media file based on an array of bytes.
        /// <param name="bytes">The array of bytes with the file's contents.</param>
        string UploadMediaFile(string folderPath, string fileName, byte[] bytes, bool extractZip);
        /// Uploads a media file based on a stream.
        /// <param name="folderPath">The folder path to where to upload the file.</param>
        /// <param name="inputStream">The stream with the file's contents.</param>
        string UploadMediaFile(string folderPath, string fileName, Stream inputStream, bool extractZip);
        /// Verifies if a file is allowed based on its name and the policies defined by the black / white lists.
        /// <param name="postedFile">The posted file</param>
        /// <returns>True if the file is allowed; false if otherwise.</returns>
        bool FileAllowed(HttpPostedFileBase postedFile);
        /// <param name="fileName">The file name of the file to validate.</param>
        /// <param name="allowZip">Boolean value indicating weather zip files are allowed.</param>
        bool FileAllowed(string fileName, bool allowZip);
    }
}
