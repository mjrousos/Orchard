using Orchard.ContentManagement;
using Orchard.Security;
using Orchard.UI.Admin;
using Orchard.DisplayManagement;
using Orchard.Localization;
using Orchard.Services;
using System.Web.Mvc;
using Orchard.Mvc.Filters;
﻿using Orchard.ContentManagement.Records;

namespace Orchard.Projections.Models {
    public class NavigationQueryPartRecord : ContentPartRecord {
        /// <summary>
        /// Maximum number of items to retrieve from db
        /// </summary>
        public virtual int Items { get; set; }
        /// Number of items to skip
        public virtual int Skip { get; set; }
        /// The query to execute
        public virtual QueryPartRecord QueryPartRecord { get; set; }
    }
}
