using Orchard.ContentManagement;
using Orchard.Security;
using Orchard.UI.Admin;
using Orchard.DisplayManagement;
using Orchard.Localization;
using Orchard.Services;
using System.Web.Mvc;
using Orchard.Mvc.Filters;
﻿using Orchard.ContentManagement.MetaData.Builders;

namespace Orchard.Layouts.Helpers {
    public static class MetaDataExtensions {
        public static ContentPartDefinitionBuilder Placeable(this ContentPartDefinitionBuilder builder, bool placeable = true) {
            return builder.WithSetting("ContentPartLayoutSettings.Placeable", placeable.ToString());
        }
        public static ContentTypeDefinitionBuilder Placeable(this ContentTypeDefinitionBuilder builder, bool placeable = true) {
            return builder.WithSetting("ContentTypeLayoutSettings.Placeable", placeable.ToString());
    }
}
