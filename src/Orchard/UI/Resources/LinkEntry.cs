using Orchard.ContentManagement;
using Orchard.Security;
using Orchard.UI.Admin;
using Orchard.DisplayManagement;
using Orchard.Localization;
using Orchard.Services;
using System.Web.Mvc;
using Orchard.Mvc.Filters;
﻿using System.Web.Mvc;

namespace Orchard.UI.Resources {
    public class LinkEntry {
        private readonly TagBuilder _builder = new TagBuilder("link");
        public string Condition { get; set; }
        public string Rel {
            get {
                string value;
                _builder.Attributes.TryGetValue("rel", out value);
                return value;
            }
            set { SetAttribute("rel", value); }
        }
        public string Type {
                _builder.Attributes.TryGetValue("type", out value);
            set { SetAttribute("type", value); }
        public string Title {
                _builder.Attributes.TryGetValue("title", out value);
            set { SetAttribute("title", value); }
        public string Href {
                _builder.Attributes.TryGetValue("href", out value);
            set { SetAttribute("href", value); }
        public string Sizes {
                _builder.Attributes.TryGetValue("sizes", out value);
            set { SetAttribute("sizes", value); }
        public string GetTag() {
            string tag = _builder.ToString(TagRenderMode.SelfClosing);
            if (!string.IsNullOrEmpty(Condition)) {
                return "<!--[if " + Condition + "]>" + tag + "<![endif]-->";
            return tag;
        public LinkEntry AddAttribute(string name, string value) {
            _builder.MergeAttribute(name, value);
            return this;
        public LinkEntry SetAttribute(string name, string value) {
            _builder.MergeAttribute(name, value, true);
    }
}
