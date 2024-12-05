using Orchard.ContentManagement;
using Orchard.Security;
using Orchard.UI.Admin;
using Orchard.DisplayManagement;
using Orchard.Localization;
using Orchard.Services;
using System.Web.Mvc;
using Orchard.Mvc.Filters;
﻿using System.ComponentModel.DataAnnotations;

namespace Orchard.Comments.Models {
    public class CommentSettingsPart : ContentPart {
        public bool ModerateComments {
            get { return this.Retrieve(x => x.ModerateComments); }
            set { this.Store(x => x.ModerateComments, value); }
        }
        [Required, Range(0, 999)]
        public int ClosedCommentsDelay {
            get { return this.Retrieve(x => x.ClosedCommentsDelay); }
            set { this.Store(x => x.ClosedCommentsDelay, value); }
        public bool NotificationEmail {
            get { return this.Retrieve(x => x.NotificationEmail); }
            set { this.Store(x => x.NotificationEmail, value); }
    }
}
