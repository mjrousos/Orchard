using Orchard.ContentManagement;
using Orchard.Security;
using Orchard.UI.Admin;
using Orchard.DisplayManagement;
using Orchard.Localization;
using Orchard.Services;
using System.Web.Mvc;
using Orchard.Mvc.Filters;
using Orchard.Events;

namespace Orchard.Lists.Services {
    public interface IFilterProvider : IEventHandler {
        void Describe(dynamic describe);
    }
}
