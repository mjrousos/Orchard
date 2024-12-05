using Orchard.ContentManagement;
using Orchard.Security;
using Orchard.UI.Admin;
using Orchard.DisplayManagement;
using Orchard.Localization;
using Orchard.Services;
using System.Web.Mvc;
using Orchard.Mvc.Filters;
using Orchard.Forms.Services;
using Orchard.Localization.Services;

namespace Orchard.DynamicForms.Services {
    public class FormElementServices : IFormElementServices {
        public FormElementServices(IFormManager formManager, ICultureManager cultureManager) {
            FormManager = formManager;
            CultureManager = cultureManager;
        }
        public IFormManager FormManager { get; private set; }
        public ICultureManager CultureManager { get; private set; }
    }
}
