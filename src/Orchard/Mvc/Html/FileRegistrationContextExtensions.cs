using Orchard.ContentManagement;
using Orchard.Security;
using Orchard.UI.Admin;
using Orchard.DisplayManagement;
using Orchard.Localization;
using Orchard.Services;
using System.Web.Mvc;
using Orchard.Mvc.Filters;
﻿namespace Orchard.Mvc.Html {
    public static class FileRegistrationContextExtensions {
        public static T WithCondition<T>(this T fileRegistrationContext, string condition)where T : FileRegistrationContext {
            if (fileRegistrationContext == null)
                return null;

            fileRegistrationContext.Condition = condition;
            return fileRegistrationContext;
        }
        public static T ForMedia<T>(this T fileRegistrationContext, string media) where T : FileRegistrationContext {
            fileRegistrationContext.SetAttribute("media", media);
    }
}
