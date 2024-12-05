using Orchard.ContentManagement;
using Orchard.Security;
using Orchard.UI.Admin;
using Orchard.DisplayManagement;
using Orchard.Localization;
using Orchard.Services;
using System.Web.Mvc;
using Orchard.Mvc.Filters;
﻿using Orchard.ContentManagement.FieldStorage;
using Orchard.ContentManagement.MetaData.Models;

namespace Orchard.ContentManagement {
    public class ContentField {
        public string Name { get { return PartFieldDefinition.Name; } }
        public string DisplayName { get { return PartFieldDefinition.DisplayName; } }
        public ContentPartFieldDefinition PartFieldDefinition { get; set; }
        public ContentFieldDefinition FieldDefinition { get { return PartFieldDefinition.FieldDefinition; } }
        public IFieldStorage Storage { get; set; }
    }
}
