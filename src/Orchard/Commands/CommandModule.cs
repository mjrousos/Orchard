using Orchard.ContentManagement;
using Orchard.Security;
using Orchard.UI.Admin;
using Orchard.DisplayManagement;
using Orchard.Localization;
using Orchard.Services;
using System.Web.Mvc;
using Orchard.Mvc.Filters;
﻿using System.Linq;
using Autofac;
using Autofac.Core;

namespace Orchard.Commands {
    public class CommandModule : Module {
        protected override void AttachToComponentRegistration(IComponentRegistry componentRegistry, IComponentRegistration registration) {
            if (!registration.Services.Contains(new TypedService(typeof(ICommandHandler))))
                return;
            var builder = new CommandHandlerDescriptorBuilder();
            var descriptor = builder.Build(registration.Activator.LimitType);
            registration.Metadata.Add(typeof(CommandHandlerDescriptor).FullName, descriptor);
        }
    }
}
