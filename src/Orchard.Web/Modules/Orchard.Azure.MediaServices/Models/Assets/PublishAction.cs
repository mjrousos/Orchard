using Orchard.ContentManagement;
using Orchard.Security;
using Orchard.UI.Admin;
using Orchard.DisplayManagement;
using Orchard.Localization;
using Orchard.Services;
using System.Web.Mvc;
using Orchard.Mvc.Filters;
using System;
using System.Collections.Generic;
using Orchard.ContentManagement.Records;
using Orchard.Core.Common.Utilities;

namespace Orchard.Azure.MediaServices.Models.Assets {
    public enum PublishAction {
        None,
        Publish,
        PublishLater
    }
}
