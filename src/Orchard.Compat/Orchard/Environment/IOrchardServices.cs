using Orchard.ContentManagement;
using Orchard.Security;
using Orchard.UI.Admin;
using Orchard.DisplayManagement;
using Orchard.Localization;
using Orchard.Services;
using System.Web.Mvc;
using Orchard.Mvc.Filters;
using Orchard.Caching;
using Orchard.Data;
using Orchard.UI.Notify;

namespace Orchard
{
    public interface IOrchardServices
    {
        IContentManager ContentManager { get; }
        ITransactionManager TransactionManager { get; }
        IAuthorizationService AuthorizationService { get; }
        INotifier Notifier { get; }
        ICacheManager CacheManager { get; }
        WorkContext WorkContext { get; }
    }

    public class WorkContext
    {
        public dynamic Layout { get; set; }
        public string CurrentSite { get; set; }
        public string CurrentTheme { get; set; }
        public string CurrentCulture { get; set; }
    }
}

namespace Orchard.Environment.Configuration
{
    public class ShellSettings
    {
        public string Name { get; set; }
        public string RequestUrlHost { get; set; }
        public string RequestUrlPrefix { get; set; }
        public string DataProvider { get; set; }
        public string DataConnectionString { get; set; }
        public string DataTablePrefix { get; set; }
        public string State { get; set; }
        public bool EnabledFeatures { get; set; }
        public bool EncryptionEnabled { get; set; }
        public string EncryptionKey { get; set; }
        public string HashKey { get; set; }
    }
}

namespace Orchard.UI.Notify
{
    public interface INotifier
    {
        void Add(NotifyType type, string message);
        void Add(NotifyType type, string message, string htmlEncode);
    }

    public enum NotifyType
    {
        Information,
        Warning,
        Error,
        Success
    }
}

namespace Orchard.ContentManagement
{
    public interface IContentManager
    {
        ContentItem New(string contentType);
        ContentItem Get(int id);
        ContentItem Get(int id, VersionOptions options);
        IEnumerable<ContentItem> GetAllVersions(int id);
        ContentItem Create(ContentItem contentItem);
        ContentItem Create(string contentType);
        void Remove(ContentItem contentItem);
        void Publish(ContentItem contentItem);
        void Unpublish(ContentItem contentItem);
    }

    public class VersionOptions
    {
        public static readonly VersionOptions Latest = new VersionOptions { IsLatest = true };
        public static readonly VersionOptions Published = new VersionOptions { IsPublished = true };
        public static readonly VersionOptions Draft = new VersionOptions { IsDraft = true };
        public static readonly VersionOptions AllVersions = new VersionOptions { IsAllVersions = true };
        public bool IsLatest { get; set; }
        public bool IsPublished { get; set; }
        public bool IsDraft { get; set; }
        public bool IsAllVersions { get; set; }
    }
}
