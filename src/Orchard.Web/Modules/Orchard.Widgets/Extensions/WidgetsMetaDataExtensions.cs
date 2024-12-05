using Orchard.ContentManagement;
using Orchard.Security;
using Orchard.UI.Admin;
using Orchard.DisplayManagement;
using Orchard.Localization;
using Orchard.Services;
using System.Web.Mvc;
using Orchard.Mvc.Filters;
﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Orchard.ContentManagement.MetaData.Builders;

namespace Orchard.ContentManagement.MetaData {
    public static class WidgetsMetaDataExtensions {
        /// <summary>
        /// This extension method can be used for easy widget creation. Adds all necessary parts and settings to the part.
        /// </summary>
        /// <returns>The ContentTypeDefinitionBuilder object on which this method is called.</returns>
        public static ContentTypeDefinitionBuilder AsWidget(this ContentTypeDefinitionBuilder builder) {
            return builder
                .WithPart("CommonPart")
                .WithPart("WidgetPart")
                .WithSetting("Stereotype", "Widget");
        }
        /// This extension method can be used for easy widget creation. Adds all necessary parts and settings to the part. And adds IdentityPart too.
        public static ContentTypeDefinitionBuilder AsWidgetWithIdentity(this ContentTypeDefinitionBuilder builder) {
                .WithSetting("Stereotype", "Widget")
                .WithIdentity();
    }
}
