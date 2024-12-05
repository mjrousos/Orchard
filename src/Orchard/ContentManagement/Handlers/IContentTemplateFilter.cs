using Orchard.ContentManagement;
using Orchard.Security;
using Orchard.UI.Admin;
using Orchard.DisplayManagement;
using Orchard.Localization;
using Orchard.Services;
using System.Web.Mvc;
using Orchard.Mvc.Filters;
﻿namespace Orchard.ContentManagement.Handlers {
    interface IContentTemplateFilter : IContentFilter {
        void GetContentItemMetadata(GetContentItemMetadataContext context);
        void BuildDisplayShape(BuildDisplayContext context);
        void BuildEditorShape(BuildEditorContext context);
        void UpdateEditorShape(UpdateEditorContext context);
    }
}
