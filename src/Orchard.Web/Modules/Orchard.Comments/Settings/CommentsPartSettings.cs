using Orchard.ContentManagement;
using Orchard.Security;
using Orchard.UI.Admin;
using Orchard.DisplayManagement;
using Orchard.Localization;
using Orchard.Services;
using System.Web.Mvc;
using Orchard.Mvc.Filters;
﻿namespace Orchard.Comments.Settings {
    public class CommentsPartSettings {
        public bool DefaultThreadedComments { get; set; }
        public bool MustBeAuthenticated { get; set; }
    }
}
