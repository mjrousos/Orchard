using Orchard.ContentManagement;
using Orchard.Security;
using Orchard.UI.Admin;
using Orchard.DisplayManagement;
using Orchard.Localization;
using Orchard.Services;
using System.Web.Mvc;
using Orchard.Mvc.Filters;
using System;
using System.Collections.Generic;

namespace Orchard.UI.Navigation
{
    public interface INavigationFilter
    {
        IEnumerable<MenuItem> Filter(IEnumerable<MenuItem> items, NavigationContext context);
    }
    public interface INavigationProvider
        string MenuName { get; }
        void GetNavigation(NavigationBuilder builder);
    public interface IMenuProvider
        IEnumerable<MenuItem> GetMenuItems();
    public class NavigationBuilder
        private readonly List<MenuItem> _items;
        public NavigationBuilder()
        {
            _items = new List<MenuItem>();
        }
        public NavigationBuilder Add(LocalizedString text, string position, Action<NavigationItemBuilder> itemBuilder = null, IEnumerable<string> classes = null)
            var item = new MenuItem
            {
                Text = text,
                Position = position,
                Classes = classes?.ToList() ?? new List<string>()
            };
            var builder = new NavigationItemBuilder().MenuItem(item);
            itemBuilder?.Invoke(builder);
            _items.Add(item);
            return this;
        public IEnumerable<MenuItem> Build()
            return _items;
    public class NavigationItemBuilder
        private MenuItem _item;
        public NavigationItemBuilder MenuItem(MenuItem item)
            _item = item;
        public NavigationItemBuilder Action(string actionName, string controllerName, object routeValues = null)
            _item.RouteValues = new RouteValueDictionary(routeValues ?? new object());
            _item.RouteValues["action"] = actionName;
            _item.RouteValues["controller"] = controllerName;
        public NavigationItemBuilder Permission(Permission permission)
            _item.Permissions = new[] { permission };
        public NavigationItemBuilder LinkToFirstChild(bool value)
            _item.LinkToFirstChild = value;
        public NavigationItemBuilder LocalNav(bool value = true)
            _item.LocalNav = value;
    public class NavigationContext
        public string MenuName { get; set; }
        public UrlHelper Url { get; set; }
        public string Area { get; set; }
    public class MenuItem
        public MenuItem()
            Permissions = new Permission[0];
            Classes = new List<string>();
            Items = new List<MenuItem>();
            RouteValues = new RouteValueDictionary();
            LocalNav = false;
            LinkToFirstChild = false;
        public LocalizedString Text { get; set; }
        public string Position { get; set; }
        public string Url { get; set; }
        public string Culture { get; set; }
        public bool LinkToFirstChild { get; set; }
        public bool LocalNav { get; set; }
        public bool Selected { get; set; }
        public IEnumerable<Permission> Permissions { get; set; }
        public IList<string> Classes { get; set; }
        public IList<MenuItem> Items { get; set; }
        public RouteValueDictionary RouteValues { get; set; }
}
