using Orchard.ContentManagement;
using Orchard.Security;
using Orchard.UI.Admin;
using Orchard.DisplayManagement;
using Orchard.Localization;
using Orchard.Services;
using System.Web.Mvc;
using Orchard.Mvc.Filters;
using Orchard.ContentManagement.Records;

namespace Orchard.Tests.ContentManagement.Records {
    public class GammaRecord : ContentPartRecord {
        public virtual string Frap { get; set; }
    }
}
