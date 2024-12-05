using Orchard.ContentManagement;
using Orchard.Security;
using Orchard.UI.Admin;
using Orchard.DisplayManagement;
using Orchard.Localization;
using Orchard.Services;
using System.Web.Mvc;
using Orchard.Mvc.Filters;
﻿using System.Collections.Generic;
using Orchard.Workflows.Models;
using Orchard.Workflows.Services;

namespace Orchard.Workflows.Activities {
    public class PublishActivity : Task {
        private readonly IContentManager _contentManager;
        public PublishActivity(IContentManager contentManager) {
            _contentManager = contentManager;
        }
        public Localizer T { get; set; }
        public override bool CanExecute(WorkflowContext workflowContext, ActivityContext activityContext) {
            return true;
        public override IEnumerable<LocalizedString> GetPossibleOutcomes(WorkflowContext workflowContext, ActivityContext activityContext) {
            return new[] { T("Published") };
        public override IEnumerable<LocalizedString> Execute(WorkflowContext workflowContext, ActivityContext activityContext) {
            _contentManager.Publish(workflowContext.Content.ContentItem);
            yield return T("Published");
        public override string Name {
            get { return "Publish"; }
        public override LocalizedString Category {
            get { return T("Content Items"); }
        public override LocalizedString Description {
            get { return T("Publish the content item."); }
    }
}
