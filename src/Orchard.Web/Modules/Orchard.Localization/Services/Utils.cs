using Orchard.ContentManagement;
using Orchard.Security;
using Orchard.UI.Admin;
using Orchard.DisplayManagement;
using Orchard.Localization;
using Orchard.Services;
using System.Web.Mvc;
using Orchard.Mvc.Filters;
﻿using System.Web;

namespace Orchard.CulturePicker.Services {
    public static class Utils {
        public static string GetReturnUrl(HttpRequestBase request) {
            if (request.UrlReferrer == null) {
                return "";
            }
            string localUrl = GetAppRelativePath(request.UrlReferrer.AbsolutePath, request);
            return HttpUtility.UrlDecode(localUrl);
        }
        public static string GetAppRelativePath(string logicalPath, HttpRequestBase request) {
            if (request.ApplicationPath == null) {
            logicalPath = logicalPath.ToLower();
            string appPath = request.ApplicationPath.ToLower();
            if (appPath != "/") {
                appPath += "/";
            else {
                return logicalPath.Substring(1);
            return logicalPath.Replace(appPath, "");
    }
}
