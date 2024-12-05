using Orchard.ContentManagement;
using Orchard.Security;
using Orchard.UI.Admin;
using Orchard.DisplayManagement;
using Orchard.Localization;
using Orchard.Services;
using System.Web.Mvc;
using Orchard.Mvc.Filters;
namespace Orchard.Glimpse.Interceptors {
    public interface IGlimpseMessageInterceptor : IDependency {
        void MessageReceived<TMessage>(TMessage message) where TMessage : class;
    }
}
