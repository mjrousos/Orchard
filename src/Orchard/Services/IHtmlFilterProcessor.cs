using Orchard.ContentManagement;
using Orchard.Security;
using Orchard.UI.Admin;
using Orchard.DisplayManagement;
using Orchard.Localization;
using Orchard.Services;
using System.Web.Mvc;
using Orchard.Mvc.Filters;
﻿using System.Collections.Generic;

namespace Orchard.Services {
    public interface IHtmlFilterProcessor : IDependency {
        string ProcessFilters(string text, HtmlFilterContext context);
    }
    public static class HtmlFilterProcessorExtensions {
        public static string ProcessFilters(
            this IHtmlFilterProcessor processor,
            string text,
            string flavor,
            IDictionary<string, object> data) =>
            processor.ProcessFilters(text, new HtmlFilterContext { Flavor = flavor, Data = data });
        public static string ProcessFilters(this IHtmlFilterProcessor processor, string text, string flavor) =>
            processor.ProcessFilters(text, new HtmlFilterContext { Flavor = flavor });
        public static string ProcessFilters(this IHtmlFilterProcessor processor, string text, string flavor, IContent content) =>
            processor.ProcessFilters(
                text,
                new HtmlFilterContext {
                    Flavor = flavor,
                    Data = new Dictionary<string, object> { { "Content", content.ContentItem } }
                });
}
