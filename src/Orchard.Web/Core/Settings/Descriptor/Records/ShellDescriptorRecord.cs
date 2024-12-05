using Orchard.ContentManagement;
using Orchard.Security;
using Orchard.UI.Admin;
using Orchard.DisplayManagement;
using Orchard.Localization;
using Orchard.Services;
using System.Web.Mvc;
using Orchard.Mvc.Filters;
﻿using System.Collections.Generic;
using Orchard.Data.Conventions;

namespace Orchard.Core.Settings.Descriptor.Records {
    public class ShellDescriptorRecord {
        public ShellDescriptorRecord() {
            Features=new List<ShellFeatureRecord>();
            Parameters=new List<ShellParameterRecord>();
        }
        public virtual int Id { get; set; }
        public virtual int SerialNumber { get; set; }
        
        [CascadeAllDeleteOrphan]
        public virtual IList<ShellFeatureRecord> Features { get; set; }
        public virtual IList<ShellParameterRecord> Parameters { get; set; }
    }
}
