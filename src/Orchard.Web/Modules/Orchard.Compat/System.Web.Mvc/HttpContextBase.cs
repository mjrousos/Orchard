using System;
using Microsoft.AspNetCore.Http;

namespace System.Web
{
    public abstract class HttpContextBase
    {
        protected HttpContextBase() { }

        public virtual HttpRequestBase Request { get; }
        public virtual HttpResponseBase Response { get; }
        public virtual IPrincipal User { get; set; }
        public virtual IDictionary Items { get; }
        public virtual SessionStateBase Session { get; }
        public virtual Cache Cache { get; }
        public virtual IHttpHandler Handler { get; set; }
    }

    public abstract class HttpRequestBase
    {
        protected HttpRequestBase() { }

        public virtual string ApplicationPath { get; }
        public virtual string Path { get; }
        public virtual string PathInfo { get; }
        public virtual string RawUrl { get; }
        public virtual Uri Url { get; }
        public virtual NameValueCollection QueryString { get; }
        public virtual NameValueCollection Form { get; }
        public virtual HttpCookieCollection Cookies { get; }
    }

    public abstract class HttpResponseBase
    {
        protected HttpResponseBase() { }

        public virtual void Write(string s) { }
        public virtual void End() { }
        public virtual void Redirect(string url) { }
        public virtual void SetCookie(HttpCookie cookie) { }
    }

    public class HttpCookie
    {
        public HttpCookie(string name)
        {
            Name = name;
        }

        public string Name { get; }
        public string Value { get; set; }
        public DateTime Expires { get; set; }
    }

    public class HttpCookieCollection : NameValueCollection { }
    public class SessionStateBase { }
    public class Cache { }
    public interface IHttpHandler { }
    public class NameValueCollection : System.Collections.Specialized.NameValueCollection { }
}
