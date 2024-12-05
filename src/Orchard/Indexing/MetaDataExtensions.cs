using Orchard.ContentManagement;
using Orchard.Security;
using Orchard.UI.Admin;
using Orchard.DisplayManagement;
using Orchard.Localization;
using Orchard.Services;
using System.Web.Mvc;
using Orchard.Mvc.Filters;
﻿using Orchard.ContentManagement.MetaData.Builders;

namespace Orchard.Indexing {
    public static class MetaDataExtensions {
        public static ContentTypeDefinitionBuilder Indexed(this ContentTypeDefinitionBuilder builder, params string[] indexes) {
            return builder.WithSetting("TypeIndexing.Indexes", string.Join(",", indexes ?? new string[0]));
        }
    }
}
