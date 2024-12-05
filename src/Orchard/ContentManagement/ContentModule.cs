using Orchard.ContentManagement;
using Orchard.Security;
using Orchard.UI.Admin;
using Orchard.DisplayManagement;
using Orchard.Localization;
using Orchard.Services;
using System.Web.Mvc;
using Orchard.Mvc.Filters;
﻿using Autofac;

namespace Orchard.ContentManagement {
    public class ContentModule : Module {
        protected override void Load(ContainerBuilder builder) {
            builder.RegisterType<DefaultContentQuery>().As<IContentQuery>().InstancePerDependency();
        }
    }
}
