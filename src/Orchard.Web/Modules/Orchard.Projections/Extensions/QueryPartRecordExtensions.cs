using Orchard.ContentManagement;
using Orchard.Security;
using Orchard.UI.Admin;
using Orchard.DisplayManagement;
using Orchard.Localization;
using Orchard.Services;
using System.Web.Mvc;
using Orchard.Mvc.Filters;
﻿namespace Orchard.Projections.Models {
    public static class QueryPartRecordExtensions {
        public static string GetVersionedFieldIndexColumnName(this QueryPartRecord queryPartRecord) {
            return queryPartRecord == null ?
                QueryVersionScopeOptions.Published.ToVersionedFieldIndexColumnName() :
                queryPartRecord.VersionScope.ToVersionedFieldIndexColumnName();
        }
    }
}
