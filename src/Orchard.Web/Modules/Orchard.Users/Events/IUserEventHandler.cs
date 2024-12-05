using Orchard.ContentManagement;
using Orchard.Security;
using Orchard.UI.Admin;
using Orchard.DisplayManagement;
using Orchard.Localization;
using Orchard.Services;
using System.Web.Mvc;
using Orchard.Mvc.Filters;
﻿using Orchard.Events;

namespace Orchard.Users.Events {
    public interface IUserEventHandler : IEventHandler {
        /// <summary>
        /// Called before a User is created
        /// </summary>
        void Creating(UserContext context);
        /// Called after a user has been created
        void Created(UserContext context);
        /// Called before a user has logged in
        void LoggingIn(string userNameOrEmail, string password);
        /// Called after a user has logged in
        void LoggedIn(IUser user);
        /// Called when a login attempt failed
        void LogInFailed(string userNameOrEmail, string password);
        /// Called when a user explicitly logs out (as opposed to one whose session cookie simply expires)
        void LoggedOut(IUser user);
        /// Called when access is denied to a user
        void AccessDenied(IUser user);
        /// Called before a user has changed password
        void ChangingPassword(IUser user, string password);
        /// Called after a user has changed password
        void ChangedPassword(IUser user, string password);
        /// Called after a user has confirmed their email address
        void SentChallengeEmail(IUser user);
        void ConfirmedEmail(IUser user);
        /// Called after a user has been approved
        void Approved(IUser user);
        /// Called after a user has been disabled
        void Moderate(IUser user);
    }
}
