using Orchard.ContentManagement;
using Orchard.Security;
using Orchard.UI.Admin;
using Orchard.DisplayManagement;
using Orchard.Localization;
using Orchard.Services;
using System.Web.Mvc;
using Orchard.Mvc.Filters;
﻿using System;
using System.Web.Security;

namespace Orchard.Security.Providers {
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1065:DoNotRaiseExceptionsInUnexpectedLocations")]
    public class OrchardRoleProvider : RoleProvider {
        public override bool IsUserInRole(string username, string roleName) {
            throw new NotImplementedException();
        }
        public override string[] GetRolesForUser(string username) {
        public override void CreateRole(string roleName) {
        public override bool DeleteRole(string roleName, bool throwOnPopulatedRole) {
        public override bool RoleExists(string roleName) {
        public override void AddUsersToRoles(string[] usernames, string[] roleNames) {
        public override void RemoveUsersFromRoles(string[] usernames, string[] roleNames) {
        public override string[] GetUsersInRole(string roleName) {
        public override string[] GetAllRoles() {
        public override string[] FindUsersInRole(string roleName, string usernameToMatch) {
        public override string ApplicationName {
            get { throw new NotImplementedException(); }
            set { throw new NotImplementedException(); }
    }
}
