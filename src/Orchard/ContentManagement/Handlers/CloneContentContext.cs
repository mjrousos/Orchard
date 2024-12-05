using Orchard.ContentManagement;
using Orchard.Security;
using Orchard.UI.Admin;
using Orchard.DisplayManagement;
using Orchard.Localization;
using Orchard.Services;
using System.Web.Mvc;
using Orchard.Mvc.Filters;
﻿namespace Orchard.ContentManagement.Handlers {
    public class CloneContentContext : ContentContextBase {
        public ContentItem CloneContentItem { get; set; }
        public string FieldName { get; set; } //in case we are cloning fields, this is the name of the field. The actual name, not the name of the type.
        public CloneContentContext(ContentItem contentItem, ContentItem cloneContentItem)
            :base(contentItem) {
            CloneContentItem = cloneContentItem;
        }
    }
}
