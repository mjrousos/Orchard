using Orchard.ContentManagement;
using Orchard.Security;
using Orchard.UI.Admin;
using Orchard.DisplayManagement;
using Orchard.Localization;
using Orchard.Services;
using System.Web.Mvc;
using Orchard.Mvc.Filters;
﻿using Orchard.Data.Conventions;

namespace Orchard.Core.Settings.Metadata.Records {
    public class ContentPartFieldDefinitionRecord {
        public virtual int Id { get; set; }
        public virtual ContentFieldDefinitionRecord ContentFieldDefinitionRecord { get; set; }
        public virtual string Name { get; set; }
        [StringLengthMax]
        public virtual string Settings { get; set; }
    }
}
