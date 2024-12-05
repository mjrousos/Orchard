using Orchard.ContentManagement;
using Orchard.Security;
using Orchard.UI.Admin;
using Orchard.DisplayManagement;
using Orchard.Localization;
using Orchard.Services;
using System.Web.Mvc;
using Orchard.Mvc.Filters;
﻿using Orchard.ContentManagement;
using Orchard.ContentManagement.FieldStorage.InfosetStorage;

namespace Orchard.Layouts.Helpers {
    public static class PlaceableContentExtensions {
        public static bool IsPlaceableContent(this IContent content) {
            return content.As<InfosetPart>().Retrieve<bool>("PlacedAsElement");
        }
        public static void IsPlaceableContent(this IContent content, bool value) {
            content.As<InfosetPart>().Store("PlacedAsElement", value);
    }
}
