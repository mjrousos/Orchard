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
using Orchard.Workflows.Services;

namespace Orchard.Roles.Events {
    [OrchardFeature("Orchard.Roles.Workflows")]
    public class RoleEventHandler : IRoleEventHandler {
        private readonly IWorkflowManager _workflowManager;
        public RoleEventHandler(IWorkflowManager workflowManager) {
            _workflowManager = workflowManager;
        }
        public void Created(RoleCreatedContext context) {
            _workflowManager.TriggerEvent("OnRoleEvent",
               null,
               () => new Dictionary<string, object> {
                    { "Role", context.Role },
                    { "Action", "Created" } });
        public void PermissionAdded(PermissionAddedContext context) {
                    { "Permission", context.Permission },
                    { "Action", "PermissionAdded" } });
        public void PermissionRemoved(PermissionRemovedContext context) {
                    { "Action", "PermissionRemoved" } });
        public void Removed(RoleRemovedContext context) {
                    { "Action", "Removed" } });
        public void Renamed(RoleRenamedContext context) {
                    { "PreviousName", context.PreviousRoleName },
                    { "NewName", context.NewRoleName },
                    { "Action", "Renamed" } });
        public void UserAdded(UserAddedContext context) {
            // Content of workflow event is the user
            var content = context.User.ContentItem;
                content,
                () => new Dictionary<string, object> {
                    { "User", context.User },
                    { "Action", "UserAdded" } });
        public void UserRemoved(UserRemovedContext context) {
               content,
                    { "Action", "UserRemoved" } });
    }
}
