using Orchard.ContentManagement;
using Orchard.Security;
using Orchard.UI.Admin;
using Orchard.DisplayManagement;
using Orchard.Localization;
using Orchard.Services;
using System.Web.Mvc;
using Orchard.Mvc.Filters;
﻿using System;
using NuGet;
using Orchard.UI.Notify;

namespace Orchard.Packaging.Models {
    public class NugetLogger : ILogger {
        private readonly INotifier _notifier;
        public NugetLogger(INotifier notifier) {
            _notifier = notifier;
        }
        public void Log(MessageLevel level, string message, params object[] args) {
            switch ( level ) {
                case MessageLevel.Debug:
                    break;
                case MessageLevel.Info:
                    _notifier.Information(new LocalizedString(String.Format(message, args)));
                case MessageLevel.Warning:
                    _notifier.Warning(new LocalizedString(String.Format(message, args)));
            }
    }
}
