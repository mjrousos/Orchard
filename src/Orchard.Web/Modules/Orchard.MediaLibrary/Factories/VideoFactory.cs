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
using System.Linq;
using Orchard.ContentManagement.MetaData;
using Orchard.MediaLibrary.Models;

namespace Orchard.MediaLibrary.Factories {
    public class VideoFactorySelector : IMediaFactorySelector {
        private readonly IContentManager _contentManager;
        private readonly IContentDefinitionManager _contentDefinitionManager;
        public VideoFactorySelector(IContentManager contentManager, IContentDefinitionManager contentDefinitionManager) {
            _contentManager = contentManager;
            _contentDefinitionManager = contentDefinitionManager;
        }
        public MediaFactorySelectorResult GetMediaFactory(Stream stream, string mimeType, string contentType) {
            if (!mimeType.StartsWith("video/")) {
                return null;
            }
            if (!String.IsNullOrEmpty(contentType)) {
                var contentDefinition = _contentDefinitionManager.GetTypeDefinition(contentType);
                if (contentDefinition == null || contentDefinition.Parts.All(x => x.PartDefinition.Name != typeof(VideoPart).Name)) {
                    return null;
                }
            return new MediaFactorySelectorResult {
                Priority = -5,
                MediaFactory = new VideoFactory(_contentManager)
            };
    }
    public class VideoFactory : IMediaFactory {
        public VideoFactory(IContentManager contentManager) {
        public MediaPart CreateMedia(Stream stream, string path, string mimeType, string contentType) {
            if (String.IsNullOrEmpty(contentType)) {
                contentType = "Video";
            var part = _contentManager.New<MediaPart>(contentType);
            part.LogicalType = "Video";
            part.MimeType = mimeType;
            part.Title = Path.GetFileNameWithoutExtension(path);
            var videoPart = part.As<VideoPart>();
            if (videoPart == null) {
            return part;
}
