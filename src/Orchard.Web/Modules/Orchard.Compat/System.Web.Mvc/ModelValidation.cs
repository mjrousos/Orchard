using Orchard.ContentManagement;
using Orchard.Security;
using Orchard.UI.Admin;
using Orchard.DisplayManagement;
using Orchard.Localization;
using Orchard.Services;
using System.Web.Mvc;
using Orchard.Mvc.Filters;
using System;

namespace System.Web.Mvc
{
    [AttributeUsage(AttributeTargets.Property)]
    public class HiddenInputAttribute : Attribute
    {
        public HiddenInputAttribute()
        {
            DisplayValue = true;
        }
        public bool DisplayValue { get; set; }
    }
}

namespace Orchard.UI.Resources
{
    public enum ResourceDebugMode
    {
        FromConfiguration,
        Enabled,
        Disabled
    }

    public class UrlHelper
    {
        private readonly Microsoft.AspNetCore.Mvc.IUrlHelper _urlHelper;

        public UrlHelper(Microsoft.AspNetCore.Mvc.IUrlHelper urlHelper)
        {
            _urlHelper = urlHelper ?? throw new ArgumentNullException(nameof(urlHelper));
        }

        public string Action(string actionName, string controllerName, object routeValues = null)
        {
            return _urlHelper.Action(actionName, controllerName, routeValues);
        }

        public string RouteUrl(object routeValues)
        {
            return _urlHelper.RouteUrl(routeValues);
        }
    }
}
