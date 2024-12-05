using Orchard.ContentManagement;
using Orchard.Security;
using Orchard.UI.Admin;
using Orchard.DisplayManagement;
using Orchard.Localization;
using Orchard.Services;
using System.Web.Mvc;
using Orchard.Mvc.Filters;
﻿using Orchard.Events;
using Orchard.Taxonomies.Models;

namespace Orchard.Taxonomies.Events {
    public interface ITermLocalizationEventHandler : IEventHandler {
        void MovingTerms(MoveTermsContext context);
    }
}
