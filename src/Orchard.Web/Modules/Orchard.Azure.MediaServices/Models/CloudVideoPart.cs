using Orchard.ContentManagement;
using Orchard.Security;
using Orchard.UI.Admin;
using Orchard.DisplayManagement;
using Orchard.Localization;
using Orchard.Services;
using System.Web.Mvc;
using Orchard.Mvc.Filters;
﻿using System.Collections.Generic;
using System.Linq;
using Orchard.Azure.MediaServices.Models.Assets;
using Orchard.Azure.MediaServices.Models.Jobs;
using Orchard.Azure.MediaServices.Services.Assets;
using Orchard.Azure.MediaServices.Services.Jobs;

namespace Orchard.Azure.MediaServices.Models {
    public class CloudVideoPart : ContentPart {
        public IAssetManager _assetManager;
        internal IJobManager _jobManager;
        public IEnumerable<Asset> Assets {
            get { return _assetManager.LoadAssetsFor(this); }
        }
        public MezzanineAsset MezzanineAsset {
            get { return (MezzanineAsset)Assets.FirstOrDefault(x => x is MezzanineAsset); }
        public IEnumerable<Job> Jobs {
            get { return _jobManager.GetJobsFor(this); }
        public bool PublishOnUpload {
            get { return this.Retrieve(x => x.PublishOnUpload); }
            set { this.Store(x => x.PublishOnUpload, value); }
        public ThumbnailAsset ThumbnailAsset {
            get { return _assetManager.GetThumbnailAssetFor(this); }
    }
}
