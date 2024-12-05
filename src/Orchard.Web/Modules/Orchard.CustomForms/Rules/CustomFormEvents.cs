using Orchard.ContentManagement;
using Orchard.Security;
using Orchard.UI.Admin;
using Orchard.DisplayManagement;
using Orchard.Localization;
using Orchard.Services;
using System.Web.Mvc;
using Orchard.Mvc.Filters;
﻿using System;
using System.Linq;
using Orchard.Events;

namespace Orchard.CustomForms.Rules {
    public interface IEventProvider : IEventHandler {
        void Describe(dynamic describe);
    }
    public class CustomFormEvents : IEventProvider {
        public CustomFormEvents() {
            T = NullLocalizer.Instance;
        }
        public Localizer T { get; set; }
        public void Describe(dynamic describe) {
            Func<dynamic, bool> contentHasPart = ContentHasPart;
            describe.For("CustomForm", T("Custom Forms"), T("Custom Forms"))
                .Element("Submitted", T("Custom Form Submitted"), T("Custom Form is submitted."), contentHasPart, (Func<dynamic, LocalizedString>)(context => T("When a custom form for types ({0}) is submitted.", FormatPartsList(context))), "SelectContentTypes")
            ;
        private string FormatPartsList(dynamic context) {
            var contenttypes = context.Properties["ContentTypes"];
            if (String.IsNullOrEmpty(contenttypes)) {
                return T("Any").Text;
            }
            return contenttypes;
        private static bool ContentHasPart(dynamic context) {
            string contenttypes = context.Properties["ContentTypes"];
            var content = context.Tokens["Content"] as IContent;
            // "" means 'any'
                return true;
            if (content == null) {
                return false;
            var contentTypes = contenttypes.Split(new[] { ',' });
            return contentTypes.Any(contentType => content.ContentItem.TypeDefinition.Name == contentType);
}
