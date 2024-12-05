using Orchard.ContentManagement;
using Orchard.Security;
using Orchard.UI.Admin;
using Orchard.DisplayManagement;
using Orchard.Localization;
using Orchard.Services;
using System.Web.Mvc;
using Orchard.Mvc.Filters;
using System;
using System.Globalization;

namespace Orchard.Layouts.Services {
    public class CultureAccessor : ICultureAccessor {
        private readonly IWorkContextAccessor _wca;
        private readonly Lazy<CultureInfo> _currentCulture;
        public CultureAccessor(IWorkContextAccessor wca) {
            _wca = wca;
            _currentCulture = new Lazy<CultureInfo>(() => new CultureInfo(_wca.GetContext().CurrentCulture));
        }
        public CultureInfo CurrentCulture {
            get { return _currentCulture.Value; }
    }
}
