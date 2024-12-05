using Orchard.ContentManagement;
using Orchard.Security;
using Orchard.UI.Admin;
using Orchard.DisplayManagement;
using Orchard.Localization;
using Orchard.Services;
using System.Web.Mvc;
using Orchard.Mvc.Filters;
﻿using System;
using Orchard.ContentManagement.Records;

namespace Orchard.Core.Containers.Models {
    [Obsolete("Use content fields instead.")]
    public class CustomPropertiesPart : ContentPart<CustomPropertiesPartRecord> {
    }
    public class CustomPropertiesPartRecord : ContentPartRecord {
        public virtual string CustomOne { get; set; }
        public virtual string CustomTwo { get; set; }
        public virtual string CustomThree { get; set; }
}
