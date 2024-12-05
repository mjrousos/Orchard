using Orchard.ContentManagement;
using Orchard.Security;
using Orchard.UI.Admin;
using Orchard.DisplayManagement;
using Orchard.Localization;
using Orchard.Services;
using System.Web.Mvc;
using Orchard.Mvc.Filters;
﻿using Orchard.Data.Conventions;
using Orchard.Environment.Extensions;

namespace Orchard.Localization.Models {
    [OrchardFeature("Orchard.Localization.Transliteration")]
    public class TransliterationSpecificationRecord {
        public virtual int Id { get; set; }
        public virtual string CultureFrom { get; set; }
        public virtual string CultureTo { get; set; }
        [StringLengthMax]
        public virtual string Rules { get; set; }
    }
}
