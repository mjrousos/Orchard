using Orchard.ContentManagement;
using Orchard.Security;
using Orchard.UI.Admin;
using Orchard.DisplayManagement;
using Orchard.Localization;
using Orchard.Services;
using System.Web.Mvc;
using Orchard.Mvc.Filters;
﻿using Orchard.ContentManagement;

namespace Orchard.Projections.Models {
    /// <summary>
    /// This Content Part is used to create a link to FieldIndexRecord records, so
    /// that the Content Manager can query them. It will be attached dynamically whenever
    /// a custom field is found on a Content Type
    /// </summary>
    public class FieldIndexPart : ContentPart<FieldIndexPartRecord> {
    }
}
