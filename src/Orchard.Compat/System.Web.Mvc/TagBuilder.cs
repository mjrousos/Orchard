using Orchard.ContentManagement;
using Orchard.Security;
using Orchard.UI.Admin;
using Orchard.DisplayManagement;
using Orchard.Localization;
using Orchard.Services;
using System.Web.Mvc;
using Orchard.Mvc.Filters;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Text;

namespace System.Web.Mvc
{
    public class TagBuilder
    {
        private readonly Microsoft.AspNetCore.Mvc.Rendering.TagBuilder _coreTagBuilder;

        public TagBuilder(string tagName)
        {
            _coreTagBuilder = new Microsoft.AspNetCore.Mvc.Rendering.TagBuilder(tagName);
        }

        public void AddCssClass(string cssClass)
        {
            _coreTagBuilder.AddCssClass(cssClass);
        }

        public void MergeAttribute(string key, string value, bool replaceExisting = false)
        {
            _coreTagBuilder.MergeAttribute(key, value ?? string.Empty, replaceExisting);
        }

        public string ToString(TagRenderMode renderMode)
        {
            var builder = new StringBuilder();
            switch (renderMode)
            {
                case TagRenderMode.StartTag:
                    builder.Append('<').Append(_coreTagBuilder.TagName);
                    foreach (var attr in _coreTagBuilder.Attributes)
                    {
                        builder.Append(' ').Append(attr.Key).Append("=\"").Append(attr.Value ?? string.Empty).Append('"');
                    }
                    builder.Append('>');
                    return builder.ToString();
                case TagRenderMode.EndTag:
                    return $"</{_coreTagBuilder.TagName}>";
                case TagRenderMode.SelfClosing:
                    builder.Append(" />");
                    return builder.ToString();
                default: // Normal
                    return _coreTagBuilder.ToString() ?? string.Empty;
            }
        }
    }

    public enum TagRenderMode
    {
        Normal,
        StartTag,
        EndTag,
        SelfClosing
    }
}
