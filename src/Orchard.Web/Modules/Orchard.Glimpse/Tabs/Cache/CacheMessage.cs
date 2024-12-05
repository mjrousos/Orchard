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

namespace Orchard.Glimpse.Tabs.Cache {
    public class CacheMessage : MessageBase, IDurationMessage {
        public string Action { get; set; }
        public string Key { get; set; }
        public object Value { get; set; }
        public string Result { get; set; }
        public TimeSpan? ValidFor { get; set; }
        public TimeSpan Duration { get; set; }
    }
}
