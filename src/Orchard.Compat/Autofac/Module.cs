using Orchard.ContentManagement;
using Orchard.Security;
using Orchard.UI.Admin;
using Orchard.DisplayManagement;
using Orchard.Localization;
using Orchard.Services;
using System.Web.Mvc;
using Orchard.Mvc.Filters;
using Autofac;
using Autofac.Core;
using System;

namespace Autofac.Core
{
    public abstract class Module : IModule
    {
        protected virtual void AttachToComponentRegistration(IComponentRegistry componentRegistry, IComponentRegistration registration)
        {
            // Default implementation does nothing
        }

        protected virtual void Load(ContainerBuilder builder)
        {
            // Default implementation does nothing
        }

        void IModule.Configure(IComponentRegistry componentRegistry)
        {
            if (componentRegistry == null)
            {
                throw new ArgumentNullException(nameof(componentRegistry));
            }

            var builder = new ContainerBuilder();
            Load(builder);
            builder.Update(componentRegistry);

            foreach (var registration in componentRegistry.Registrations)
            {
                AttachToComponentRegistration(componentRegistry, registration);
            }
        }
    }
}
