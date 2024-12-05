using Orchard.ContentManagement;
using Orchard.Security;
using Orchard.UI.Admin;
using Orchard.DisplayManagement;
using Orchard.Localization;
using Orchard.Services;
using System.Web.Mvc;
using Orchard.Mvc.Filters;
﻿using System.ServiceModel;
using System.ServiceModel.Channels;
using System.ServiceModel.Dispatcher;
using Autofac;
using Autofac.Core;

namespace Orchard.Wcf {
    public class OrchardInstanceProvider : IInstanceProvider {
        private readonly IWorkContextAccessor _workContextAccessor;
        private readonly IComponentRegistration _componentRegistration;
        public OrchardInstanceProvider(IWorkContextAccessor workContextAccessor, IComponentRegistration componentRegistration) {
            _workContextAccessor = workContextAccessor;
            _componentRegistration = componentRegistration;
        }
        public object GetInstance(InstanceContext instanceContext, Message message) {
            OrchardInstanceContext item = new OrchardInstanceContext(_workContextAccessor);
            instanceContext.Extensions.Add(item);
            return item.Resolve(_componentRegistration);
        public object GetInstance(InstanceContext instanceContext) {
            return GetInstance(instanceContext, null);
        public void ReleaseInstance(InstanceContext instanceContext, object instance) {
            OrchardInstanceContext context = instanceContext.Extensions.Find<OrchardInstanceContext>();
            if (context != null) {
                context.Dispose();
            }
    }
}
