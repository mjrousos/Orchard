using Orchard.ContentManagement;
using Orchard.Security;
using Orchard.UI.Admin;
using Orchard.DisplayManagement;
using Orchard.Localization;
using Orchard.Services;
using System.Web.Mvc;
using Orchard.Mvc.Filters;
using System;
using System.Collections;
using System.Globalization;
using System.Security.Principal;
using System.Web;
using System.Web.Caching;
using System.Web.Profile;

namespace Orchard.Mvc.Wrappers {
    public abstract class HttpContextBaseWrapper : HttpContextBase {
        protected readonly HttpContextBase _httpContextBase;
        protected HttpContextBaseWrapper(HttpContextBase httpContextBase) {
            _httpContextBase = httpContextBase;
        }
        public override void AddError(Exception errorInfo) {
            _httpContextBase.AddError(errorInfo);
        public override void ClearError() {
            _httpContextBase.ClearError();
        public override object GetGlobalResourceObject(string classKey, string resourceKey) {
            return _httpContextBase.GetGlobalResourceObject(classKey, resourceKey);
        public override object GetGlobalResourceObject(string classKey, string resourceKey, CultureInfo culture) {
            return _httpContextBase.GetGlobalResourceObject(classKey, resourceKey, culture);
        public override object GetLocalResourceObject(string virtualPath, string resourceKey) {
            return _httpContextBase.GetLocalResourceObject(virtualPath, resourceKey);
        public override object GetLocalResourceObject(string virtualPath, string resourceKey, CultureInfo culture) {
            return _httpContextBase.GetLocalResourceObject(virtualPath, resourceKey, culture);
        public override object GetSection(string sectionName) {
            return _httpContextBase.GetSection(sectionName);
        public override object GetService(Type serviceType) {
            return ((IServiceProvider)_httpContextBase).GetService(serviceType);
        public override void RewritePath(string path) {
            _httpContextBase.RewritePath(path);
        public override void RewritePath(string path, bool rebaseClientPath) {
            _httpContextBase.RewritePath(path, rebaseClientPath);
        public override void RewritePath(string filePath, string pathInfo, string queryString) {
            _httpContextBase.RewritePath(filePath, pathInfo, queryString);
        public override void RewritePath(string filePath, string pathInfo, string queryString, bool setClientFilePath) {
            _httpContextBase.RewritePath(filePath, pathInfo, queryString, setClientFilePath);
        public override Exception[] AllErrors {
            get {
                return _httpContextBase.AllErrors;
            }
        public override HttpApplicationStateBase Application {
                return _httpContextBase.Application;
        public override HttpApplication ApplicationInstance {
                return _httpContextBase.ApplicationInstance;
            set {
                _httpContextBase.ApplicationInstance = value;
        public override Cache Cache {
                return _httpContextBase.Cache;
        public override IHttpHandler CurrentHandler {
                return _httpContextBase.CurrentHandler;
        public override RequestNotification CurrentNotification {
                return _httpContextBase.CurrentNotification;
        public override Exception Error {
                return _httpContextBase.Error;
        public override IHttpHandler Handler {
                return _httpContextBase.Handler;
                _httpContextBase.Handler = value;
        public override bool IsCustomErrorEnabled {
                return _httpContextBase.IsCustomErrorEnabled;
        public override bool IsDebuggingEnabled {
                return _httpContextBase.IsDebuggingEnabled;
        public override bool IsPostNotification {
        public override IDictionary Items {
                return _httpContextBase.Items;
        public override IHttpHandler PreviousHandler {
                return _httpContextBase.PreviousHandler;
        public override ProfileBase Profile {
                return _httpContextBase.Profile;
        public override HttpRequestBase Request {
                return _httpContextBase.Request;
        public override HttpResponseBase Response {
                return _httpContextBase.Response;
        public override HttpServerUtilityBase Server {
                return _httpContextBase.Server;
        public override HttpSessionStateBase Session {
                return _httpContextBase.Session;
        public override bool SkipAuthorization {
                return _httpContextBase.SkipAuthorization;
                _httpContextBase.SkipAuthorization = value;
        public override DateTime Timestamp {
                return _httpContextBase.Timestamp;
        public override TraceContext Trace {
                return _httpContextBase.Trace;
        public override IPrincipal User {
                return _httpContextBase.User;
                _httpContextBase.User = value;
    }
}
