using Orchard.ContentManagement;
using Orchard.Security;
using Orchard.UI.Admin;
using Orchard.DisplayManagement;
using Orchard.Localization;
using Orchard.Services;
using System.Web.Mvc;
using Orchard.Mvc.Filters;
using Microsoft.AspNetCore.Http;
using System.Security.Principal;
using System.Web.SessionState;

namespace System.Web.Http
{
    public class HttpContext
    {
        private readonly Microsoft.AspNetCore.Http.HttpContext _context;
        private HttpRequest _request;
        private HttpResponse _response;
        private IPrincipal _user;
        private IHttpSessionState _session;

        public HttpContext(Microsoft.AspNetCore.Http.HttpContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public HttpRequest Request
        {
            get
            {
                if (_request == null)
                {
                    _request = new HttpRequest(_context.Request);
                }
                return _request;
            }
        }

        public HttpResponse Response
        {
            get
            {
                if (_response == null)
                {
                    _response = new HttpResponse(_context.Response);
                }
                return _response;
            }
        }

        public IPrincipal User
        {
            get => _user ?? _context.User;
            set => _user = value;
        }

        public IHttpSessionState Session
        {
            get
            {
                if (_session == null)
                {
                    _session = new HttpSessionStateWrapper(_context.Session);
                }
                return _session;
            }
        }
    }

    public class HttpRequest
    {
        private readonly Microsoft.AspNetCore.Http.HttpRequest _request;

        public HttpRequest(Microsoft.AspNetCore.Http.HttpRequest request)
        {
            _request = request ?? throw new ArgumentNullException(nameof(request));
        }

        public string Path => _request.Path;
        public string ApplicationPath => _request.PathBase;
        public string Url => $"{_request.Scheme}://{_request.Host}{_request.PathBase}{_request.Path}{_request.QueryString}";
    }

    public class HttpResponse
    {
        private readonly Microsoft.AspNetCore.Http.HttpResponse _response;

        public HttpResponse(Microsoft.AspNetCore.Http.HttpResponse response)
        {
            _response = response ?? throw new ArgumentNullException(nameof(response));
        }

        public int StatusCode
        {
            get => _response.StatusCode;
            set => _response.StatusCode = value;
        }

        public void Redirect(string url)
        {
            _response.Redirect(url);
        }
    }

    public interface IHttpSessionState
    {
        object this[string name] { get; set; }
        void Remove(string name);
        void Clear();
    }

    public class HttpSessionStateWrapper : IHttpSessionState
    {
        private readonly ISession _session;

        public HttpSessionStateWrapper(ISession session)
        {
            _session = session ?? throw new ArgumentNullException(nameof(session));
        }

        public object this[string name]
        {
            get => _session.GetString(name);
            set => _session.SetString(name, value?.ToString());
        }

        public void Remove(string name)
        {
            _session.Remove(name);
        }

        public void Clear()
        {
            _session.Clear();
        }
    }
}
