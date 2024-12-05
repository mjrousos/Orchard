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
using System.Linq;
using System.Web;
using Orchard.ContentManagement.MetaData.Builders;

namespace Orchard.ContentManagement.MetaData {
    public static class MediaMetaDataExtensions {
        /// <summary>
        /// This extension method can be used for easy image part creation. Adds all necessary parts and settings to the part.
        /// </summary>
        public static ContentTypeDefinitionBuilder AsImage(this ContentTypeDefinitionBuilder builder) {
            return builder
                .AsMedia()
                .WithPart("ImagePart");
        }
        /// This extension method can be used for easy vector image part creation. Adds all necessary parts and settings to the part.
        public static ContentTypeDefinitionBuilder AsVectorImage(this ContentTypeDefinitionBuilder builder) {
                .WithPart("VectorImagePart");
        /// This extension method can be used for easy audio part creation. Adds all necessary parts and settings to the part.
        public static ContentTypeDefinitionBuilder AsAudio(this ContentTypeDefinitionBuilder builder) {
                .WithPart("AudioPart");
        /// This extension method can be used for video image part creation. Adds all necessary parts and settings to the part.
        public static ContentTypeDefinitionBuilder AsVideo(this ContentTypeDefinitionBuilder builder) {
                .WithPart("VideoPart");
        /// This extension method can be used for easy document part creation. Adds all necessary parts and settings to the part.
        public static ContentTypeDefinitionBuilder AsDocument(this ContentTypeDefinitionBuilder builder) {
                .WithPart("DocumentPart");
        /// This extension method can be used for easy media part creation. Adds all necessary parts and settings to the part.
        public static ContentTypeDefinitionBuilder AsMedia(this ContentTypeDefinitionBuilder builder) {
                .WithSetting("Stereotype", "Media")
                .WithPart("CommonPart")
                .WithPart("MediaPart")
                .WithPart("TitlePart");
    }
}
