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

namespace Orchard.Core.Title.Models {
    public class TitlePartRecord : ContentPartVersionRecord {
        [StringLength(1024)]
        public virtual string Title { get; set; }
    }
}
