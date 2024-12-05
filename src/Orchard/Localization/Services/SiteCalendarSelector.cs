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

namespace Orchard.Localization.Services {
    public class SiteCalendarSelector : ICalendarSelector {
        private readonly IWorkContextAccessor _workContextAccessor;
		public SiteCalendarSelector(IWorkContextAccessor workContextAccessor) {
            _workContextAccessor = workContextAccessor;
        }
        public CalendarSelectorResult GetCalendar(HttpContextBase context) {
            string currentCalendarName = _workContextAccessor.GetContext().CurrentSite.SiteCalendar;
			if (String.IsNullOrEmpty(currentCalendarName)) {
                return null;
            }
			return new CalendarSelectorResult {
				Priority = -5,
				CalendarName = currentCalendarName
			};
    }
}
