using Orchard.ContentManagement;
using Orchard.Security;
using Orchard.UI.Admin;
using Orchard.DisplayManagement;
using Orchard.Localization;
using Orchard.Services;
using System.Web.Mvc;
using Orchard.Mvc.Filters;
using Microsoft.AspNetCore.Mvc.ViewFeatures;

namespace System.Web.Mvc
{
    public class TempDataDictionary : System.Collections.Generic.Dictionary<string, object>
    {
        private readonly Microsoft.AspNetCore.Mvc.ViewFeatures.ITempDataDictionary _coreTempData;
        public TempDataDictionary(Microsoft.AspNetCore.Mvc.ViewFeatures.ITempDataDictionary coreTempData)
        {
            _coreTempData = coreTempData ?? throw new ArgumentNullException(nameof(coreTempData));
        }
        public new object? this[string key]
            get => _coreTempData.ContainsKey(key) ? _coreTempData[key] : null;
            set => _coreTempData[key] = value ?? throw new ArgumentNullException(nameof(value));
        public new void Clear()
            _coreTempData.Clear();
        public new bool ContainsKey(string key)
            return _coreTempData.ContainsKey(key);
    }
}
