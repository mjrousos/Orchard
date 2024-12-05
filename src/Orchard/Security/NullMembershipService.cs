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

namespace Orchard.Security {
    /// <summary>
    /// Provides a default implementation of <c>IMembershipService</c> used only for dependency resolution
    /// in a setup context. No members on this implementation will ever be called; at the time when this
    /// interface is actually used in a tenant, another implementation is assumed to have suppressed it.
    /// </summary>
    public class NullMembershipService : IMembershipService {
        public IUser CreateUser(CreateUserParams createUserParams) {
            throw new NotImplementedException();
        }
        public IMembershipSettings GetSettings() {
        public IUser GetUser(string username) {
        public void SetPassword(IUser user, string password) {
        public IUser ValidateUser(string userNameOrEmail, string password, out List<LocalizedString> validationErrors) {
        public bool PasswordIsExpired(IUser user, int weeks) {
    }
}
