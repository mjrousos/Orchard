using Orchard.ContentManagement;
using Orchard.Security;
using Orchard.UI.Admin;
using Orchard.DisplayManagement;
using Orchard.Localization;
using Orchard.Services;
using System.Web.Mvc;
using Orchard.Mvc.Filters;
﻿using System.Collections.Generic;
using System.Linq;
using Orchard.Roles.Constants;

namespace Orchard.Roles.Models {
    public static class UserRolesExtensions {
        /// <summary>
        /// Determines whether the given User has any of the provided list of Roles.
        /// </summary>
        /// <param name="user">The User to examine.</param>
        /// <param name="roles">The list of Roles to compare to User's Roles with.</param>
        /// <returns>True if the User has any of the provided Roles.</returns>
        public static bool UserIsInRole(this IUser user, IEnumerable<string> roles) {
            return UserIsInRole(user.As<UserRolesPart>(), roles);
        }
        public static bool UserIsInRole(this UserRolesPart userRolesPart, IEnumerable<string> roles) {
            if (!roles?.Any() ?? false) return false;
            return userRolesPart == null ?
                roles.Contains(SystemRoles.Anonymous) :
                roles.Contains(SystemRoles.Authenticated) || userRolesPart.Roles.Any(roles.Contains);
        /// Returns the list of Roles the User has, including the ones
        /// that are not assignable (Anonymous or Authenticated).
        /// <param name="user">The User whose Roles are to be retrieved.</param>
        /// <returns>The User's list of Roles.</returns>
        public static IEnumerable<string> GetRuntimeUserRoles(this IUser user) {
            return GetRuntimeUserRoles(user.As<UserRolesPart>());
        /// <param name="user">The UserRolesPart of the User whose Roles are to be retrieved.</param>
        public static IEnumerable<string> GetRuntimeUserRoles(this UserRolesPart userRolesPart) {
            var roles = new List<string>();
            if (userRolesPart == null) roles.Add(SystemRoles.Anonymous);
            else {
                roles.Add(SystemRoles.Authenticated);
                roles.AddRange(userRolesPart.Roles);
            }
            return roles;
    }
}
