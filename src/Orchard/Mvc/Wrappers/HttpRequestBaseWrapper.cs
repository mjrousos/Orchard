using Orchard.ContentManagement;
using Orchard.Security;
using Orchard.UI.Admin;
using Orchard.DisplayManagement;
using Orchard.Localization;
using Orchard.Services;
using System.Web.Mvc;
using Orchard.Mvc.Filters;
using System;
using System.Collections.Specialized;
using System.IO;
using System.Security.Principal;
using System.Text;
using System.Web;

namespace Orchard.Mvc.Wrappers {
    public abstract class HttpRequestBaseWrapper : HttpRequestBase {
        protected readonly HttpRequestBase _httpRequestBase;
        protected HttpRequestBaseWrapper(HttpRequestBase httpRequestBase) {
            _httpRequestBase = httpRequestBase;
        }
        public override byte[] BinaryRead(int count) {
            return _httpRequestBase.BinaryRead(count);
        public override int[] MapImageCoordinates(string imageFieldName) {
            return _httpRequestBase.MapImageCoordinates(imageFieldName);
        public override string MapPath(string virtualPath) {
            return _httpRequestBase.MapPath(virtualPath);
        public override string MapPath(string virtualPath, string baseVirtualDir, bool allowCrossAppMapping) {
            return _httpRequestBase.MapPath(virtualPath, baseVirtualDir, allowCrossAppMapping);
        public override void SaveAs(string filename, bool includeHeaders) {
            _httpRequestBase.SaveAs(filename, includeHeaders);
        public override void ValidateInput() {
            _httpRequestBase.ValidateInput();
        public override string[] AcceptTypes {
            get {
                return _httpRequestBase.AcceptTypes;
            }
        public override string AnonymousID {
                return _httpRequestBase.AnonymousID;
        public override string ApplicationPath {
                return _httpRequestBase.ApplicationPath;
        public override string AppRelativeCurrentExecutionFilePath {
                return _httpRequestBase.AppRelativeCurrentExecutionFilePath;
        public override HttpBrowserCapabilitiesBase Browser {
                return _httpRequestBase.Browser;
        public override HttpClientCertificate ClientCertificate {
                return _httpRequestBase.ClientCertificate;
        public override Encoding ContentEncoding {
                return _httpRequestBase.ContentEncoding;
            set {
                _httpRequestBase.ContentEncoding = value;
        public override int ContentLength {
                return _httpRequestBase.ContentLength;
        public override string ContentType {
                return _httpRequestBase.ContentType;
                _httpRequestBase.ContentType = value;
        public override HttpCookieCollection Cookies {
                return _httpRequestBase.Cookies;
        public override string CurrentExecutionFilePath {
                return _httpRequestBase.CurrentExecutionFilePath;
        public override string FilePath {
                return _httpRequestBase.FilePath;
        public override HttpFileCollectionBase Files {
                return _httpRequestBase.Files;
        public override Stream Filter {
                return _httpRequestBase.Filter;
                _httpRequestBase.Filter = value;
        public override NameValueCollection Form {
                return _httpRequestBase.Form;
        public override NameValueCollection Headers {
                return _httpRequestBase.Headers;
        public override string HttpMethod {
                return _httpRequestBase.HttpMethod;
        public override Stream InputStream {
                return _httpRequestBase.InputStream;
        public override bool IsAuthenticated {
                return _httpRequestBase.IsAuthenticated;
        public override bool IsLocal {
                return _httpRequestBase.IsLocal;
        public override bool IsSecureConnection {
                return _httpRequestBase.IsSecureConnection;
        public override string this[string key] {
                return _httpRequestBase[key];
        public override WindowsIdentity LogonUserIdentity {
                return _httpRequestBase.LogonUserIdentity;
        public override NameValueCollection Params {
                return _httpRequestBase.Params;
        public override string Path {
                return _httpRequestBase.Path;
        public override string PathInfo {
                return _httpRequestBase.PathInfo;
        public override string PhysicalApplicationPath {
                return _httpRequestBase.PhysicalApplicationPath;
        public override string PhysicalPath {
                return _httpRequestBase.PhysicalPath;
        public override NameValueCollection QueryString {
                return _httpRequestBase.QueryString;
        public override string RawUrl {
                return _httpRequestBase.RawUrl;
        public override string RequestType {
                return _httpRequestBase.RequestType;
                _httpRequestBase.RequestType = value;
        public override NameValueCollection ServerVariables {
                return _httpRequestBase.ServerVariables;
        public override int TotalBytes {
                return _httpRequestBase.TotalBytes;
        public override Uri Url {
                return _httpRequestBase.Url;
        public override Uri UrlReferrer {
                return _httpRequestBase.UrlReferrer;
        public override string UserAgent {
                return _httpRequestBase.UserAgent;
        public override string UserHostAddress {
                return _httpRequestBase.UserHostAddress;
        public override string UserHostName {
                return _httpRequestBase.UserHostName;
        public override string[] UserLanguages {
                return _httpRequestBase.UserLanguages;
    }
}
