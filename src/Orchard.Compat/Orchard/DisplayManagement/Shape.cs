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
    [AttributeUsage(AttributeTargets.Method)]
    public class ShapeAttribute : Attribute
    {
        public string ShapeType { get; set; }
    }
    public class Shape : DynamicObject
        private readonly Dictionary<string, object> _properties = new Dictionary<string, object>();
        public override bool TryGetMember(GetMemberBinder binder, out object result)
        {
            return _properties.TryGetValue(binder.Name, out result);
        }
        public override bool TrySetMember(SetMemberBinder binder, object value)
            _properties[binder.Name] = value;
            return true;
        public override IEnumerable<string> GetDynamicMemberNames()
            return _properties.Keys;
}
namespace Orchard.Environment.Extensions.Models
    public class ShellFeatureState
        public string Name { get; set; }
        public bool IsEnabled { get; set; }
        public bool NeedsUpdate { get; set; }
        public bool IsInstalled { get; set; }
    public class ShellState
        public ShellState()
            Features = new List<ShellFeatureState>();
        public IList<ShellFeatureState> Features { get; set; }
namespace Orchard.Environment
    public interface IOrchardServices
        IContentManager ContentManager { get; }
        ITransactionManager TransactionManager { get; }
        IAuthorizer Authorizer { get; }
        INotifier Notifier { get; }
        WorkContext WorkContext { get; }
    public class WorkContext
        private readonly IDictionary<string, object> _state = new Dictionary<string, object>();
        public T Resolve<T>() where T : class
            if (_state.TryGetValue(typeof(T).FullName, out object value))
            {
                return value as T;
            }
            return null;
        public void Set<T>(T value) where T : class
            _state[typeof(T).FullName] = value;
namespace Orchard.ContentManagement
    public interface IContentManager
        IContent New(string contentType);
        IContent Get(int id);
        void Create(IContent content);
        void Remove(IContent content);
    public interface IContent
        int Id { get; }
        string ContentType { get; }
    public abstract class ContentField
namespace Orchard.Security
    public interface IAuthorizer
        bool Authorize(Permission permission);
        bool Authorize(Permission permission, IContent content);
    public interface IMembershipService
        bool ValidateUser(string userNameOrEmail, string password);
        void SetPassword(string userName, string password);
    public abstract class Permission
        public string Name { get; protected set; }
        public string Description { get; protected set; }
        public string Category { get; protected set; }
namespace Orchard.UI.Notify
    public interface INotifier
        void Add(NotifyType type, string message);
    public enum NotifyType
        Information,
        Warning,
        Error,
        Success
namespace Orchard.Data
    public interface ITransactionManager
        void Demand();
        void Cancel();
        void RequireNew();
    public interface IRepository<T>
        void Create(T entity);
        void Update(T entity);
        void Delete(T entity);
        T Get(int id);
        IQueryable<T> Table { get; }
namespace Orchard.Caching
    public interface ICacheManager
        T Get<T>(string key, Func<T> factory);
        void Remove(string key);
namespace Orchard.ContentManagement.MetaData
    public interface IContentDefinitionManager
        IEnumerable<ContentTypeDefinition> ListTypeDefinitions();
        ContentTypeDefinition GetTypeDefinition(string name);
    public class ContentTypeDefinition
        public string DisplayName { get; set; }
namespace Orchard.Events
    public interface IEventHandler
namespace Orchard.Localization
    public class Localizer
        private readonly string _scope;
        public Localizer(string scope)
            _scope = scope;
        public LocalizedString this[string text]
            get { return new LocalizedString(_scope, text); }
    public class LocalizedString
        public LocalizedString(string scope, string text)
            Scope = scope;
            Text = text;
        public string Scope { get; }
        public string Text { get; }
        public static implicit operator string(LocalizedString s)
            return s.Text;
