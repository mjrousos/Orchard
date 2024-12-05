using Orchard.ContentManagement;
using Orchard.Security;
using Orchard.UI.Admin;
using Orchard.DisplayManagement;
using Orchard.Localization;
using Orchard.Services;
using System.Web.Mvc;
using Orchard.Mvc.Filters;
﻿using System;
using Orchard.ContentManagement.Drivers;
using Orchard.FileSystems.Media;
using Orchard.MediaLibrary.Models;
using Orchard.MediaLibrary.Services;
using Orchard.UI.Notify;

namespace Orchard.MediaLibrary.MediaFileName {
    public class MediaFileNameDriver : ContentPartDriver<MediaPart> {
        private readonly IAuthenticationService _authenticationService;
        private readonly IAuthorizationService _authorizationService;
        private readonly IMediaLibraryService _mediaLibraryService;
        private readonly INotifier _notifier;
        public MediaFileNameDriver(IAuthorizationService authorizationService, IAuthenticationService authenticationService, IMediaLibraryService mediaLibraryService, INotifier notifier) {
            _authorizationService = authorizationService;
            _authenticationService = authenticationService;
            _mediaLibraryService = mediaLibraryService;
            _notifier = notifier;
            T = NullLocalizer.Instance;
        }
        public Localizer T { get; set; }
        protected override string Prefix {
            get { return "MediaFileName"; }
        protected override DriverResult Editor(MediaPart part, dynamic shapeHelper) {
            return Editor(part, null, shapeHelper);
        protected override DriverResult Editor(MediaPart part, IUpdateModel updater, dynamic shapeHelper) {
            return ContentShape(
                "Parts_Media_Edit_FileName",
                () => {
                    var currentUser = _authenticationService.GetAuthenticatedUser();
                    if (!_authorizationService.TryCheckAccess(Permissions.EditMediaContent, currentUser, part)) {
                        return null;
                    }
                    var settings = part.TypeDefinition.Settings.GetModel<MediaFileNameEditorSettings>();
                    if (!settings.ShowFileNameEditor) {
                    MediaFileNameEditorViewModel model = shapeHelper.Parts_Media_Edit_FileName(typeof(MediaFileNameEditorViewModel));
                    if (part.FileName != null) {
                        model.FileName = part.FileName;
                    if (updater != null) {
                        var priorFileName = model.FileName;
                        if (updater.TryUpdateModel(model, Prefix, null, null)) {
                            if (model.FileName != null && !model.FileName.Equals(priorFileName, StringComparison.OrdinalIgnoreCase)) {
                                var fieldName = "MediaFileNameEditorSettings.FileName";
                                try {
                                    _mediaLibraryService.RenameFile(part.FolderPath, priorFileName, model.FileName);
                                    part.FileName = model.FileName;
                                    _notifier.Add(NotifyType.Success, T("File '{0}' was renamed to '{1}'", priorFileName, model.FileName));
                                }
                                catch (OrchardException) {
                                    updater.AddModelError(fieldName, T("Unable to rename file. Invalid Windows file path."));
                                catch (InvalidNameCharacterException) {
                                    updater.AddModelError(fieldName, T("The file name contains invalid character(s)."));
                                catch (Exception exception) {
                                    updater.AddModelError(fieldName, T("Unable to rename file: {0}", exception.Message));
                            }
                        }
                    return model;
                });
    }
}
