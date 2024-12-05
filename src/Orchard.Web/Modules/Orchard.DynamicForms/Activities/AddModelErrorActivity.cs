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

namespace Orchard.DynamicForms.Activities {
    public class AddModelErrorActivity : Task {
        public AddModelErrorActivity() {
            T = NullLocalizer.Instance;
        }
        public Localizer T { get; set; }
        public override string Name {
            get { return "AddModelError"; }
        public override LocalizedString Category {
            get { return T("Forms"); }
        public override LocalizedString Description {
            get { return T("Add a model validation error"); }
        public override string Form {
        public override IEnumerable<LocalizedString> GetPossibleOutcomes(WorkflowContext workflowContext, ActivityContext activityContext) {
            return new[] {T("Done")};
        public override bool CanExecute(WorkflowContext workflowContext, ActivityContext activityContext) {
            return workflowContext.Tokens.ContainsKey("Updater") && workflowContext.Tokens["Updater"] is IUpdateModel;
        public override IEnumerable<LocalizedString> Execute(WorkflowContext workflowContext, ActivityContext activityContext) {
            var key = activityContext.GetState<string>("Key");
            var message = activityContext.GetState<string>("ErrorMessage");
            var updater = (IUpdateModel) workflowContext.Tokens["Updater"];
            updater.AddModelError(key, T(message));
            return new[] { T("Done") };
    }
}
