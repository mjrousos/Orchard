using Orchard.ContentManagement;
using Orchard.Security;
using Orchard.UI.Admin;
using Orchard.DisplayManagement;
using Orchard.Localization;
using Orchard.Services;
using System.Web.Mvc;
using Orchard.Mvc.Filters;
﻿namespace Orchard.MediaProcessing.Models {
    public class FileNameRecord {
        public virtual int Id { get; set; }
        public virtual string Path { get; set; }
        public virtual string FileName { get; set; }

        // Parent property
        public virtual ImageProfilePartRecord ImageProfilePartRecord { get; set; }
    }
}
