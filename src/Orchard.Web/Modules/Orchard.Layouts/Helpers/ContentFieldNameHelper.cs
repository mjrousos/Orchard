using Orchard.ContentManagement;
using Orchard.Security;
using Orchard.UI.Admin;
using Orchard.DisplayManagement;
using Orchard.Localization;
using Orchard.Services;
using System.Web.Mvc;
using Orchard.Mvc.Filters;
﻿using System.Linq;

namespace Orchard.Layouts.Helpers {
    public static class ContentFieldHelper {
        public static void GetPartAndFieldName(this string elementTypeName, out string partName, out string fieldName) {
            var typeNameParts = elementTypeName.Split(new[] { '.' });
            partName = typeNameParts[0];
            fieldName = typeNameParts[1];
        }
        public static ContentField GetContentField(this ContentItem contentItem, string elementTypeName) {
            string partName, fieldName;
            GetPartAndFieldName(elementTypeName, out partName, out fieldName);
            return contentItem.Parts.Single(x => x.PartDefinition.Name == partName).Fields.Single(x => x.Name == fieldName);
    }
}
