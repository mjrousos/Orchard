using Orchard.ContentManagement;
using Orchard.Security;
using Orchard.UI.Admin;
using Orchard.DisplayManagement;
using Orchard.Localization;
using Orchard.Services;
using System.Web.Mvc;
using Orchard.Mvc.Filters;
﻿using Orchard.ContentManagement.Records;
using System.ComponentModel.DataAnnotations;

namespace Orchard.Autoroute.Models {
    public class AutoroutePartRecord : ContentPartVersionRecord {
        public virtual bool UseCustomPattern { get; set; }
        public virtual bool UseCulturePattern { get; set; }
        
        [StringLength(2048)]
        public virtual string CustomPattern { get; set; }
        public virtual string DisplayAlias { get; set; }
    }
}
