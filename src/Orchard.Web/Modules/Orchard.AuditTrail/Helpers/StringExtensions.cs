using Orchard.ContentManagement;
using Orchard.Security;
using Orchard.UI.Admin;
using Orchard.DisplayManagement;
using Orchard.Localization;
using Orchard.Services;
using System.Web.Mvc;
using Orchard.Mvc.Filters;
﻿using System;
using System.Text.RegularExpressions;

namespace Orchard.AuditTrail.Helpers {
    public static class StringExtensions {
        public static int? ToInt32(this string value) {
            if (String.IsNullOrWhiteSpace(value))
                return null;
            int i;
            if(!Int32.TryParse(value, out i))
            return i;
        }
        public static string OrIfEmpty(this string value, LocalizedString emptyString) {
            return String.IsNullOrWhiteSpace(value) ? emptyString.Text : value;
        public static string NewlinesToHtml(this string value) {
            return String.IsNullOrWhiteSpace(value) ? value : Regex.Replace(value, @"\n", "<br/>");
    }
}
