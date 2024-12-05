using Orchard.ContentManagement;
using Orchard.Security;
using Orchard.UI.Admin;
using Orchard.DisplayManagement;
using Orchard.Localization;
using Orchard.Services;
using System.Web.Mvc;
using Orchard.Mvc.Filters;
﻿using System;
using Orchard.ContentManagement.Records;

namespace Orchard.ContentManagement.Handlers {
    public class TemplateFilterForRecord<TRecord> : TemplateFilterBase<ContentPart<TRecord>> where TRecord : ContentPartRecord, new() {
        private readonly string _prefix;
        private string _location = "Content";
        private string _position = "5";
        private readonly string _templateName;
        private string _groupId;
        public TemplateFilterForRecord(string prefix, string templateName) {
            _prefix = prefix;
            _templateName = templateName;
        }
        public TemplateFilterForRecord(string prefix, string templateName, string groupId) {
            _groupId = groupId;
        public TemplateFilterForRecord<TRecord> Location(string location) {
            _location = location;
            return this;
        public TemplateFilterForRecord<TRecord> Position(string position) {
            _position = position;
        public TemplateFilterForRecord<TRecord> Group(string groupId) {
        protected override void BuildEditorShape(BuildEditorContext context, ContentPart<TRecord> part) {
            if (!string.Equals(_groupId, context.GroupId, StringComparison.OrdinalIgnoreCase))
                return;
            var templateShape = context.New.EditorTemplate(TemplateName: _templateName, Model: part.Record, Prefix: _prefix);
            context.Shape.Zones[_location].Add(templateShape, _position);
        protected override void UpdateEditorShape(UpdateEditorContext context, ContentPart<TRecord> part) {
            context.Updater.TryUpdateModel(part.Record, _prefix, null, null);
            BuildEditorShape(context, part);
    }
}
