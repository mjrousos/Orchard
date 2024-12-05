using Orchard.ContentManagement;
using Orchard.Security;
using Orchard.UI.Admin;
using Orchard.DisplayManagement;
using Orchard.Localization;
using Orchard.Services;
using System.Web.Mvc;
using Orchard.Mvc.Filters;
﻿using System;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using Orchard.ContentManagement.MetaData;
using Orchard.MediaLibrary.Models;

namespace Orchard.MediaLibrary.Factories {
    public class ImageFactorySelector : IMediaFactorySelector {
        private readonly IContentManager _contentManager;
        private readonly IContentDefinitionManager _contentDefinitionManager;
        public ImageFactorySelector(IContentManager contentManager, IContentDefinitionManager contentDefinitionManager) {
            _contentManager = contentManager;
            _contentDefinitionManager = contentDefinitionManager;
        }
        public MediaFactorySelectorResult GetMediaFactory(Stream stream, string mimeType, string contentType) {
            if (!mimeType.StartsWith("image/")) {
                return null;
            }
            if (!ImageCodecInfo.GetImageDecoders().Select(d => d.MimeType).Contains(mimeType)) {
            if (!String.IsNullOrEmpty(contentType)) {
                var contentDefinition = _contentDefinitionManager.GetTypeDefinition(contentType);
                if (contentDefinition == null || contentDefinition.Parts.All(x => x.PartDefinition.Name != typeof(ImagePart).Name)) {
                    return null;
                }
            return new MediaFactorySelectorResult {
                Priority = -5,
                MediaFactory = new ImageFactory(_contentManager)
            };
    }
    public class ImageFactory : IMediaFactory {
        public ImageFactory(IContentManager contentManager) {
        public MediaPart CreateMedia(Stream stream, string path, string mimeType, string contentType) {
            if (String.IsNullOrEmpty(contentType)) {
                contentType = "Image";
            var part = _contentManager.New<MediaPart>(contentType);
            part.LogicalType = "Image";
            part.MimeType = mimeType;
            part.Title = Path.GetFileNameWithoutExtension(path);
            var imagePart = part.As<ImagePart>();
            if (imagePart == null) {
            return part;
}
