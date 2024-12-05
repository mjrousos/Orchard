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
using System.Dynamic;

namespace Orchard.DisplayManagement
{
    public interface IShape : IDynamicMetaObjectProvider
    {
        string Id { get; set; }
        string Type { get; set; }
        string Classes { get; set; }
        IDictionary<string, string> Attributes { get; }
        IList<string> Classes_List { get; }
        IEnumerable<dynamic> Items { get; set; }
    }
    public interface IShapeFactory
        dynamic Create(string shapeType);
        dynamic Create(string shapeType, INamedEnumerable<object> parameters);
        dynamic Create(string shapeType, object parameters);
    public interface IShapeDisplay
        string Display(IShape shape);
        string Display(IShape shape, string displayType);
    public interface INamedEnumerable<T> : IEnumerable<T>
        IDictionary<string, T> Named { get; }
    public class Component
        public virtual string Type { get; set; }
        public virtual IDictionary<string, object> Properties { get; set; }
        public virtual IList<Component> Components { get; set; }
        public Component()
        {
            Properties = new Dictionary<string, object>();
            Components = new List<Component>();
        }
    public class ShapeMetadata
        public string Type { get; set; }
        public string DisplayType { get; set; }
        public string Position { get; set; }
        public string PlacementSource { get; set; }
        public string Prefix { get; set; }
        public string Name { get; set; }
        public AlternatesCollection Alternates { get; set; }
        public AlternatesCollection Wrappers { get; set; }
        public ShapeMetadata()
            Alternates = new AlternatesCollection();
            Wrappers = new AlternatesCollection();
    public class AlternatesCollection : List<string>
        public void Add(string format, params object[] args)
            Add(String.Format(format, args));
    [AttributeUsage(AttributeTargets.Class)]
    public class ShapeAttribute : Attribute
}
