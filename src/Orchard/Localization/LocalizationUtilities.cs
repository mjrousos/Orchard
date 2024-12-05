using Orchard.ContentManagement;
using Orchard.Security;
using Orchard.UI.Admin;
using Orchard.DisplayManagement;
using Orchard.Localization;
using Orchard.Services;
using System.Web.Mvc;
using Orchard.Mvc.Filters;
﻿using System.Collections.Generic;
using Autofac;

namespace Orchard.Localization {
    public class LocalizationUtilities {
        public static Localizer Resolve(WorkContext workContext, string scope) {
            return workContext == null ? NullLocalizer.Instance : Resolve(workContext.Resolve<ILifetimeScope>(), new List<string> { scope });
        }
        public static Localizer Resolve(ControllerContext controllerContext, string scope) {
            var workContext = controllerContext.GetWorkContext();
            return Resolve(workContext,  scope );
        public static Localizer Resolve(IComponentContext context, string scope) {
            var text = context.Resolve<IText>(new NamedParameter("scope", new List<string> { scope }));
            return text.Get;
        public static Localizer Resolve(IComponentContext context, IEnumerable<string> scopes) {
            var text = context.Resolve<IText>(new NamedParameter("scopes", scopes));
    }
}
