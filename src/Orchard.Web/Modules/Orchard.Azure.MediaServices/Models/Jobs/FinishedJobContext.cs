using Orchard.ContentManagement;
using Orchard.Security;
using Orchard.UI.Admin;
using Orchard.DisplayManagement;
using Orchard.Localization;
using Orchard.Services;
using System.Web.Mvc;
using Orchard.Mvc.Filters;
﻿using Orchard.Azure.MediaServices.Models.Records;
using Microsoft.WindowsAzure.MediaServices.Client;

namespace Orchard.Azure.MediaServices.Models.Jobs {
    public class FinishedJobContext {
        public CloudVideoPart CloudVideoPart { get; set; }
        public JobRecord JobRecord { get; set; }
        public IJob Job { get; set; }
    }
}
