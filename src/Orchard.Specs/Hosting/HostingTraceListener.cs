using Orchard.ContentManagement;
using Orchard.Security;
using Orchard.UI.Admin;
using Orchard.DisplayManagement;
using Orchard.Localization;
using Orchard.Services;
using System.Web.Mvc;
using Orchard.Mvc.Filters;
﻿using System;
using System.Diagnostics;

namespace Orchard.Specs.Hosting {
    public class HostingTraceListener : TraceListener {
        private static Action<string> _hook = ignored => { };
        private string _message;
        public static void SetHook(Action<string> hook) {
            _hook = hook;
        }
        public override void Write(string message) {
            var cumulative = _message + message;
            _message = cumulative;
        public override void WriteLine(string message) {
            _message = null;
            _hook(cumulative);
    }
}
