using Orchard.ContentManagement;
using Orchard.Security;
using Orchard.UI.Admin;
using Orchard.DisplayManagement;
using Orchard.Localization;
using Orchard.Services;
using System.Web.Mvc;
using Orchard.Mvc.Filters;
using System.Data;
using NHibernate;

namespace Orchard.Data {
    public interface ITransactionManager : IDependency {
        void Demand();
        void RequireNew();
        void RequireNew(IsolationLevel level);
        void Cancel();
        ISession GetSession();
    }
    public class TransactionFilter : FilterProvider, IExceptionFilter {
        private readonly ITransactionManager _transactionManager;
        public TransactionFilter(ITransactionManager transactionManager) {
            _transactionManager = transactionManager;
        }
        public void OnException(ExceptionContext filterContext) {
            _transactionManager.Cancel();
    public class WebApiTransactionFilter : System.Web.Http.Filters.ExceptionFilterAttribute, WebApi.Filters.IApiFilterProvider {
        public WebApiTransactionFilter(ITransactionManager transactionManager) {
        public override void OnException(System.Web.Http.Filters.HttpActionExecutedContext actionExecutedContext) {
}
