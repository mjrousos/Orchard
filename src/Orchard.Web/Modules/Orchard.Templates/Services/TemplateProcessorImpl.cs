using Orchard.ContentManagement;
using Orchard.Security;
using Orchard.UI.Admin;
using Orchard.DisplayManagement;
using Orchard.Localization;
using Orchard.Services;
using System.Web.Mvc;
using Orchard.Mvc.Filters;
﻿using System;
using Orchard.DisplayManagement.Implementation;

namespace Orchard.Templates.Services {
    public abstract class TemplateProcessorImpl : ITemplateProcessor {
        public abstract string Type { get; }
        public abstract string Process(string template, string name, DisplayContext context = null, dynamic model = null);
        public virtual void Verify(string template) { }
    }
}
