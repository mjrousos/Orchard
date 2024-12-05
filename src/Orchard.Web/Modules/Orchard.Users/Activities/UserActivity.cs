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
using Orchard.Workflows.Models;
using Orchard.Workflows.Services;

namespace Orchard.Users.Activities {
    public abstract class UserActivity : Event {
        protected UserActivity() {
            T = NullLocalizer.Instance;
        }
        public Localizer T { get; set; }
        public override bool CanStartWorkflow {
            get { return true; }
        public override bool CanExecute(WorkflowContext workflowContext, ActivityContext activityContext) {
            return true;
        public override IEnumerable<LocalizedString> GetPossibleOutcomes(WorkflowContext workflowContext, ActivityContext activityContext) {
            return new[] {T("Done")};
        public override IEnumerable<LocalizedString> Execute(WorkflowContext workflowContext, ActivityContext activityContext) {
            yield return T("Done");
        public override LocalizedString Category {
            get { return T("Events"); }
    }
    [OrchardFeature("Orchard.Users.Workflows")]
    public class UserCreatingActivity : UserActivity {
        public override string Name {
            get { return "UserCreating"; }
        public override LocalizedString Description {
            get { return T("User is creating."); }
    public class UserCreatedActivity : UserActivity {
            get { return "UserCreated"; }
            get { return T("User is created."); }
    public class UserLoggingInActivity : UserActivity {
            get { return "UserLoggingIn"; }
            get { return T("User is logging in."); }
    public class UserLoggedInActivity : UserActivity {
            get { return "UserLoggedIn"; }
            get { return T("User is logged in."); }
    public class UserLogInFailedActivity : UserActivity {
            get { return "UserLogInFailed"; }
            get { return T("User login failed."); }
    public class UserLoggedOutActivity : UserActivity {
            get { return "UserLoggedOut"; }
            get { return T("User is logged out."); }
    public class UserAccessDeniedActivity : UserActivity {
            get { return "UserAccessDenied"; }
            get { return T("User access is denied."); }
    public class UserChangedPasswordActivity : UserActivity {
            get { return "UserChangedPassword"; }
            get { return T("User changed password."); }
    public class UserSentChallengeEmailActivity : UserActivity {
            get { return "UserSentChallengeEmail"; }
            get { return T("User sent challenge email."); }
    public class UserConfirmedEmailActivity : UserActivity {
            get { return "UserConfirmedEmail"; }
            get { return T("User confirmed email."); }
    public class UserApprovedActivity : UserActivity {
            get { return "UserApproved"; }
            get { return T("User is approved."); }
    public class UserDisabledActivity : UserActivity {
            get { return "UserDisabled"; }
            get { return T("User is Disabled."); }
}
