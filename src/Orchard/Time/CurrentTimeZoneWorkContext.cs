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
using System.Linq;
using System.Web;

namespace Orchard.Time {
    public class CurrentTimeZoneWorkContext : IWorkContextStateProvider {
        private readonly IEnumerable<ITimeZoneSelector> _timeZoneSelectors;
        public CurrentTimeZoneWorkContext(IEnumerable<ITimeZoneSelector> timeZoneSelectors) {
            _timeZoneSelectors = timeZoneSelectors;
        }
        public Func<WorkContext, T> Get<T>(string name) {
            if (name == "CurrentTimeZone") {
                return ctx => (T)(object)CurrentTimeZone(ctx.HttpContext);
            }
            return null;
        TimeZoneInfo CurrentTimeZone(HttpContextBase httpContext) {
            var timeZone = _timeZoneSelectors
                .Select(x => x.GetTimeZone(httpContext))
                .Where(x => x != null)
                .OrderByDescending(x => x.Priority)
                .FirstOrDefault();
            if (timeZone == null) {
                return null;
            return timeZone.TimeZone;
    }
}
