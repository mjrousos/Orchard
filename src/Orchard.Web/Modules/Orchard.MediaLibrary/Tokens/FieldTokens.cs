using Orchard.ContentManagement;
using Orchard.Security;
using Orchard.UI.Admin;
using Orchard.DisplayManagement;
using Orchard.Localization;
using Orchard.Services;
using System.Web.Mvc;
using Orchard.Mvc.Filters;
﻿using System.Linq;
using Orchard.MediaLibrary.Fields;
using Orchard.MediaLibrary.Models;
using Orchard.Tokens;

namespace Orchard.MediaLibrary.Tokens {
    public class FieldTokens : ITokenProvider {
        private readonly IContentManager _contentManager;
        public FieldTokens(IContentManager contentManager) {
            _contentManager = contentManager;
            T = NullLocalizer.Instance;
        }
        public Localizer T { get; set; }
        public void Describe(DescribeContext context) {
            context.For("MediaLibraryPickerField", T("First media for Media Library Picker Field"), T("Tokens for Media Picker Fields"))
                .Token("Url", T("Url"), T("The url of the media."), "Url")
                .Token("MimeType", T("Mime Type"), T("The mime type of the media."), "Text")
                .Token("Caption", T("Caption"), T("The caption of the media."), "Text")
                .Token("AlternateText", T("Alternate Text"), T("The alternate text of the media."), "Text")
                .Token("FolderPath", T("Folder Path"), T("The hierarchical location of the media."), "Text")
                .Token("FileName", T("File Name"), T("The file name of the media, if applicable."), "Text")
                ;
        public void Evaluate(EvaluateContext context) {
            context.For<MediaLibraryPickerField>("MediaLibraryPickerField")
                .Token("Url", field => {
                    var mediaPart = MediaPart(field);
                    return mediaPart == null ? "" : mediaPart.MediaUrl;
                })
                .Chain("Url", "Url", field => {
                .Token("MimeType", field => {
                    return mediaPart == null ? "" : mediaPart.MimeType;
                .Chain("MimeType", "Text", field => {
                .Token("Caption", field => {
                    return mediaPart == null ? "" : mediaPart.Caption;
                .Chain("Caption", "Text", field => {
                .Token("AlternateText", field => {
                    return mediaPart == null ? "" : mediaPart.AlternateText;
                .Chain("AlternateText", "Text", field => {
                .Token("FolderPath", field => {
                    return mediaPart == null ? "" : mediaPart.FolderPath;
                .Chain("FolderPath", "Text", field => {
                .Token("FileName", field => {
                    return mediaPart == null ? "" : mediaPart.FileName;
                .Chain("FileName", "Text", field => {
        private MediaPart MediaPart(MediaLibraryPickerField field) {
            var mediaId = field.Ids.FirstOrDefault();
            return _contentManager.Get<MediaPart>(mediaId);
    }
}
