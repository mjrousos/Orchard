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
using System.Linq;

namespace Orchard.DisplayManagement
{
    [AttributeUsage(AttributeTargets.Method)]
    public class ShapeAttribute : Attribute
    {
        public ShapeAttribute()
        {
            Cache = new Dictionary<string, string>();
        }
        public IDictionary<string, string> Cache { get; set; }
    }
    public class Shape : DynamicObject
        private readonly Dictionary<string, object> _properties;
        private readonly List<string> _wrappers;
        private readonly List<string> _classes;
        public Shape()
            _properties = new Dictionary<string, object>();
            _wrappers = new List<string>();
            _classes = new List<string>();
            Metadata = new ShapeMetadata();
        public ShapeMetadata Metadata { get; set; }
        public override bool TryGetMember(GetMemberBinder binder, out object result)
            return _properties.TryGetValue(binder.Name, out result);
        public override bool TrySetMember(SetMemberBinder binder, object value)
            _properties[binder.Name] = value;
            return true;
        public IList<string> Classes => _classes;
        public IList<string> Wrappers => _wrappers;
    public class ShapeMetadata
        public ShapeMetadata()
            Wrappers = new List<string>();
            Alternates = new List<string>();
            DisplayType = "";
        public string Type { get; set; }
        public string DisplayType { get; set; }
        public string Position { get; set; }
        public string PlacementSource { get; set; }
        public string Prefix { get; set; }
        public IList<string> Wrappers { get; private set; }
        public IList<string> Alternates { get; private set; }
}
namespace Orchard.Environment.Extensions.Models
    public class ShellFeature
        public string Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Category { get; set; }
        public int Priority { get; set; }
        public string[] Dependencies { get; set; }
    public class ShellFeatureState
        public ShellFeature Feature { get; set; }
        public bool IsEnabled { get; set; }
        public bool IsInstalled { get; set; }
        public bool NeedsUpdate { get; set; }
    public class ShellState
        public ShellState()
            Features = new List<ShellFeatureState>();
        public IList<ShellFeatureState> Features { get; set; }
namespace Orchard.Events
    public interface IEventHandler { }
namespace Orchard.ContentManagement
    public interface IContent
        ContentItem ContentItem { get; }
    public class ContentItem
        public int Id { get; set; }
        public string ContentType { get; set; }
    public class ContentField
        public ContentPart Part { get; set; }
    public class ContentPart
        public ContentItem ContentItem { get; set; }
namespace Orchard.Localization
    public class Localizer
        private readonly string _scope;
        public Localizer(string scope)
            _scope = scope;
        public LocalizedString Get(string text, params object[] args)
            return new LocalizedString(_scope, text, args);
    public class LocalizedString
        public LocalizedString(string scope, string text, params object[] args)
            Text = string.Format(text, args);
            TextHint = text;
            Scope = scope;
        public string Text { get; }
        public string TextHint { get; }
        public string Scope { get; }
        public static implicit operator string(LocalizedString s)
            return s.Text;
