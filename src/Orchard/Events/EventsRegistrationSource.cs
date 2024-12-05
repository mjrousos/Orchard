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
using Autofac;
using Autofac.Builder;
using Autofac.Core;
using Castle.DynamicProxy;

namespace Orchard.Events {
    public class EventsRegistrationSource : IRegistrationSource {
        private readonly DefaultProxyBuilder _proxyBuilder;
        public EventsRegistrationSource() {
            _proxyBuilder = new DefaultProxyBuilder();
        }
        public bool IsAdapterForIndividualComponents {
            get { return false; }
        public IEnumerable<IComponentRegistration> RegistrationsFor(Service service, Func<Service, IEnumerable<IComponentRegistration>> registrationAccessor) {
            var serviceWithType = service as IServiceWithType;
            if (serviceWithType == null)
                yield break;
            var serviceType = serviceWithType.ServiceType;
            if (!serviceType.IsInterface || !typeof(IEventHandler).IsAssignableFrom(serviceType) || serviceType == typeof(IEventHandler))
            var interfaceProxyType = _proxyBuilder.CreateInterfaceProxyTypeWithoutTarget(
                serviceType,
                new Type[0],
                ProxyGenerationOptions.Default);
            var rb = RegistrationBuilder
                .ForDelegate((ctx, parameters) => {
                    var interceptors = new IInterceptor[] { new EventsInterceptor(ctx.Resolve<IEventBus>()) };
                    var args = new object[] { interceptors, null };
                    return Activator.CreateInstance(interfaceProxyType, args);
                })
                .As(service);
            yield return rb.CreateRegistration();
    }
}
