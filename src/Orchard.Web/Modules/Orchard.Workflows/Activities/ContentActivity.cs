using Orchard.ContentManagement;
using Orchard.Security;
using Orchard.UI.Admin;
using Orchard.DisplayManagement;
using Orchard.Localization;
using Orchard.Services;
using System.Web.Mvc;
using Orchard.Mvc.Filters;
﻿using System;
using System.Collections.Generic;
using System.Linq;
using Orchard.Workflows.Models;
using Orchard.Workflows.Services;

namespace Orchard.Workflows.Activities {
    public abstract class ContentActivity : Event {
        public Localizer T { get; set; }
        public override bool CanStartWorkflow {
            get { return true; }
        }
        public override bool CanExecute(WorkflowContext workflowContext, ActivityContext activityContext) {
            try {
                var contentTypesState = activityContext.GetState<string>("ContentTypes");
                // "" means 'any'
                if (String.IsNullOrEmpty(contentTypesState)) {
                    return true;
                }
                string[] contentTypes = contentTypesState.Split(',');
                var content = workflowContext.Content;
                if (content == null) {
                    return false;
                return contentTypes.Any(contentType => content.ContentItem.TypeDefinition.Name == contentType);
            }
            catch {
                return false;
        public override IEnumerable<LocalizedString> GetPossibleOutcomes(WorkflowContext workflowContext, ActivityContext activityContext) {
            return new[] { T("Done") };
        public override IEnumerable<LocalizedString> Execute(WorkflowContext workflowContext, ActivityContext activityContext) {
            yield return T("Done");
        public override string Form {
            get {
                return "SelectContentTypes";
        public override LocalizedString Category {
            get { return T("Content Items"); }
    }
    public class ContentCreatedActivity : ContentActivity {
        public override string Name {
            get { return "ContentCreated"; }
        public override LocalizedString Description {
            get { return T("Content is created."); }
    public class ContentUpdatedActivity : ContentActivity {
            get { return "ContentUpdated"; }
            get { return T("Content is updated."); }
    public class ContentFirstUpdatedActivity : ContentActivity {
            get { return "ContentFirstUpdated"; }
            get { return T("Content is updated for the first time."); }
    public class ContentPublishedActivity : ContentActivity {
            get { return "ContentPublished"; }
            get { return T("Content is published."); }
    public class ContentUnpublishedActivity : ContentActivity {
            get { return "ContentUnpublished"; }
            get { return T("Content is unpublished."); }
    public class ContentVersionedActivity : ContentActivity {
            get { return "ContentVersioned"; }
            get { return T("Content is versioned."); }
    public class ContentRemovedActivity : ContentActivity {
            get { return "ContentRemoved"; }
            get { return T("Content is removed."); }
}
