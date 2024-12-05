using Orchard.ContentManagement;
using Orchard.Security;
using Orchard.UI.Admin;
using Orchard.DisplayManagement;
using Orchard.Localization;
using Orchard.Services;
using System.Web.Mvc;
using Orchard.Mvc.Filters;
using System.Collections.Generic;
using Orchard.Environment.Extensions;
using Orchard.Users.Events;
using Orchard.Users.Models;
using Orchard.Workflows.Models;
using Orchard.Workflows.Services;

namespace Orchard.Users.Activities {
    [OrchardFeature("Orchard.Users.Workflows")]
    public class ApproveUserActivity : Task {
        private readonly IUserEventHandler _userEventHandlers;
        public ApproveUserActivity(IUserEventHandler userEventHandlers) {
            _userEventHandlers = userEventHandlers;
            T = NullLocalizer.Instance;
        }
        public Localizer T { get; set; }
        public override string Name {
            get { return "ApproveUser"; }
        public override LocalizedString Category {
            get { return T("User"); }
        public override LocalizedString Description {
            get { return T("If the content item is a user, that user will be approved."); }
        public override bool CanExecute(WorkflowContext workflowContext, ActivityContext activityContext) {
            return workflowContext.Content != null && workflowContext.Content.Is<UserPart>();
        public override IEnumerable<LocalizedString> GetPossibleOutcomes(WorkflowContext workflowContext, ActivityContext activityContext) {
            return new[] { T("Done") };
        public override IEnumerable<LocalizedString> Execute(WorkflowContext workflowContext, ActivityContext activityContext) {
            var user = workflowContext.Content.As<UserPart>();
            user.RegistrationStatus = UserStatus.Approved;
            user.EmailStatus = UserStatus.Approved;
            _userEventHandlers.Approved(user);
            yield return T("Done");
    }
}
