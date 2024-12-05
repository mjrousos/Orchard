using Orchard.ContentManagement;
using Orchard.Security;
using Orchard.UI.Admin;
using Orchard.DisplayManagement;
using Orchard.Localization;
using Orchard.Services;
using System.Web.Mvc;
using Orchard.Mvc.Filters;
﻿using Orchard.Commands;
using Orchard.Search.Models;

namespace Orchard.Search.Commands {
    public class SearchCommands : DefaultOrchardCommandHandler {
        private readonly IOrchardServices _orchardServices;
        public SearchCommands(IOrchardServices orchardServices) {
            _orchardServices = orchardServices;
        }
        [CommandName("search use")]
        [CommandHelp("search use <index>\r\n\t" + "Defines the default index to use for search")]
        public void Index(string index) {
            var settings = _orchardServices.WorkContext.CurrentSite.As<SearchSettingsPart>();
            if (string.IsNullOrWhiteSpace(index)) {
                Context.Output.WriteLine(T("Invalid index name."));
                return;
            }
            if (settings != null) {
                settings.SearchIndex = index;
    }
}
