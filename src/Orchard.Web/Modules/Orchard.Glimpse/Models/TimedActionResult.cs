using Orchard.ContentManagement;
using Orchard.Security;
using Orchard.UI.Admin;
using Orchard.DisplayManagement;
using Orchard.Localization;
using Orchard.Services;
using System.Web.Mvc;
using Orchard.Mvc.Filters;
using Glimpse.Core.Extensibility;

namespace Orchard.Glimpse.Models {
    public class TimedActionResult<T> {
        public TimedActionResult() {
            TimerResult = new TimerResult(); // Glimpse fails if it is ever passed a null TimerResult
        }
        public TimerResult TimerResult { get; set; }
        public T ActionResult { get; set; }
    }
}
