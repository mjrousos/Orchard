using Orchard.ContentManagement;
using Orchard.Security;
using Orchard.UI.Admin;
using Orchard.DisplayManagement;
using Orchard.Localization;
using Orchard.Services;
using System.Web.Mvc;
using Orchard.Mvc.Filters;
﻿using System;

namespace Orchard.Localization.Services {
    public class CurrentCalendarWorkContext : IWorkContextStateProvider {
        private readonly ICalendarManager _calendarManager;
		public CurrentCalendarWorkContext(ICalendarManager calendarManager) {
			_calendarManager = calendarManager;
        }
        public Func<WorkContext, T> Get<T>(string name) {
            if (name == "CurrentCalendar") {
				return ctx => (T)(object)_calendarManager.GetCurrentCalendar(ctx.HttpContext);
            }
            return null;
    }
}
