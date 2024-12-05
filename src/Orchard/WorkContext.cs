using Orchard.ContentManagement;
using Orchard.Security;
using Orchard.UI.Admin;
using Orchard.DisplayManagement;
using Orchard.Localization;
using Orchard.Services;
using System.Web.Mvc;
using Orchard.Mvc.Filters;
﻿using System;
using System.Web;
using Orchard.Environment.Extensions.Models;
using Orchard.Settings;

namespace Orchard {
    /// <summary>
    /// A work context for work context scope
    /// </summary>
    public abstract class WorkContext {
        /// <summary>
        /// Resolves a registered dependency type.
        /// </summary>
        /// <typeparam name="T">The type of the dependency.</typeparam>
        /// <returns>An instance of the dependency if it could be resolved.</returns>
        public abstract T Resolve<T>();
        /// <param name="serviceType">The type of the dependency.</param>
        public abstract object Resolve(Type serviceType);
        /// Tries to resolve a registered dependency type.
        /// <param name="service">An instance of the dependency if it could be resolved.</param>
        /// <returns>True if the dependency could be resolved, false otherwise.</returns>
        public abstract bool TryResolve<T>(out T service);
        public abstract bool TryResolve(Type serviceType, out object service);
        public abstract T GetState<T>(string name);
        public abstract void SetState<T>(string name, T value);
        /// The http context corresponding to the work context
        public HttpContextBase HttpContext {
            get { return GetState<HttpContextBase>("HttpContext"); }
            set { SetState("HttpContext", value); }
        }
        /// The Layout shape corresponding to the work context
        public dynamic Layout {
            get { return GetState<dynamic>("Layout"); }
            set { SetState("Layout", value); }
        /// Settings of the site corresponding to the work context
        public ISite CurrentSite {
            get { return GetState<ISite>("CurrentSite"); }
            set { SetState("CurrentSite", value); }
        /// The user, if there is any corresponding to the work context
        public IUser CurrentUser {
            get { return GetState<IUser>("CurrentUser"); }
            set { SetState("CurrentUser", value); }
        /// The theme used in the work context
        public ExtensionDescriptor CurrentTheme {
            get { return GetState<ExtensionDescriptor>("CurrentTheme"); }
            set { SetState("CurrentTheme", value); }
        /// Active culture of the work context
        public string CurrentCulture {
            get { return GetState<string>("CurrentCulture"); }
            set { SetState("CurrentCulture", value); }
        /// Active calendar of the work context
        public string CurrentCalendar {
            get { return GetState<string>("CurrentCalendar"); }
            set { SetState("CurrentCalendar", value); }
        /// Time zone of the work context
        public TimeZoneInfo CurrentTimeZone {
            get { return GetState<TimeZoneInfo>("CurrentTimeZone"); }
            set { SetState("CurrentTimeZone", value); }
    }
}
