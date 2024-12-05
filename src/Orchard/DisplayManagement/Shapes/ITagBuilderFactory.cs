using Orchard.ContentManagement;
using Orchard.Security;
using Orchard.UI.Admin;
using Orchard.DisplayManagement;
using Orchard.Localization;
using Orchard.Services;
using System.Web.Mvc;
using Orchard.Mvc.Filters;
﻿using System.Linq;
using System.Web;

namespace Orchard.DisplayManagement.Shapes {
    public interface ITagBuilderFactory : IDependency {
        OrchardTagBuilder Create(dynamic shape, string tagName);
    }
    public class OrchardTagBuilder : TagBuilder {
        public OrchardTagBuilder(string tagName) : base(tagName) { }
        public IHtmlString StartElement { get { return new HtmlString(ToString(TagRenderMode.StartTag)); } }
        public IHtmlString EndElement { get { return new HtmlString(ToString(TagRenderMode.EndTag)); } }
        public IHtmlString ToHtmlString(TagRenderMode renderMode = TagRenderMode.Normal) {
            return new HtmlString(ToString(renderMode));
        }
    public class TagBuilderFactory : ITagBuilderFactory {
        public OrchardTagBuilder Create(dynamic shape, string tagName) {
            var tagBuilder = new OrchardTagBuilder(tagName);
            tagBuilder.MergeAttributes(shape.Attributes, false);
            foreach (var cssClass in shape.Classes ?? Enumerable.Empty<string>())
                tagBuilder.AddCssClass(cssClass);
            if (!string.IsNullOrEmpty(shape.Id))
                tagBuilder.GenerateId(shape.Id);
            return tagBuilder;
}
