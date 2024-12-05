using Orchard.ContentManagement;
using Orchard.Security;
using Orchard.UI.Admin;
using Orchard.DisplayManagement;
using Orchard.Localization;
using Orchard.Services;
using System.Web.Mvc;
using Orchard.Mvc.Filters;
﻿using Orchard.ContentManagement;

namespace Orchard.Projections.Models {
    public class NavigationQueryPart : ContentPart<NavigationQueryPartRecord> {
        /// <summary>
        /// Maximum number of items to retrieve from db
        /// </summary>
        public virtual int Items {
            get { return Record.Items; }
            set { Record.Items = value; }
        }
        /// Number of items to skip
        public virtual int Skip {
            get { return Record.Skip; }
            set { Record.Skip = value; }
        /// The query to execute
        public virtual QueryPartRecord QueryPartRecord {
            get { return Record.QueryPartRecord; }
            set { Record.QueryPartRecord = value; }
    }
}
