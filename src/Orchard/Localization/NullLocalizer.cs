using Orchard.ContentManagement;
using Orchard.Security;
using Orchard.UI.Admin;
using Orchard.DisplayManagement;
using Orchard.Localization;
using Orchard.Services;
using System.Web.Mvc;
using Orchard.Mvc.Filters;
namespace Orchard.Localization {
    public static class NullLocalizer {
        
        static NullLocalizer () {
            _instance = (format, args) => new LocalizedString((args == null || args.Length == 0) ? format : string.Format(format, args));
        }
        static readonly Localizer _instance;

        public static Localizer Instance { get { return _instance; } }
    }
}
