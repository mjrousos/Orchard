using Orchard.ContentManagement;
using Orchard.Security;
using Orchard.UI.Admin;
using Orchard.DisplayManagement;
using Orchard.Localization;
using Orchard.Services;
using System.Web.Mvc;
using Orchard.Mvc.Filters;
using Orchard.Forms.Services;

namespace Orchard.Layouts.Services {
    public class FormsBasedElementServices : IFormsBasedElementServices {
        public FormsBasedElementServices(IFormManager formManager, ICultureAccessor cultureAccessor) {
            FormManager = formManager;
            CultureAccessor = cultureAccessor;
        }
        public IFormManager FormManager { get; private set; }
        public ICultureAccessor CultureAccessor { get; private set; }
    }
}
