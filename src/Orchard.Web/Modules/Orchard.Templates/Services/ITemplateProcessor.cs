using Orchard.ContentManagement;
using Orchard.Security;
using Orchard.UI.Admin;
using Orchard.DisplayManagement;
using Orchard.Localization;
using Orchard.Services;
using System.Web.Mvc;
using Orchard.Mvc.Filters;
﻿using Orchard.DisplayManagement.Implementation;

namespace Orchard.Templates.Services {
    public interface ITemplateProcessor : IDependency {
        string Type { get; }
        string Process(string template, string name, DisplayContext context = null, dynamic model = null);
        void Verify(string template);
    }
}
