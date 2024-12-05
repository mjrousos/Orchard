using Orchard.ContentManagement;
using Orchard.Security;
using Orchard.UI.Admin;
using Orchard.DisplayManagement;
using Orchard.Localization;
using Orchard.Services;
using System.Web.Mvc;
using Orchard.Mvc.Filters;
﻿using Orchard.ContentManagement.MetaData.Models;

namespace Orchard.ContentTypes.ViewModels {
    public class EditFieldViewModel {
        public EditFieldViewModel() { }
        public EditFieldViewModel(ContentFieldDefinition contentFieldDefinition) {
            Name = contentFieldDefinition.Name;
            _Definition = contentFieldDefinition;
        }
        public string Name { get; set; }
        public ContentFieldDefinition _Definition { get; private set; }
    }
}
