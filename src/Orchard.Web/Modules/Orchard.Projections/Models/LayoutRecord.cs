using Orchard.ContentManagement;
using Orchard.Security;
using Orchard.UI.Admin;
using Orchard.DisplayManagement;
using Orchard.Localization;
using Orchard.Services;
using System.Web.Mvc;
using Orchard.Mvc.Filters;
﻿using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Orchard.Data.Conventions;

namespace Orchard.Projections.Models {
    public class LayoutRecord {
        public LayoutRecord() {
            Properties = new List<PropertyRecord>();    
        }
        public virtual int Id { get; set; }
        public virtual string GUIdentifier { get; set; }
        public virtual string Description { get; set; }
        public virtual string Category { get; set; }
        public virtual string Type { get; set; }
        [StringLengthMax]
        public virtual string State { get; set; }
        public virtual int Display { get; set; }
        [StringLength(64)]
        public virtual string DisplayType { get; set; }
        // Parent property
        public virtual QueryPartRecord QueryPartRecord { get; set; }
        [CascadeAllDeleteOrphan, Aggregate]
        public virtual IList<PropertyRecord> Properties { get; set; }
        public virtual PropertyRecord GroupProperty { get; set; }
        public enum Displays {
            Content,
            Properties
    }
}
