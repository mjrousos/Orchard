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
    public class DeleteActivity : Task {
        private readonly IContentManager _contentManager;
        public DeleteActivity(IContentManager contentManager) {
            _contentManager = contentManager;
        }
        public Localizer T { get; set; }
        public override bool CanExecute(WorkflowContext workflowContext, ActivityContext activityContext) {
            return true;
        public override IEnumerable<LocalizedString> GetPossibleOutcomes(WorkflowContext workflowContext, ActivityContext activityContext) {
            return new[] { T("Deleted") };
        public override IEnumerable<LocalizedString> Execute(WorkflowContext workflowContext, ActivityContext activityContext) {
            _contentManager.Remove(workflowContext.Content.ContentItem);
            yield return T("Deleted");
        public override string Name {
            get { return "Delete"; }
        public override LocalizedString Category {
            get { return T("Content Items"); }
        public override LocalizedString Description {
            get { return T("Delete the content item."); }
    }
}
