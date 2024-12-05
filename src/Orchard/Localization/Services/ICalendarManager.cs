using Orchard.ContentManagement;
using Orchard.Security;
using Orchard.UI.Admin;
using Orchard.DisplayManagement;
using Orchard.Localization;
using Orchard.Services;
using System.Web.Mvc;
using Orchard.Mvc.Filters;
﻿using System.Collections.Generic;
using System.Globalization;
using System.Web;

namespace Orchard.Localization.Services {
    public interface ICalendarManager : IDependency {
        IEnumerable<string> ListCalendars();
		string GetCurrentCalendar(HttpContextBase requestContext);
		Calendar GetCalendarByName(string calendarName);
	}
}
