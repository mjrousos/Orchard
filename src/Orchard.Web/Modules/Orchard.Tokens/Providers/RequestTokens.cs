using Orchard.ContentManagement;
using Orchard.Security;
using Orchard.UI.Admin;
using Orchard.DisplayManagement;
using Orchard.Localization;
using Orchard.Services;
using System.Web.Mvc;
using Orchard.Mvc.Filters;
using System;
using System.Linq;
using System.Web;
using System.Globalization;
using System.Text.RegularExpressions;

namespace Orchard.Tokens.Providers {
    public class RequestTokens : ITokenProvider {
        private readonly IWorkContextAccessor _workContextAccessor;
        private readonly IContentManager _contentManager;
        private static string[] _textChainableTokens;

        public RequestTokens(IWorkContextAccessor workContextAccessor, IContentManager contentManager) {
            _workContextAccessor = workContextAccessor;
            _contentManager = contentManager;
            _textChainableTokens = new string[] { "QueryString", "Form", "Header" };
            T = NullLocalizer.Instance;
        }

        public Localizer T { get; set; }

        public void Describe(DescribeContext context) {
            context.For("Request", T("Http Request"), T("Current Http Request tokens."))
                .Token("QueryString:*", T("QueryString:<element>"), T("The Query String value for the specified element. To chain text, surround the <element> with parentheses, e.g. 'QueryString:(param1)'."))
                .Token("Form:*", T("Form:<element>"), T("The Form value for the specified element. To chain text, surround the <element> with parentheses, e.g. 'Form:(param1)'."))
                .Token("Route:*", T("Route:<key>"), T("The Route value for the specified key."))
                .Token("Content", T("Content"), T("The request routed Content Item."), "Content")
                .Token("Header:*", T("Header:<element>"), T("The Header value for the specified element. To chain text, surround the <element> with parentheses, e.g. 'Header:(param1)'."));
        }

        public void Evaluate(EvaluateContext context) {
            if (_workContextAccessor.GetContext().HttpContext == null) {
                return;
            }

            context.For("Request", _workContextAccessor.GetContext().HttpContext.Request)
                .Token(
                    token => token.StartsWith("QueryString:", StringComparison.OrdinalIgnoreCase) ? FilterTokenParam(token) : null,
                    (token, request) => request.QueryString.Get(token)
                )
                .Chain(
                    token => token.StartsWith("QueryString:", StringComparison.OrdinalIgnoreCase) ? FilterChainParam(token) : null,
                    "Text",
                    (token, request) => request.QueryString.Get(token)
                )
                .Token(
                    token => token.StartsWith("Form:", StringComparison.OrdinalIgnoreCase) ? FilterTokenParam(token) : null,
                    (token, request) => request.Form.Get(token)
                )
                .Chain(
                    token => token.StartsWith("Form:", StringComparison.OrdinalIgnoreCase) ? FilterChainParam(token) : null,
                    "Text",
                    (token, request) => request.Form.Get(token)
                )
                .Token(
                    token => token.StartsWith("Header:", StringComparison.OrdinalIgnoreCase) ? FilterTokenParam(token) : null,
                    (token, request) => request.Headers[token]
                )
                .Chain(
                    token => token.StartsWith("Header:", StringComparison.OrdinalIgnoreCase) ? FilterChainParam(token) : null,
                    "Text",
                    (token, request) => request.Headers[token]
                )
                .Token(
                    token => token.StartsWith("Route:", StringComparison.OrdinalIgnoreCase) ? token.Substring("Route:".Length) : null,
                    (token, request) => GetRouteValue(token, request)
                )
                .Token(
                    "Content",
                    request => DisplayText(GetRoutedContentItem(request))
                )
                .Chain(
                    "Content",
                    "Content",
                    request => GetRoutedContentItem(request)
                );
        }

        private static string GetRouteValue(string token, HttpRequestBase request) {
            object result;
            if (!request.RequestContext.RouteData.Values.TryGetValue(token, out result)) {
                return String.Empty;
            }
            return result.ToString();
        }

        private ContentItem GetRoutedContentItem(HttpRequestBase request) {
            String area = GetRouteValue("area", request);
            String action = GetRouteValue("action", request);
            int contentId;

            if (!String.Equals(area, "Containers", StringComparison.OrdinalIgnoreCase) &&
                !String.Equals(area, "Contents", StringComparison.OrdinalIgnoreCase)) {
                return null;
            }

            if (!String.Equals(GetRouteValue("controller", request), "Item", StringComparison.OrdinalIgnoreCase)) {
                return null;
            }

            if (!int.TryParse(GetRouteValue("id", request), out contentId)) {
                return null;
            }

            if (String.Equals(action, "Display", StringComparison.OrdinalIgnoreCase)) {
                return _contentManager.Get(contentId, VersionOptions.Published);
            }
            else if (String.Equals(action, "Preview", StringComparison.OrdinalIgnoreCase)) {
                VersionOptions versionOptions = VersionOptions.Latest;
                int version;
                if (int.TryParse(request.QueryString["version"], out version)) {
                    versionOptions = VersionOptions.Number(version);
                }
                return _contentManager.Get(contentId, versionOptions);
            }

            return null;
        }

        private string DisplayText(IContent content) {
            if (content == null) {
                return String.Empty;
            }
            return _contentManager.GetItemMetadata(content).DisplayText;
        }

        private static string FilterTokenParam(string token) {
            string tokenPrefix;
            int chainIndex, tokenLength;

            if (token.IndexOf(":") == -1) {
                return null;
            }

            tokenPrefix = token.Substring(0, token.IndexOf(":"));
            if (!_textChainableTokens.Contains(tokenPrefix, StringComparer.OrdinalIgnoreCase)) {
                return token.Substring((tokenPrefix + ":").Length);
            }

            chainIndex = token.IndexOf(").") + 1;
            tokenLength = (tokenPrefix + ":").Length;

            if (chainIndex == 0) {
                return token.Substring(tokenLength).Trim(new char[] { '(', ')' });
            }

            if (!token.StartsWith((tokenPrefix + ":"), StringComparison.OrdinalIgnoreCase) || chainIndex <= tokenLength) {
                return null;
            }

            return token.Substring(tokenLength, chainIndex - tokenLength).Trim(new char[] { '(', ')' });
        }

        private static Tuple<string, string> FilterChainParam(string token) {
            string tokenPrefix = token.Substring(0, token.IndexOf(":"));
            int chainIndex = token.IndexOf(").") + 1;
            int tokenLength = (tokenPrefix + ":").Length;

            if (chainIndex == 0) {
                return new Tuple<string, string>(token.Substring(tokenLength).Trim(new char[] { '(', ')' }), "");
            }

            return new Tuple<string, string>(
                token.Substring(tokenLength, chainIndex - tokenLength).Trim(new char[] { '(', ')' }),
                token.Substring(chainIndex + 1));
        }
    }
}
