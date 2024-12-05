using Orchard.ContentManagement;
using Orchard.Security;
using Orchard.UI.Admin;
using Orchard.DisplayManagement;
using Orchard.Localization;
using Orchard.Services;
using System.Web.Mvc;
using Orchard.Mvc.Filters;
﻿using System;
using Orchard.Utility.Extensions;

namespace Orchard.ContentManagement.Handlers {
    public class TemplateFilterForPart<TPart> : TemplateFilterBase<ContentPart> where TPart : ContentPart, new() {
        private readonly string _prefix;
        private string _location = "Content";
        private string _position = "5";
        private readonly string _templateName;
        private string _groupId;
        public TemplateFilterForPart(string prefix, string templateName) {
            _prefix = prefix;
            _templateName = templateName;
        }
        public TemplateFilterForPart(string prefix, string templateName, string groupId) {
            _groupId = groupId;
        public TemplateFilterForPart<TPart> Location(string location) {
            _location = location;
            return this;
        public TemplateFilterForPart<TPart> Position(string position) {
            _position = position;
        public TemplateFilterForPart<TPart> Group(string groupId) {
        protected override void BuildEditorShape(BuildEditorContext context, ContentPart part) {
            if (!_groupId.SafeNameEquals(context.GroupId, StringComparison.OrdinalIgnoreCase))
                return;
            var templatePart = part.As<TPart>();
            if (templatePart != null) {
                var templateShape = context.New.EditorTemplate(TemplateName: _templateName, Model: templatePart, Prefix: _prefix);
                context.Shape.Zones[_location].Add(templateShape, _position);
            }
        protected override void UpdateEditorShape(UpdateEditorContext context, ContentPart part) {
                context.Updater.TryUpdateModel(templatePart, _prefix, null, null);
                BuildEditorShape(context, part);
    }
}
