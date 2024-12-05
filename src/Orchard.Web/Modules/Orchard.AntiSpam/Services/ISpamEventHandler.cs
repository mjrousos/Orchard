using Orchard.ContentManagement;
using Orchard.Security;
using Orchard.UI.Admin;
using Orchard.DisplayManagement;
using Orchard.Localization;
using Orchard.Services;
using System.Web.Mvc;
using Orchard.Mvc.Filters;
﻿using Orchard.ContentManagement;
using Orchard.Events;

namespace Orchard.AntiSpam.Services {
    public interface ISpamEventHandler : IEventHandler {
        void SpamReported(IContent content);
        void HamReported(IContent content);
    }
}
