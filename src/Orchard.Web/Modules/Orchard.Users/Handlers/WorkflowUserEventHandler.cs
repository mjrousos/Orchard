using Orchard.ContentManagement;
using Orchard.Security;
using Orchard.UI.Admin;
using Orchard.DisplayManagement;
using Orchard.Localization;
using Orchard.Services;
using System.Web.Mvc;
using Orchard.Mvc.Filters;
﻿using System.Collections.Generic;
using Orchard.Environment.Extensions;
using Orchard.Users.Events;
using Orchard.Workflows.Services;

namespace Orchard.Users.Handlers {
    [OrchardFeature("Orchard.Users.Workflows")]
    public class WorkflowUserEventHandler : IUserEventHandler {
        private readonly IWorkflowManager _workflowManager;
        public WorkflowUserEventHandler(IWorkflowManager workflowManager) {
            _workflowManager = workflowManager;
        }
        public void Creating(UserContext context) {
            _workflowManager.TriggerEvent("UserCreating",
                                         context.User,
                                         () => new Dictionary<string, object> {
                                             {"User", context.User},
                                             {"UserParameters", context.UserParameters}
                                         });
        public void Created(UserContext context) {
            _workflowManager.TriggerEvent("UserCreated",
        public void LoggingIn(string userNameOrEmail, string password) {
            _workflowManager.TriggerEvent("UserLoggingIn",
                                         null,
                                         () => new Dictionary<string, object>{{"UserNameOrEmail", userNameOrEmail}, {"Password", password}});
        public void LoggedIn(Security.IUser user) {
            _workflowManager.TriggerEvent("UserLoggedIn",
                                         user,
                                         () => new Dictionary<string, object> {{"User", user}});
        public void LogInFailed(string userNameOrEmail, string password) {
            _workflowManager.TriggerEvent("UserLogInFailed",
                                         () => new Dictionary<string, object> { { "UserNameOrEmail", userNameOrEmail }, { "Password", password } });
        public void LoggedOut(Security.IUser user) {
            _workflowManager.TriggerEvent("UserLoggedOut",
        public void AccessDenied(Security.IUser user) {
            _workflowManager.TriggerEvent("UserAccessDenied",
        public void ChangedPassword(Security.IUser user, string password) {
            _workflowManager.TriggerEvent("UserChangedPassword",
                                         () => new Dictionary<string, object> {{"User", user}, { "Password", password } });
        public void SentChallengeEmail(Security.IUser user) {
            _workflowManager.TriggerEvent("UserSentChallengeEmail",
        public void ConfirmedEmail(Security.IUser user) {
            _workflowManager.TriggerEvent("UserConfirmedEmail",
        public void Approved(Security.IUser user) {
            _workflowManager.TriggerEvent("UserApproved",
        public void Moderate(Security.IUser user) {
            _workflowManager.TriggerEvent("UserDisabled",
                                         () => new Dictionary<string, object> { { "User", user } });
        //TODO evaluate if we need a workflow event for this
        public void ChangingPassword(Security.IUser user, string password) {
    }
}
