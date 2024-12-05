using Orchard.ContentManagement;
using Orchard.Security;
using Orchard.UI.Admin;
using Orchard.DisplayManagement;
using Orchard.Localization;
using Orchard.Services;
using System.Web.Mvc;
using Orchard.Mvc.Filters;
﻿using System;
using System.IO;

namespace Orchard {
    public class Logger : MarshalByRefObject {
        private readonly bool _verbose;
        private readonly TextWriter _output;
        public Logger(bool verbose, TextWriter output) {
            _verbose = verbose;
            _output = output;
        }
        public void LogInfo(string format, params object[] args) {
            if (_verbose) {
                _output.Write("{0}: ", DateTime.Now);
                _output.WriteLine(format, args);
            }
        public override object InitializeLifetimeService() {
            // never expire the cross-AppDomain lease on this object
            return null;
    }
}
