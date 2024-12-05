using Orchard.ContentManagement;
using Orchard.Security;
using Orchard.UI.Admin;
using Orchard.DisplayManagement;
using Orchard.Localization;
using Orchard.Services;
using System.Web.Mvc;
using Orchard.Mvc.Filters;
﻿using System.Reflection;
using Autofac;
using Orchard.Data.Providers;
using Module = Autofac.Module;

namespace Orchard.Data {
    public class DataModule : Module {
        protected override void Load(ContainerBuilder builder) {
            builder.RegisterGeneric(typeof(Repository<>)).As(typeof(IRepository<>)).InstancePerDependency();
        }
        protected override void AttachToComponentRegistration(Autofac.Core.IComponentRegistry componentRegistry, Autofac.Core.IComponentRegistration registration) {
            if (typeof(IDataServicesProvider).IsAssignableFrom(registration.Activator.LimitType)) {
                var propertyInfo = registration.Activator.LimitType.GetProperty("ProviderName", BindingFlags.Static | BindingFlags.Public);
                if (propertyInfo != null) {
                    registration.Metadata["ProviderName"] = propertyInfo.GetValue(null, null);
                }
            }
    }
}
