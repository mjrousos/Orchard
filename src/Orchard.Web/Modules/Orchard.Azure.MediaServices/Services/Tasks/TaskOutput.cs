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

namespace Orchard.Azure.MediaServices.Services.Tasks {
    /// <summary>
    /// Represents an output asset for a task.
    /// </summary>
    public class TaskOutput {
        public TaskOutput(int index, string assetType, string assetName) {
            Index = index;
            AssetType = assetType;
            AssetName = assetName;
        }
        /// <summary>
        /// Gets the position of the output asset in relation to other output assets of the same task.
        /// </summary>
        public int Index {
            get;
            private set;
        /// Gets the type of the output asset.
        public string AssetType {
        /// Gets the suggested name of the output asset.
        public string AssetName {
    }
}
