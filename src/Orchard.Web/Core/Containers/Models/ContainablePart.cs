using Orchard.ContentManagement;
using Orchard.Security;
using Orchard.UI.Admin;
using Orchard.DisplayManagement;
using Orchard.Localization;
using Orchard.Services;
using System.Web.Mvc;
using Orchard.Mvc.Filters;
﻿using Orchard.ContentManagement;
using Orchard.ContentManagement.Records;

namespace Orchard.Core.Containers.Models {
    public class ContainablePart : ContentPart<ContainablePartRecord> {
        public int Position {
            get { return Record.Position; }
            set { Record.Position = value; }
        }
    }
    public class ContainablePartRecord : ContentPartRecord {
        public virtual int Position { get; set; }
}
