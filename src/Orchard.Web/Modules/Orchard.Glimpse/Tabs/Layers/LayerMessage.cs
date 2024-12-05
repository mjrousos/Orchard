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

namespace Orchard.Glimpse.Tabs.Layers {
    public class LayerMessage : MessageBase, IDurationMessage {
        public string Name { get; set; }
        public string Rule { get; set; }
        public bool Active { get; set; }
        public string EditUrl { get; set; }
        public TimeSpan Duration { get; set; }
    }
}
