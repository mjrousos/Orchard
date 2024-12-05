using Orchard.ContentManagement;
using Orchard.Security;
using Orchard.UI.Admin;
using Orchard.DisplayManagement;
using Orchard.Localization;
using Orchard.Services;
using System.Web.Mvc;
using Orchard.Mvc.Filters;
using Orchard.ContentManagement.Handlers;
using Orchard.Warmup.Models;

namespace Orchard.Warmup.Handlers {
    public class WarmupSettingsPartHandler : ContentHandler {
        public WarmupSettingsPartHandler() {
            Filters.Add(new ActivatingFilter<WarmupSettingsPart>("Site"));
            
            OnInitializing<WarmupSettingsPart>((context, part) => {
                part.Delay = 90;
            });
        }
    }
}
