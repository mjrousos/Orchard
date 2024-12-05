using Orchard.ContentManagement;
using Orchard.Security;
using Orchard.UI.Admin;
using Orchard.DisplayManagement;
using Orchard.Localization;
using Orchard.Services;
using System.Web.Mvc;
using Orchard.Mvc.Filters;
using System;
using System.Web;

namespace Orchard.Tokens {
    public class ReplaceOptions {
        public Func<string, bool> Predicate { get; set; }
        public Func<string, object, string> Encoding { get; set; }

        public static string HtmlEncode(string token, object value) {
            return HttpUtility.HtmlEncode(value);
        }

        public static string NoEncode(string token, object value) {
            return Convert.ToString(value);
        }

        public static string UrlEncode(string token, object value) {
            return HttpUtility.UrlEncode(value.ToString());
        }

        public static ReplaceOptions Default {
            get {
                return new ReplaceOptions { Encoding = HtmlEncode };
            }
        }
    }
}
