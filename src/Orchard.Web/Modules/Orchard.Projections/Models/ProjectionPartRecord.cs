using Orchard.ContentManagement;
using Orchard.Security;
using Orchard.UI.Admin;
using Orchard.DisplayManagement;
using Orchard.Localization;
using Orchard.Services;
using System.Web.Mvc;
using Orchard.Mvc.Filters;
﻿using System.ComponentModel.DataAnnotations;
using Orchard.ContentManagement.Records;
using Orchard.Data.Conventions;

namespace Orchard.Projections.Models {
    public class ProjectionPartRecord : ContentPartRecord {
        public ProjectionPartRecord() {
            MaxItems = 20;
        }
        /// <summary>
        /// Maximum number of items to retrieve from db
        /// </summary>
        public virtual int Items { get; set; }
        /// Number of items per page
        public virtual int ItemsPerPage { get; set; }
        /// Number of items to skip
        public virtual int Skip { get; set; }
        /// Suffix to use when multiple pagers are available on the same page
        [StringLength(255)]
        public virtual string PagerSuffix { get; set; }
        /// The maximum number of items which can be requested at once. 
        public virtual int MaxItems { get; set; }
        /// True to render a pager
        public virtual bool DisplayPager { get; set; }
        /// The query to execute
        [Aggregate]
        public virtual QueryPartRecord QueryPartRecord { get; set; }
        /// The layout to render
        public virtual LayoutRecord LayoutRecord { get; set; }
    }
}
