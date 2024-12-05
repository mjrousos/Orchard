using Orchard.ContentManagement;
using Orchard.Security;
using Orchard.UI.Admin;
using Orchard.DisplayManagement;
using Orchard.Localization;
using Orchard.Services;
using System.Web.Mvc;
using Orchard.Mvc.Filters;
﻿using Orchard.Localization;
using Orchard.Logging;

namespace Orchard {
    /// <summary>
    /// Base interface for services that are instantiated per unit of work (i.e. web request).
    /// </summary>
    public interface IDependency {
    }
    /// Base interface for services that are instantiated per shell/tenant.
    public interface ISingletonDependency : IDependency {
    /// Base interface for services that may *only* be instantiated in a unit of work.
    /// This interface is used to guarantee they are not accidentally referenced by a singleton dependency.
    public interface IUnitOfWorkDependency : IDependency {
    /// Base interface for services that are instantiated per usage.
    public interface ITransientDependency : IDependency {
    /// Indicates that a service should be registered as a decorator.
    /// <typeparam name="T">The type that this service decorates. Must be <see cref="IDependency"/>, and this service must also implement this type.</typeparam>
    public interface IDecorator<T> where T : IDependency {
    public abstract class Component : IDependency {
        protected Component() {
            Logger = NullLogger.Instance;
            T = NullLocalizer.Instance;
        }
        public ILogger Logger { get; set; }
        public Localizer T { get; set; }
}
