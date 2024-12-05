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
using Orchard.DynamicForms.Services.Models;
using Orchard.Workflows.Models;
using Orchard.Workflows.Services;

namespace Orchard.DynamicForms.Activities {
    public abstract class DynamicFormActivity : Event {
        protected DynamicFormActivity() {
            T = NullLocalizer.Instance;
        }
        public Localizer T { get; set; }
        public override bool CanStartWorkflow {
            get { return true; }
        public override bool CanExecute(WorkflowContext workflowContext, ActivityContext activityContext) {
            var forms = activityContext.GetState<string>("DynamicForms");
            // "" means 'any'.
            if (String.IsNullOrEmpty(forms)) {
                return true;
            }
            var submission = (FormSubmissionTokenContext)workflowContext.Tokens["FormSubmission"];
            if (submission == null) {
                return false;
            var formNames = forms.Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
            return formNames.Any(x => x == submission.Form.Name);
        public override IEnumerable<LocalizedString> GetPossibleOutcomes(WorkflowContext workflowContext, ActivityContext activityContext) {
            return new[] { T("Done") };
        public override IEnumerable<LocalizedString> Execute(WorkflowContext workflowContext, ActivityContext activityContext) {
            yield return T("Done");
        public override string Form {
            get {
                return "SelectDynamicForms";
        public override LocalizedString Category {
            get { return T("Forms"); }
    }
}
