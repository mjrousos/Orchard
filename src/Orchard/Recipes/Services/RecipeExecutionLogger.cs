using Orchard.ContentManagement;
using Orchard.Security;
using Orchard.UI.Admin;
using Orchard.DisplayManagement;
using Orchard.Localization;
using Orchard.Services;
using System.Web.Mvc;
using Orchard.Mvc.Filters;
﻿using System;
using Orchard.Logging;

namespace Orchard.Recipes.Services {
    public class RecipeExecutionLogger : ITransientDependency, ILogger {
        public RecipeExecutionLogger() {
            Logger = NullLogger.Instance;
        }
        public Type ComponentType { get; internal set; }
        public ILogger Logger { get; set; }
        public bool IsEnabled(LogLevel level) {
            return Logger.IsEnabled(level);
        public void Log(LogLevel level, Exception exception, string format, params object[] args) {
            var message = args == null ? format : string.Format(format, args);
            Logger.Log(level, exception, "{0}: {1}", ComponentType.Name, message);
    }
}
