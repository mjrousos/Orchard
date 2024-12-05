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

namespace Orchard.Workflows.Services {
    public interface IActivity : IDependency {
        string Name { get; }
        LocalizedString Category { get; }
        LocalizedString Description { get; }
        bool IsEvent { get; }
        bool CanStartWorkflow { get; }
        string Form { get; }
        /// <summary>
        /// List of possible outcomes when the activity is executed.
        /// </summary>
        IEnumerable<LocalizedString> GetPossibleOutcomes(WorkflowContext workflowContext, ActivityContext activityContext);
        /// Whether the activity can transition to the next outcome. Can prevent the activity from being transitioned
        /// because a condition is not valid.
        bool CanExecute(WorkflowContext workflowContext, ActivityContext activityContext);
        /// Executes the current activity
        /// <returns>The names of the resulting outcomes.</returns>
        IEnumerable<LocalizedString> Execute(WorkflowContext workflowContext, ActivityContext activityContext);
        /// Called on each activity when a workflow is about to start
        void OnWorkflowStarting(WorkflowContext context, CancellationToken cancellationToken);
        /// Called on each activity when a workflow has started
        void OnWorkflowStarted(WorkflowContext context);
        /// Called on each activity when a workflow is about to be resumed
        void OnWorkflowResuming(WorkflowContext context, CancellationToken cancellationToken);
        /// Called on each activity when a workflow is resumed
        void OnWorkflowResumed(WorkflowContext context);
        /// Called on each activity when an activity is about to be executed
        void OnActivityExecuting(WorkflowContext workflowContext, ActivityContext activityContext, CancellationToken cancellationToken);
        /// Called on each activity when an activity has been executed
        void OnActivityExecuted(WorkflowContext workflowContext, ActivityContext activityContext);
    }
}
