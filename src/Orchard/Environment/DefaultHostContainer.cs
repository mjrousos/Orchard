using Orchard.ContentManagement;
using Orchard.Security;
using Orchard.UI.Admin;
using Orchard.DisplayManagement;
using Orchard.Localization;
using Orchard.Services;
using System.Web.Mvc;
using Orchard.Mvc.Filters;
﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Autofac;

namespace Orchard.Environment {
    public class DefaultOrchardHostContainer : IOrchardHostContainer, IDependencyResolver {
        private readonly IContainer _container;
        public DefaultOrchardHostContainer(IContainer container) {
            _container = container;
        }
        static bool TryResolveAtScope(ILifetimeScope scope, string key, Type serviceType, out object value) {
            if (scope == null) {
                value = null;
                return false;
            }
            return key == null ? scope.TryResolve(serviceType, out value) : scope.TryResolveKeyed(key, serviceType, out value);
        bool TryResolve(string key, Type serviceType, out object value) {
            return TryResolveAtScope(_container, key, serviceType, out value) ;
        static object CreateInstance(Type t) {
            if (t.IsAbstract || t.IsInterface)
                return null;
            return Activator.CreateInstance(t);
        TService Resolve<TService>(Type serviceType, TService defaultValue = default(TService)) {
            object value;
            return TryResolve(null, serviceType, out value) ? (TService)value : defaultValue;
        TService Resolve<TService>(Type serviceType, string key, TService defaultValue = default(TService)) {
            return TryResolve(key, serviceType, out value) ? (TService)value : defaultValue;
        TService Resolve<TService>(Type serviceType, Func<Type, TService> defaultFactory) {
            return TryResolve(null, serviceType, out value) ? (TService)value : defaultFactory(serviceType);
        TService Resolve<TService>(Type serviceType, string key, Func<Type, TService> defaultFactory) {
            return TryResolve(key, serviceType, out value) ? (TService)value : defaultFactory(serviceType);
        TService IOrchardHostContainer.Resolve<TService>() {
            // Resolve service, or null
            return Resolve(typeof(TService), default(TService));
        object IDependencyResolver.GetService(Type serviceType) {
            return Resolve(serviceType, default(object));
        IEnumerable<object> IDependencyResolver.GetServices(Type serviceType) {
            return Resolve<IEnumerable>(typeof(IEnumerable<>).MakeGenericType(serviceType), Enumerable.Empty<object>()).Cast<object>();
    }
}
