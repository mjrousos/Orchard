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
using System.Web.Routing;

namespace Orchard.UI.Navigation
{
    public interface INavigationProvider
    {
        string MenuName { get; }
        void GetNavigation(NavigationBuilder builder);
    }
    public interface IMenuProvider
        IEnumerable<MenuItem> GetMenuItems();
    public interface INavigationFilter
        IEnumerable<MenuItem> Filter(IEnumerable<MenuItem> items);
    public class MenuItem
        public MenuItem()
        {
            Permissions = new List<Permission>();
            Items = new List<MenuItem>();
            Classes = new List<string>();
            Attributes = new RouteValueDictionary();
        }
        public string Text { get; set; }
        public string IdHint { get; set; }
        public string Url { get; set; }
        public string Href { get; set; }
        public string Position { get; set; }
        public bool Selected { get; set; }
        public RouteValueDictionary RouteValues { get; set; }
        public IList<string> Classes { get; set; }
        public IDictionary<string, object> Attributes { get; set; }
        public IList<MenuItem> Items { get; set; }
        public IEnumerable<Permission> Permissions { get; set; }
        public string Culture { get; set; }
        public string LocalNav { get; set; }
    public class NavigationBuilder
        private readonly List<MenuItem> _items;
        public NavigationBuilder()
            _items = new List<MenuItem>();
        public NavigationBuilder Add(Action<NavigationItemBuilder> itemBuilder)
            var builder = new NavigationItemBuilder();
            itemBuilder(builder);
            _items.Add(builder.Build());
            return this;
        public IEnumerable<MenuItem> Build()
            return _items;
    public class NavigationItemBuilder
        private readonly MenuItem _item;
        public NavigationItemBuilder()
            _item = new MenuItem();
        public NavigationItemBuilder Caption(string caption)
            _item.Text = caption;
        public NavigationItemBuilder Position(string position)
            _item.Position = position;
        public NavigationItemBuilder Url(string url)
            _item.Url = url;
        public MenuItem Build()
            return _item;
}
namespace Orchard.ContentManagement.MetaData.Models
    public class ContentPartDefinition
        public string Name { get; set; }
        public IDictionary<string, string> Settings { get; set; }
        public IList<ContentPartFieldDefinition> Fields { get; set; }
    public class ContentPartFieldDefinition
        public string FieldDefinition { get; set; }
    public class ContentFieldDefinition
namespace Orchard.Data.Migration
    public abstract class DataMigrationImpl : IDataMigration
        public virtual string DataFeature { get; set; }
        public virtual string DataVersion { get; set; }
    public interface IDataMigration
        string DataFeature { get; }
        string DataVersion { get; }
namespace Orchard.Caching
    public interface ISignals
        void Trigger(string signal);
        IVolatileToken When(string signal);
    public interface IVolatileToken
        bool IsCurrent { get; }
    public class AcquireContext<T>
        public string Key { get; set; }
        public T Result { get; set; }
namespace Orchard.Services
    public interface ISettingsFormatter
        string Map(IDictionary<string, string> settings);
        IDictionary<string, string> Parse(string settings);
