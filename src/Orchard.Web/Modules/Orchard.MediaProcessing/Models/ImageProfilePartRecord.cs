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

namespace Orchard.MediaProcessing.Models {
    public class ImageProfilePartRecord : ContentPartRecord {
        public ImageProfilePartRecord() {
            Filters = new List<FilterRecord>();
            FileNames = new List<FileNameRecord>();
        }
        public virtual string Name { get; set; }
        [CascadeAllDeleteOrphan, Aggregate]
        [XmlArray("FilterRecords")]
        public virtual IList<FilterRecord> Filters { get; set; }
        [XmlArray("FileNameRecords")]
        public virtual IList<FileNameRecord> FileNames { get; set; }
    }
}
