using Orchard.ContentManagement;
using Orchard.Security;
using Orchard.UI.Admin;
using Orchard.DisplayManagement;
using Orchard.Localization;
using Orchard.Services;
using System.Web.Mvc;
using Orchard.Mvc.Filters;
﻿using System.IO;
using Orchard.MediaLibrary.Models;

namespace Orchard.MediaLibrary.Factories {
    public interface IMediaFactory {
        MediaPart CreateMedia(Stream stream, string path, string mimeType, string contentType);
    }
    public class NullMediaFactory : IMediaFactory {
        public static IMediaFactory Instance {
            get { return new NullMediaFactory(); }
        }
        public MediaPart CreateMedia(Stream stream, string path, string mimeType, string contentType) {
            return null;
}
