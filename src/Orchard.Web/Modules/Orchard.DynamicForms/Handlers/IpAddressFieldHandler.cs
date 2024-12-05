using Orchard.ContentManagement;
using Orchard.Security;
using Orchard.UI.Admin;
using Orchard.DisplayManagement;
using Orchard.Localization;
using Orchard.Services;
using System.Web.Mvc;
using Orchard.Mvc.Filters;
using Orchard.DynamicForms.Elements;
using Orchard.DynamicForms.Services;

namespace Orchard.DynamicForms.Handlers {
    public class IpAddressFieldHandler : FormElementEventHandlerBase {
        private readonly IClientHostAddressAccessor _clientHostAddressAccessor;
        public IpAddressFieldHandler(IClientHostAddressAccessor clientHostAddressAccessor) {
            _clientHostAddressAccessor = clientHostAddressAccessor;
        }
        public override void GetElementValue(FormElement element, ReadElementValuesContext context) {
            var ipAddressField = element as IpAddressField;
            if (ipAddressField == null)
                return;
            var key = ipAddressField.Name;
            context.Output[key] = _clientHostAddressAccessor.GetClientAddress();
    }
}
