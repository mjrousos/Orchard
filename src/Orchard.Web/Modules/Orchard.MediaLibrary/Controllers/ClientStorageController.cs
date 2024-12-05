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
using Orchard.ContentManagement.Handlers;
using Orchard.FileSystems.Media;
using Orchard.Logging;
using Orchard.MediaLibrary.Models;
using Orchard.MediaLibrary.Services;
using Orchard.MediaLibrary.ViewModels;
using Orchard.Themes;

namespace Orchard.MediaLibrary.Controllers {
    [Admin, Themed(false)]
    public class ClientStorageController : Controller {
        private readonly IMediaLibraryService _mediaLibraryService;
        private readonly IMimeTypeProvider _mimeTypeProvider;
        private readonly IEnumerable<IContentHandler> _handlers;
        public ClientStorageController(
            IMediaLibraryService mediaManagerService,
            IOrchardServices orchardServices,
            IMimeTypeProvider mimeTypeProvider,
            IEnumerable<IContentHandler> handlers) {
            _mediaLibraryService = mediaManagerService;
            _mimeTypeProvider = mimeTypeProvider;
            _handlers = handlers;
            Services = orchardServices;
            T = NullLocalizer.Instance;
            Logger = NullLogger.Instance;
        }
        public IOrchardServices Services { get; set; }
        public Localizer T { get; set; }
        public ILogger Logger { get; set; }
        public ActionResult Index(string folderPath, string type, int? replaceId = null) {
            if (!_mediaLibraryService.CheckMediaFolderPermission(Permissions.SelectMediaContent, folderPath)) {
                return new HttpUnauthorizedResult();
            }
            // Check permission
            if (!_mediaLibraryService.CanManageMediaFolder(folderPath)) {
            var viewModel = new ImportMediaViewModel {
                FolderPath = folderPath,
                Type = type,
            };
            if (replaceId != null) {
                var replaceMedia = Services.ContentManager.Get<MediaPart>(replaceId.Value);
                if (replaceMedia == null)
                    return HttpNotFound();
                viewModel.Replace = replaceMedia;
            return View(viewModel);
        [HttpPost]
        public ActionResult Upload(string folderPath, string type) {
            if (!_mediaLibraryService.CheckMediaFolderPermission(Permissions.ImportMediaContent, folderPath)) {
            var statuses = new List<object>();
            var settings = Services.WorkContext.CurrentSite.As<MediaLibrarySettingsPart>();
            // Loop through each file in the request
            for (int i = 0; i < HttpContext.Request.Files.Count; i++) {
                // Pointer to file
                var file = HttpContext.Request.Files[i];
                var filename = Path.GetFileName(file.FileName);
                // if the file has been pasted, provide a default name
                if (file.ContentType.Equals("image/png", StringComparison.InvariantCultureIgnoreCase) && !filename.EndsWith(".png", StringComparison.InvariantCultureIgnoreCase)) {
                    filename = "clipboard.png";
                }
                // skip file if the allowed extensions is defined and doesn't match
                if (!settings.IsFileAllowed(filename)) {
                    statuses.Add(new {
                        error = T("This file is not allowed: {0}", filename).Text,
                        progress = 1.0,
                    });
                    continue;
                try {
                    var mediaPart = _mediaLibraryService.ImportMedia(file.InputStream, folderPath, filename, type);
                    Services.ContentManager.Create(mediaPart);
                        id = mediaPart.Id,
                        name = mediaPart.Title,
                        type = mediaPart.MimeType,
                        size = file.ContentLength,
                        url = mediaPart.FileName,
                catch (InvalidNameCharacterException) {
                        error = T("The file name contains invalid character(s)").Text,
                catch (Exception ex) {
                    Logger.Error(ex, T("Unexpected exception when uploading a media.").Text);
                        error = ex.Message,
            // Return JSON
            return Json(statuses, JsonRequestBehavior.AllowGet);
        public ActionResult Replace(int replaceId, string type) {
            if (!Services.Authorizer.Authorize(Permissions.ManageOwnMedia))
            var replaceMedia = Services.ContentManager.Get<MediaPart>(replaceId);
            if (replaceMedia == null)
                return HttpNotFound();
            if (!(_mediaLibraryService.CheckMediaFolderPermission(Permissions.EditMediaContent, replaceMedia.FolderPath) && _mediaLibraryService.CheckMediaFolderPermission(Permissions.ImportMediaContent, replaceMedia.FolderPath))
                && !_mediaLibraryService.CanManageMediaFolder(replaceMedia.FolderPath)) {
                if (file.ContentType.Equals("image/png", StringComparison.InvariantCultureIgnoreCase)
                    && !filename.EndsWith(".png", StringComparison.InvariantCultureIgnoreCase)) {
                    var mimeType = _mimeTypeProvider.GetMimeType(filename);
                    string replaceContentType = _mediaLibraryService.MimeTypeToContentType(file.InputStream, mimeType, type) ?? type;
                    if (!replaceContentType.Equals(replaceMedia.TypeDefinition.Name, StringComparison.OrdinalIgnoreCase))
                        throw new Exception(T("Cannot replace {0} with {1}", replaceMedia.TypeDefinition.Name, replaceContentType).Text);
                    // Raise update and publish events which will update relevant Media properties
                    _handlers.Invoke(x => x.Updating(new UpdateContentContext(replaceMedia.ContentItem)), Logger);
                    var mediaItemsUsingTheFile = Services.ContentManager.Query<MediaPart, MediaPartRecord>()
                                                                .ForVersion(VersionOptions.Latest)
                                                                .Where(x => x.FolderPath == replaceMedia.FolderPath && x.FileName == replaceMedia.FileName)
                                                                .Count();
                    if (mediaItemsUsingTheFile == 1) { // if the file is referenced only by the deleted media content, the file too can be removed.
                        try {
                            _mediaLibraryService.DeleteFile(replaceMedia.FolderPath, replaceMedia.FileName);
                        }
                        catch (ArgumentException) { // File not found by FileSystemStorageProvider is thrown as ArgumentException.
                            statuses.Add(new {
                                error = T("Error when deleting file to replace: file {0} does not exist in folder {1}. Media has been updated anyway.", replaceMedia.FileName, replaceMedia.FolderPath).Text,
                                progress = 1.0
                            });
                    }
                    else {
                        // it changes the media file name
                        replaceMedia.FileName = filename;
                    _mediaLibraryService.UploadMediaFile(replaceMedia.FolderPath, replaceMedia.FileName, file.InputStream);
                    replaceMedia.MimeType = mimeType;
                    _handlers.Invoke(x => x.Updated(new UpdateContentContext(replaceMedia.ContentItem)), Logger);
                    var publishedVersion = replaceMedia.ContentItem.Record.Versions.SingleOrDefault(v => v.Published);
                    _handlers.Invoke(x => x.Publishing(new PublishContentContext(replaceMedia.ContentItem, publishedVersion)), Logger);
                    _handlers.Invoke(x => x.Published(new PublishContentContext(replaceMedia.ContentItem, publishedVersion)), Logger);
                        id = replaceMedia.Id,
                        name = replaceMedia.Title,
                        type = replaceMedia.MimeType,
                        url = replaceMedia.FileName,
                        error = T(ex.Message).Text,
    }
}
