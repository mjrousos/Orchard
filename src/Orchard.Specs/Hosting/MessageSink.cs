using Orchard.ContentManagement;
using Orchard.Security;
using Orchard.UI.Admin;
using Orchard.DisplayManagement;
using Orchard.Localization;
using Orchard.Services;
using System.Web.Mvc;
using Orchard.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace Orchard.Specs.Hosting {
    public class MessageSink : MarshalByRefObject {
        readonly IList<string> _messages = new List<string>();
        public void Receive(string message) {
            Trace.WriteLine("  "+message);
            _messages.Add(message);
        }
    }
}
