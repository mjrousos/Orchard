using Orchard.ContentManagement;
using Orchard.Security;
using Orchard.UI.Admin;
using Orchard.DisplayManagement;
using Orchard.Localization;
using Orchard.Services;
using System.Web.Mvc;
using Orchard.Mvc.Filters;
﻿using System.Collections.Generic;
using System.Xml.Serialization;
using Orchard.ContentManagement.Records;
using Orchard.Data.Conventions;

namespace Orchard.Projections.Models {
    public class QueryPartRecord : ContentPartRecord {
        public QueryPartRecord() {
            VersionScope = QueryVersionScopeOptions.Published;
            FilterGroups = new List<FilterGroupRecord>();
            SortCriteria = new List<SortCriterionRecord>();
            Layouts = new List<LayoutRecord>();
        }
        public virtual QueryVersionScopeOptions VersionScope { get; set; }
        [CascadeAllDeleteOrphan, Aggregate]
        [XmlArray("FilterGroupRecords")]
        public virtual IList<FilterGroupRecord> FilterGroups { get; set; }
        [XmlArray("SortCriteria")]
        public virtual IList<SortCriterionRecord> SortCriteria { get; set; }
        [XmlArray("Layouts")]
        public virtual IList<LayoutRecord> Layouts { get; set; }
    }
}
