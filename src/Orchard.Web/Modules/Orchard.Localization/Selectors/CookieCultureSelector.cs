using System.Web;
using Orchard.Environment.Configuration;
using Orchard.Environment.Extensions;
using Orchard.Localization.Providers;
using Orchard.Localization.Services;
using Orchard.Mvc;
using Orchard.Services;
using Orchard.UI.Admin;

namespace Orchard.Localization.Selectors {
    [OrchardFeature("Orchard.Localization.CultureSelector")]
    public class CookieCultureSelector : ICultureSelector, ICultureStorageProvider {
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IClock _clock;
        private readonly ShellSettings _shellSettings;

        private const string FrontEndCookieName = "OrchardCurrentCulture-FrontEnd";
        private const string AdminCookieName = "OrchardCurrentCulture-Admin";
        private const int DefaultExpireTimeYear = 1;

        public CookieCultureSelector(
            IHttpContextAccessor httpContextAccessor,
            IClock clock,
            ShellSettings shellSettings) {
            _httpContextAccessor = httpContextAccessor;
            _clock = clock;
            _shellSettings = shellSettings;
        }

        public void SetCulture(string culture) {
            var httpContext = _httpContextAccessor.Current();

            if (httpContext == null) return;

            var cookieName = AdminFilter.IsApplied(httpContext) ? AdminCookieName : FrontEndCookieName;

            var cookie = new HttpCookie(cookieName, culture) {
                Expires = _clock.UtcNow.AddYears(DefaultExpireTimeYear),
                Domain = httpContext.Request.IsLocal ? null : httpContext.Request.Url.Host
            };

            if (!string.IsNullOrEmpty(_shellSettings.RequestUrlPrefix)) {
                cookie.Path = GetCookiePath(httpContext);
            }

            httpContext.Request.Cookies.Remove(cookieName);
            httpContext.Response.Cookies.Remove(cookieName);
            httpContext.Response.Cookies.Add(cookie);
        }

        public CultureSelectorResult GetCulture(HttpContextBase context) {
            if (context == null) return null;

            var cookieName = AdminFilter.IsApplied(context) ? AdminCookieName : FrontEndCookieName;

            var cookie = context.Request.Cookies.Get(cookieName);

            if (cookie != null)
                return new CultureSelectorResult { Priority = -1, CultureName = cookie.Value };

            return null;
        }

        private string GetCookiePath(HttpContextBase httpContext) {
            var cookiePath = httpContext.Request.ApplicationPath;
            if (cookiePath != null && cookiePath.Length > 1) {
                cookiePath += '/';
            }

            cookiePath += _shellSettings.RequestUrlPrefix;

            return cookiePath;
        }
    }
}
