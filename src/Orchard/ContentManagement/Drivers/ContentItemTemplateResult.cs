using Orchard.ContentManagement;
using Orchard.Security;
using Orchard.UI.Admin;
using Orchard.DisplayManagement;
using Orchard.Localization;
using Orchard.Services;
using System.Web.Mvc;
using Orchard.Mvc.Filters;
using System.Linq;
using Orchard.ContentManagement.Handlers;

namespace Orchard.ContentManagement.Drivers {
    public class ContentItemTemplateResult<TContent> : DriverResult where TContent : class, IContent {
        public ContentItemTemplateResult(string templateName) {
            TemplateName = templateName;
        }
        public string TemplateName { get; set; }
        public override void Apply(BuildDisplayContext context) {
        public override void Apply(BuildEditorContext context) {
        class ViewDataContainer : IViewDataContainer {
            public ViewDataDictionary ViewData { get; set; }
        public ContentItemTemplateResult<TContent> LongestMatch(string displayType, params string[] knownDisplayTypes) {
            if (string.IsNullOrEmpty(displayType))
                return this;
            var longest = knownDisplayTypes.Aggregate("", (best, x) => {
                if (displayType.StartsWith(x) && x.Length > best.Length) return x;
                return best;
            });
            if (string.IsNullOrEmpty(longest))
            TemplateName += "." + longest;
            return this;
    }
}
