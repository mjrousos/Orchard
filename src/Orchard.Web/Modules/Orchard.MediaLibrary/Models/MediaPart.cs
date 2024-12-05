using Orchard.ContentManagement;
using Orchard.Security;
using Orchard.UI.Admin;
using Orchard.DisplayManagement;
using Orchard.Localization;
using Orchard.Services;
using System.Web.Mvc;
using Orchard.Mvc.Filters;
﻿using System;
using Orchard.ContentManagement.FieldStorage.InfosetStorage;
using Orchard.ContentManagement.Handlers;
using Orchard.ContentManagement.Utilities;
using Orchard.Core.Title.Models;
using Orchard.MediaLibrary.Handlers;

namespace Orchard.MediaLibrary.Models {
    public class MediaPart : ContentPart<MediaPartRecord> {
        internal LazyField<string> _publicUrl = new LazyField<string>();
        /// <summary>
        /// Gets or sets the title of the media.
        /// This adds an implicit dependency on <see cref="TitlePart"/> which will be resolved by an
        /// <see cref="ActivatingFilter{TPart}"/> in the <see cref="MediaPartHandler"/>.
        /// </summary>
        public string Title {
            get { return ContentItem.As<TitlePart>().Title; }
            set { ContentItem.As<TitlePart>().Title = value; }
        }
        /// Gets or sets the mime type of the media.
        public string MimeType {
            get { return Retrieve(x => x.MimeType); }
            set { Store(x => x.MimeType, value); }
        /// Gets or sets the caption of the media.
        public string Caption {
            get { return Retrieve(x => x.Caption); }
            set { Store(x => x.Caption, value); }
        /// Gets or sets the alternate text of the media.
        public string AlternateText {
            get { return Retrieve(x => x.AlternateText); }
            set { Store(x => x.AlternateText, value); }
        /// Gets or sets the hierarchical location of the media.
        public string FolderPath {
            get { return Retrieve(x => x.FolderPath); }
            set { Store(x => x.FolderPath, value); }
        /// Gets or sets the name of the media when <see cref="IMediaService"/> is used 
        /// to store the physical media. If <value>null</value> then the media is not associated
        /// with a local file.
        public string FileName {
            get { return Retrieve(x => x.FileName); }
            set { Store(x => x.FileName, value); }
        /// Gets the public Url of the media if stored locally.
        public string MediaUrl {
            get { return _publicUrl.Value; }
        /// Get or sets the logical type of the media. For instance a custom type could be rendered as an Image
        /// <remarks>
        /// The logical type is used to drive the thumbnails generation in the admin.
        /// </remarks>
        public string LogicalType {
            get { return Convert.ToString(this.As<InfosetPart>().Get<MediaPart>("LogicalType")); }
            set { this.As<InfosetPart>().Set<MediaPart>("LogicalType", value); }
    }
}
