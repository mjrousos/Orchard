using Orchard.ContentManagement;
using Orchard.Security;
using Orchard.UI.Admin;
using Orchard.DisplayManagement;
using Orchard.Localization;
using Orchard.Services;
using System.Web.Mvc;
using Orchard.Mvc.Filters;
using Microsoft.AspNetCore.Mvc.ViewEngines;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.AspNetCore.Mvc;

namespace System.Web.Mvc
{
    public interface IView
    {
        void Render(ViewContext viewContext, System.IO.TextWriter writer);
    }

    public interface IViewEngine
    {
        ViewEngineResult FindView(ControllerContext controllerContext, string viewName, string masterName, bool useCache);
        ViewEngineResult FindPartialView(ControllerContext controllerContext, string partialViewName, bool useCache);
    }

    public class ViewEngineResult
    {
        private readonly IView _view;
        private readonly string[] _searchedLocations;

        public ViewEngineResult(IView view, IViewEngine viewEngine)
        {
            _view = view;
            ViewEngine = viewEngine;
            _searchedLocations = Array.Empty<string>();
        }

        public ViewEngineResult(string[] searchedLocations)
        {
            _searchedLocations = searchedLocations ?? Array.Empty<string>();
            _view = null;
            ViewEngine = null;
        }

        public IView View => _view;
        public IViewEngine ViewEngine { get; }
        public string[] SearchedLocations => _searchedLocations;
    }

    public class ViewContext : ControllerContext
    {
        public ViewContext(
            ControllerContext controllerContext,
            IView view,
            ViewDataDictionary viewData,
            TempDataDictionary tempData)
            : base(controllerContext)
        {
            View = view;
            ViewData = viewData;
            TempData = tempData;
        }

        public IView View { get; set; }
        public ViewDataDictionary ViewData { get; set; }
        public TempDataDictionary TempData { get; set; }
    }
}
