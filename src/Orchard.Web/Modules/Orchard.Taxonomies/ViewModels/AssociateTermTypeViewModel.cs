using Orchard.ContentManagement;
using Orchard.Security;
using Orchard.UI.Admin;
using Orchard.DisplayManagement;
using Orchard.Localization;
using Orchard.Services;
using System.Web.Mvc;
using Orchard.Mvc.Filters;
﻿using System.Collections.Generic;
using Orchard.ContentManagement.MetaData.Models;
using Orchard.Environment.Extensions;

namespace Orchard.Taxonomies.ViewModels {
    [OrchardFeature("Orchard.Taxonomies.LocalizationExtensions")]
    public class AssociateTermTypeViewModel {
        public IEnumerable<ContentTypeDefinition> TermTypes { get; set; }
        public TermCreationOptions TermCreationAction { get; set; }
        public string SelectedTermTypeId { get; set; }
        public IContent ContentItem { get; set; }
    }
    public enum TermCreationOptions {
        CreateLocalized,
        CreateCultureNeutral,
        UseExisting
}
