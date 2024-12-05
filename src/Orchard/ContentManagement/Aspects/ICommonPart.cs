using Orchard.ContentManagement;
using Orchard.Security;
using Orchard.UI.Admin;
using Orchard.DisplayManagement;
using Orchard.Localization;
using Orchard.Services;
using System.Web.Mvc;
using Orchard.Mvc.Filters;
﻿using System;

namespace Orchard.ContentManagement.Aspects {
    public interface ICommonPart : IContent {
        IUser Owner { get; set; }
        IContent Container { get; set; }
        DateTime? CreatedUtc { get; set; }
        DateTime? PublishedUtc { get; set; }
        DateTime? ModifiedUtc { get; set; }
        DateTime? VersionCreatedUtc { get; set; }
        DateTime? VersionPublishedUtc { get; set; }
        DateTime? VersionModifiedUtc { get; set; }
        string VersionModifiedBy { get; set; }
    }
}
