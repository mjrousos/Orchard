using Orchard.ContentManagement;
using Orchard.Security;
using Orchard.UI.Admin;
using Orchard.DisplayManagement;
using Orchard.Localization;
using Orchard.Services;
using System.Web.Mvc;
using Orchard.Mvc.Filters;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using System.Collections.Generic;

namespace System.Web.Mvc
{
    public interface IViewDataContainer
    {
        ViewDataDictionary ViewData { get; set; }
    }

    public class ViewDataDictionary : Dictionary<string, object>
    {
        private readonly Microsoft.AspNetCore.Mvc.ViewFeatures.ViewDataDictionary _coreViewData;

        public ViewDataDictionary(Microsoft.AspNetCore.Mvc.ViewFeatures.ViewDataDictionary source)
        {
            _coreViewData = source;
            foreach (var item in source)
            {
                base[item.Key] = item.Value;
            }
        }

        public ViewDataDictionary()
        {
            _coreViewData = new Microsoft.AspNetCore.Mvc.ViewFeatures.ViewDataDictionary(
                new EmptyModelMetadataProvider(),
                new ModelStateDictionary());
        }

        public object Model
        {
            get => _coreViewData.Model;
            set => _coreViewData.Model = value;
        }

        public new object this[string key]
        {
            get => _coreViewData[key];
            set
            {
                _coreViewData[key] = value;
                base[key] = value;
            }
        }

        public new void Add(string key, object value)
        {
            _coreViewData[key] = value;
            base.Add(key, value);
        }

        public new bool ContainsKey(string key)
        {
            return _coreViewData.ContainsKey(key);
        }

        public new bool Remove(string key)
        {
            _coreViewData.Remove(key);
            return base.Remove(key);
        }
    }
}
