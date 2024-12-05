using Orchard.ContentManagement;
using Orchard.Security;
using Orchard.UI.Admin;
using Orchard.DisplayManagement;
using Orchard.Localization;
using Orchard.Services;
using System.Web.Mvc;
using Orchard.Mvc.Filters;
﻿using System.Collections.Generic;
using Orchard.ContentManagement.Handlers;
using Orchard.ContentManagement.MetaData;

namespace Orchard.ContentManagement.Drivers {
    public interface IContentFieldDriver : IDependency {
        DriverResult BuildDisplayShape(BuildDisplayContext context);
        DriverResult BuildEditorShape(BuildEditorContext context);
        DriverResult UpdateEditorShape(UpdateEditorContext context);
        void Importing(ImportContentContext context);
        void Imported(ImportContentContext context);
        void ImportCompleted(ImportContentContext context);
        void Exporting(ExportContentContext context);
        void Exported(ExportContentContext context);
        void Cloning(CloneContentContext context);
        void Cloned(CloneContentContext context);
        void Describe(DescribeMembersContext context);
        IEnumerable<ContentFieldInfo> GetFieldInfo();
        void GetContentItemMetadata(GetContentItemMetadataContext context);
    }
}
