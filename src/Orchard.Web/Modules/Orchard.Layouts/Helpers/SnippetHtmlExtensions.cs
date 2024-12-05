using Orchard.ContentManagement;
using Orchard.Security;
using Orchard.UI.Admin;
using Orchard.DisplayManagement;
using Orchard.Localization;
using Orchard.Services;
using System.Web.Mvc;
using Orchard.Mvc.Filters;
﻿using System;
using System.Web;
using Orchard.Layouts.Elements;
using Orchard.Layouts.Models;

namespace Orchard.Layouts.Helpers {
    public static class SnippetHtmlExtensions {
        public static SnippetFieldDescriptorBuilder SnippetField(this HtmlHelper htmlHelper, string name, string type = null) {
            var shape = (dynamic)htmlHelper.ViewData.Model;
            return new SnippetFieldDescriptorBuilder(shape)
                .Named(name)
                .WithType(type);
        }
        public class SnippetFieldDescriptorBuilder : IHtmlString {
            private readonly dynamic _shape;
            public SnippetFieldDescriptorBuilder(dynamic shape) {
                _shape = shape;
                Descriptor = new SnippetFieldDescriptor();
            }
            public SnippetFieldDescriptor Descriptor { get; private set; }
            public SnippetFieldDescriptorBuilder Named(string value) {
                Descriptor.Name = value;
                return this;
            public SnippetFieldDescriptorBuilder WithType(string value) {
                Descriptor.Type = value;
            public SnippetFieldDescriptorBuilder DisplayedAs(LocalizedString value) {
                Descriptor.DisplayName = value;
            public SnippetFieldDescriptorBuilder WithDescription(LocalizedString value) {
                Descriptor.Description = value;
            public override string ToString() {
                ((Action<SnippetFieldDescriptor>)_shape.DescriptorRegistrationCallback)?.Invoke(Descriptor);
                var element = (Snippet)_shape.Element;
                return element?.Data.Get(Descriptor.Name);
            public string ToHtmlString() {
                return ToString();
    }
}
