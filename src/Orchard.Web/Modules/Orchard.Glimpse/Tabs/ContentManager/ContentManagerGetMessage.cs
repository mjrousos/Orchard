using Orchard.ContentManagement;
using Orchard.Security;
using Orchard.UI.Admin;
using Orchard.DisplayManagement;
using Orchard.Localization;
using Orchard.Services;
using System.Web.Mvc;
using Orchard.Mvc.Filters;
﻿using System;
using Glimpse.Core.Message;
using Orchard.Glimpse.Models;

namespace Orchard.Glimpse.Tabs.ContentManager {
    public class ContentManagerGetMessage : MessageBase, IDurationMessage {
        public int ContentId { get; set; }
        public string Name { get; set; }
        public string ContentType { get; set; }
        public VersionOptions VersionOptions { get; set; }
        public TimeSpan Duration { get; set; }
    }
}
