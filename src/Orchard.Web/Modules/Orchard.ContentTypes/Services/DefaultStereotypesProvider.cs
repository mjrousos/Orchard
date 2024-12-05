using Orchard.ContentManagement;
using Orchard.Security;
using Orchard.UI.Admin;
using Orchard.DisplayManagement;
using Orchard.Localization;
using Orchard.Services;
using System.Web.Mvc;
using Orchard.Mvc.Filters;
﻿using System;
using System.Collections.Generic;
using System.Linq;

namespace Orchard.ContentTypes.Services {
    public class DefaultStereotypesProvider : IStereotypesProvider {
        private readonly Lazy<IContentDefinitionService> _contentDefinitionService;
        public DefaultStereotypesProvider(Lazy<IContentDefinitionService> contentDefinitionService) {
            _contentDefinitionService = contentDefinitionService;
        }
        public IEnumerable<StereotypeDescription> GetStereotypes() {
            // Harvest all available stereotypes by finding out about the stereotype of all content types
            var stereotypes = _contentDefinitionService.Value.GetTypes().Where(x => x.Settings.ContainsKey("Stereotype")).Select(x => x.Settings["Stereotype"]).Distinct();
            return stereotypes.Select(x => new StereotypeDescription {DisplayName = x, Stereotype = x});
    }
}
