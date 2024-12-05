using Orchard.ContentManagement;
using Orchard.Security;
using Orchard.UI.Admin;
using Orchard.DisplayManagement;
using Orchard.Localization;
using Orchard.Services;
using System.Web.Mvc;
using Orchard.Mvc.Filters;
﻿using System.Collections.Generic;

namespace Orchard.Email.Models {
    public class EmailMessage {
        public string Subject { get; set; }
        public string Body { get; set; }
        public string Recipients { get; set; }
        public string ReplyTo { get; set; }
        public string FromAddress { get; set; }
        public string FromName { get; set; }
        public string Bcc { get; set; }
        public string Cc { get; set; }
        public bool NotifyReadEmail { get; set; }
        /// <summary>
        /// IEnumerable of strings representing attachments paths
        /// </summary>
        public IEnumerable<string> Attachments { get; set; }
    }
}
