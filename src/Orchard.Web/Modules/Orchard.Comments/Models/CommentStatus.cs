using Orchard.ContentManagement;
using Orchard.Security;
using Orchard.UI.Admin;
using Orchard.DisplayManagement;
using Orchard.Localization;
using Orchard.Services;
using System.Web.Mvc;
using Orchard.Mvc.Filters;
using System;

namespace Orchard.Comments.Models {
    public enum CommentStatus {
        Pending,
        Approved,
        [Obsolete]
        Spam
    }
}
