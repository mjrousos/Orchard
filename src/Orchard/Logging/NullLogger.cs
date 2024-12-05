using Orchard.ContentManagement;
using Orchard.Security;
using Orchard.UI.Admin;
using Orchard.DisplayManagement;
using Orchard.Localization;
using Orchard.Services;
using System.Web.Mvc;
using Orchard.Mvc.Filters;
using System;

namespace Orchard.Logging {
    public class NullLogger : ILogger {
        private static readonly ILogger _instance = new NullLogger();
        public static ILogger Instance {
            get { return _instance; }
        }
        public bool IsEnabled(LogLevel level) {
            return false;
        public void Log(LogLevel level, Exception exception, string format, params object[] args) {
    }
}
