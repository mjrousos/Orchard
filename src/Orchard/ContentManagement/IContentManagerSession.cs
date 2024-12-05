using Orchard.ContentManagement;
using Orchard.Security;
using Orchard.UI.Admin;
using Orchard.DisplayManagement;
using Orchard.Localization;
using Orchard.Services;
using System.Web.Mvc;
using Orchard.Mvc.Filters;
﻿namespace Orchard.ContentManagement {
    public interface IContentManagerSession : IDependency {
        void Store(ContentItem item);
        bool RecallVersionRecordId(int id, out ContentItem item);
        bool RecallVersionNumber(int id, int version, out ContentItem item);
        bool RecallContentRecordId(int id, out ContentItem item);

        void Clear();
    }
}
