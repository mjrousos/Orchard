using Orchard.ContentManagement;
using Orchard.Security;
using Orchard.UI.Admin;
using Orchard.DisplayManagement;
using Orchard.Localization;
using Orchard.Services;
using System.Web.Mvc;
using Orchard.Mvc.Filters;
using System.Collections.Generic;
using Orchard.Core.Navigation.Models;

namespace Orchard.Core.Navigation.Services {
    public interface IMenuService : IDependency {
        IEnumerable<MenuPart> Get();
        IEnumerable<MenuPart> GetMenuParts(int menuId);
        MenuPart Get(int id);
        IContent GetMenu(int menuId);
        IContent GetMenu(string name);
        IEnumerable<ContentItem> GetMenus();
        IContent Create(string name);
        void Delete(MenuPart menuPart);
    }
}
