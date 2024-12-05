using System;
using Orchard.ContentManagement;
using Orchard.Security;
using Orchard.UI.Notify;

namespace Orchard
{
    public interface IOrchardServices
    {
        IContentManager ContentManager { get; }
        ITransactionManager TransactionManager { get; }
        IAuthorizer Authorizer { get; }
        INotifier Notifier { get; }
        IWorkContext WorkContext { get; }
    }

    public interface ITransactionManager : IDisposable
    {
        void Demand();
        void Cancel();
        void RequireNew();
    }

    public interface IAuthorizer
    {
        bool Authorize(Permission permission);
        bool Authorize(Permission permission, IContent content);
        bool Authorize(Permission permission, IUser user);
        bool Authorize(Permission permission, IContent content, IUser user);
    }

    public class Permission
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string Category { get; set; }
        public Permission ImpliedBy { get; set; }

        public Permission(string name)
        {
            Name = name;
        }
    }

    public interface INotifier
    {
        void Add(NotifyType type, LocalizedString message);
        void Add(NotifyType type, LocalizedString message, string htmlEncode);
    }

    public enum NotifyType
    {
        Information,
        Warning,
        Error,
        Success
    }

    public class OrchardServices : IOrchardServices
    {
        public IContentManager ContentManager { get; set; }
        public ITransactionManager TransactionManager { get; set; }
        public IAuthorizer Authorizer { get; set; }
        public INotifier Notifier { get; set; }
        public IWorkContext WorkContext { get; set; }
    }
}
