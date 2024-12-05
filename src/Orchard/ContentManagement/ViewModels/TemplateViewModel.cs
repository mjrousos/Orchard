using Orchard.ContentManagement;
using Orchard.Security;
using Orchard.UI.Admin;
using Orchard.DisplayManagement;
using Orchard.Localization;
using Orchard.Services;
using System.Web.Mvc;
using Orchard.Mvc.Filters;
﻿namespace Orchard.ContentManagement.ViewModels {
    public class TemplateViewModel {
        public TemplateViewModel(object model)
            : this(model, string.Empty) {
        }
        public TemplateViewModel(object model, string prefix) {
            Model = model;
            Prefix = prefix;

        public object Model { get; set; }
        public string Prefix { get; set; }
        public string TemplateName { get; set; }
        public string ZoneName { get; set; }
        public string Position { get; set; }
        public bool WasUsed { get; set; }
    }
}
