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
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web.Security;
using Orchard.Logging;
using Orchard.Mvc;
using Orchard.Mvc.Extensions;
using Orchard.Themes;
using Orchard.UI.Notify;
using Orchard.Users.Events;
using Orchard.Users.Models;
using Orchard.Users.Services;
using Orchard.Utility.Extensions;

namespace Orchard.Users.Controllers {
    [HandleError, Themed]
    public class AccountController : Controller {
        private readonly IAuthenticationService _authenticationService;
        private readonly IMembershipService _membershipService;
        private readonly IUserService _userService;
        private readonly IOrchardServices _orchardServices;
        private readonly IUserEventHandler _userEventHandler;
        private readonly IClock _clock;
        private readonly IAccountValidationService _accountValidationService;
        public AccountController(
            IAuthenticationService authenticationService,
            IMembershipService membershipService,
            IUserService userService,
            IOrchardServices orchardServices,
            IUserEventHandler userEventHandler,
            IClock clock,
            IAccountValidationService accountValidationService) {
            _authenticationService = authenticationService;
            _membershipService = membershipService;
            _userService = userService;
            _orchardServices = orchardServices;
            _userEventHandler = userEventHandler;
            _clock = clock;
            _accountValidationService = accountValidationService;
            Logger = NullLogger.Instance;
            T = NullLocalizer.Instance;
        }
        public ILogger Logger { get; set; }
        public Localizer T { get; set; }
        [AlwaysAccessible]
        public ActionResult AccessDenied() {
            var returnUrl = Request.QueryString["ReturnUrl"];
            var currentUser = _authenticationService.GetAuthenticatedUser();
            if (currentUser == null) {
                Logger.Information("Access denied to anonymous request on {0}", returnUrl);
                var shape = _orchardServices.New.LogOn().Title(T("Access Denied").Text);
                return new ShapeResult(this, shape);
            }
            Logger.Information("Access denied to user #{0} '{1}' on {2}", currentUser.Id, currentUser.UserName, returnUrl);
            _userEventHandler.AccessDenied(currentUser);
            return View();
        public ActionResult LogOn(string returnUrl) {
            if (_authenticationService.GetAuthenticatedUser() != null)
                return this.RedirectLocal(returnUrl);
            var shape = _orchardServices.New.LogOn().Title(T("Log On").Text);
            return new ShapeResult(this, shape);
        [HttpPost]
        [ValidateInput(false)]
        [SuppressMessage("Microsoft.Design", "CA1054:UriParametersShouldNotBeStrings",
            Justification = "Needs to take same parameter type as Controller.Redirect()")]
        public ActionResult LogOn(string userNameOrEmail, string password, string returnUrl, bool rememberMe = false) {
            _userEventHandler.LoggingIn(userNameOrEmail, password);
            var user = ValidateLogOn(userNameOrEmail, password);
            if (!ModelState.IsValid) {
                var shape = _orchardServices.New.LogOn().Title(T("Log On").Text);
            var membershipSettings = _membershipService.GetSettings();
            if (user != null &&
                membershipSettings.EnableCustomPasswordPolicy &&
                membershipSettings.EnablePasswordExpiration &&
                _membershipService.PasswordIsExpired(user, membershipSettings.PasswordExpirationTimeInDays)) {
                return RedirectToAction("ChangeExpiredPassword", new { username = user.UserName });
            if (user != null && user.As<UserPart>().ForcePasswordChange) {
            _authenticationService.SignIn(user, rememberMe);
            _userEventHandler.LoggedIn(user);
            return this.RedirectLocal(returnUrl);
        public ActionResult LogOff(string returnUrl) {
            _authenticationService.SignOut();
            var loggedUser = _authenticationService.GetAuthenticatedUser();
            if (loggedUser != null) {
                _userEventHandler.LoggedOut(loggedUser);
        public ActionResult Register() {
            // ensure users can register
            if (!membershipSettings.UsersCanRegister) {
                return HttpNotFound();
            ViewData["PasswordLength"] = membershipSettings.GetMinimumPasswordLength();
            ViewData["LowercaseRequirement"] = membershipSettings.GetPasswordLowercaseRequirement();
            ViewData["UppercaseRequirement"] = membershipSettings.GetPasswordUppercaseRequirement();
            ViewData["SpecialCharacterRequirement"] = membershipSettings.GetPasswordSpecialRequirement();
            ViewData["NumberRequirement"] = membershipSettings.GetPasswordNumberRequirement();
            var shape = _orchardServices.New.Register();
        public ActionResult Register(string userName, string email, string password, string confirmPassword, string returnUrl = null) {
            if (ValidateRegistration(userName, email, password, confirmPassword)) {
                // Attempt to register the user
                // No need to report this to IUserEventHandler because _membershipService does that for us
                var user = _membershipService.CreateUser(new CreateUserParams(userName, password, email, null, null, false, false));
                if (user != null) {
                    if (user.As<UserPart>().EmailStatus == UserStatus.Pending) {
                        var siteUrl = _orchardServices.WorkContext.CurrentSite.BaseUrl;
                        if (String.IsNullOrWhiteSpace(siteUrl)) {
                            siteUrl = HttpContext.Request.ToRootUrlString();
                        }
                        _userService.SendChallengeEmail(user.As<UserPart>(), nonce => Url.MakeAbsolute(Url.Action("ChallengeEmail", "Account", new { Area = "Orchard.Users", nonce = nonce }), siteUrl));
                        _userEventHandler.SentChallengeEmail(user);
                        return RedirectToAction("ChallengeEmailSent", new { ReturnUrl = returnUrl });
                    }
                    if (user.As<UserPart>().RegistrationStatus == UserStatus.Pending) {
                        return RedirectToAction("RegistrationPending", new { ReturnUrl = returnUrl });
                    _userEventHandler.LoggingIn(userName, password);
                    _authenticationService.SignIn(user, false /* createPersistentCookie */);
                    _userEventHandler.LoggedIn(user);
                    return this.RedirectLocal(returnUrl);
                }
                ModelState.AddModelError("_FORM", T(ErrorCodeToString(/*createStatus*/MembershipCreateStatus.ProviderError)));
            // If we got this far, something failed, redisplay form
        public ActionResult RequestLostPassword() {
            // ensure users can request lost password
            if (!membershipSettings.EnableLostPassword) {
        public ActionResult RequestLostPassword(string username) {
            if (string.IsNullOrWhiteSpace(username)) {
                ModelState.AddModelError("username", T("You must specify a username or e-mail."));
                return View();
            var siteUrl = _orchardServices.WorkContext.CurrentSite.BaseUrl;
            if (string.IsNullOrWhiteSpace(siteUrl)) {
                siteUrl = HttpContext.Request.ToRootUrlString();
            _userService.SendLostPasswordEmail(username, nonce =>
                Url.MakeAbsolute(Url.Action("LostPassword", "Account", new { Area = "Orchard.Users", nonce }), siteUrl));
            _orchardServices.Notifier.Information(T("If your username or email is correct, we will send you an email with a link to reset your password."));
            return RedirectToAction("LogOn");
        public ActionResult RequestChallengeEmail(string email = null) {
            if (!membershipSettings.UsersMustValidateEmail) {
            return View(model: email);
        [HttpPost, ActionName("RequestChallengeEmail")]
        public ActionResult RequestChallengeEmailPOST(string username) {
            // Get the user
            var user = _userService.GetUserByNameOrEmail(username);
            if (user != null && user.EmailStatus == UserStatus.Pending) {
                var siteUrl = _orchardServices.WorkContext.CurrentSite.BaseUrl;
                if (string.IsNullOrWhiteSpace(siteUrl)) {
                    siteUrl = HttpContext.Request.ToRootUrlString();
                _userService.SendChallengeEmail(user.As<UserPart>(), nonce => Url.MakeAbsolute(Url.Action("ChallengeEmail", "Account", new { Area = "Orchard.Users", nonce = nonce }), siteUrl));
                _userEventHandler.SentChallengeEmail(user);
            return RedirectToAction("ChallengeEmailSent");
        [Authorize]
        public ActionResult ChangePassword() {
            ViewData["InvalidateOnPasswordChange"] = _orchardServices.WorkContext
                .CurrentSite.As<SecuritySettingsPart>()
                .ShouldInvalidateAuthOnPasswordChanged;
        [SuppressMessage("Microsoft.Design", "CA1031:DoNotCatchGeneralExceptionTypes",
            Justification = "Exceptions result in password not being changed.")]
        public ActionResult ChangePassword(string currentPassword, string newPassword, string confirmPassword) {
            var shouldSignout = _orchardServices.WorkContext
            ViewData["InvalidateOnPasswordChange"] = shouldSignout;
            if (!ValidateChangePassword(currentPassword, newPassword, confirmPassword, _orchardServices.WorkContext.CurrentUser)) {
            if (PasswordChangeIsSuccess(currentPassword, newPassword, _orchardServices.WorkContext.CurrentUser.UserName)) {
                if (shouldSignout) {
                    _authenticationService.SignOut();
                    var loggedUser = _authenticationService.GetAuthenticatedUser();
                    if (loggedUser != null) {
                        _userEventHandler.LoggedOut(loggedUser);
                return RedirectToAction("ChangePasswordSuccess");
            } else {
                return ChangePassword();
        public ActionResult ChangeExpiredPassword(string username) {
                return RedirectToAction("LogOn");
            var userPart = _membershipService.GetUser(username)?.As<UserPart>();
            if (userPart == null) {
                // user not valid / doesn't exist
            // if the password hasn't actually expired for the user, redirect to logon
            var passwordIsActuallyExpired = membershipSettings.EnableCustomPasswordPolicy
                && membershipSettings.EnablePasswordExpiration
                && _membershipService.PasswordIsExpired(userPart, membershipSettings.PasswordExpirationTimeInDays);
            if (!passwordIsActuallyExpired && !userPart.ForcePasswordChange) {
            var viewModel = _orchardServices.New.ViewModel(
                Username: username,
                PasswordLength: membershipSettings.GetMinimumPasswordLength(),
                LowercaseRequirement: membershipSettings.GetPasswordLowercaseRequirement(),
                UppercaseRequirement: membershipSettings.GetPasswordUppercaseRequirement(),
                SpecialCharacterRequirement: membershipSettings.GetPasswordSpecialRequirement(),
                NumberRequirement: membershipSettings.GetPasswordNumberRequirement());
            return View(viewModel);
        [HttpPost, AlwaysAccessible, ValidateInput(false)]
        public ActionResult ChangeExpiredPassword(string currentPassword, string newPassword, string confirmPassword, string username) {
            if (!ValidateChangePassword(currentPassword, newPassword, confirmPassword, _membershipService.GetUser(username))) {
                return View(viewModel);
            if (PasswordChangeIsSuccess(currentPassword, newPassword, username)) {
        private bool PasswordChangeIsSuccess(string currentPassword, string newPassword, string username) {
            try {
                var validated = _membershipService.ValidateUser(username, currentPassword, out List<LocalizedString> validationErrors);
                if (validated != null) {
                    _userEventHandler.ChangingPassword(validated, newPassword);
                    _membershipService.SetPassword(validated, newPassword);
                    _userEventHandler.ChangedPassword(validated, newPassword);
                    // if security settings tell to invalidate on password change fire the LoggedOut event
                    if (_orchardServices.WorkContext
                        .CurrentSite.As<SecuritySettingsPart>()
                        .ShouldInvalidateAuthOnPasswordChanged) {
                        _userEventHandler.LoggedOut(validated);
                    return true;
            } catch {
                ModelState.AddModelError("_FORM", T("The current password is incorrect or the new password is invalid."));
                return false;
            // unknown error
            ModelState.AddModelError("_FORM", T("The current password is incorrect or the new password is invalid."));
            return false;
        public ActionResult LostPassword(string nonce) {
            if (_userService.ValidateLostPassword(nonce) == null) {
        public ActionResult LostPassword(string nonce, string newPassword, string confirmPassword) {
            IUser user;
            if ((user = _userService.ValidateLostPassword(nonce)) == null) {
                return Redirect("~/");
            if (!ValidatePassword(newPassword, confirmPassword, user)) {
            _userEventHandler.ChangingPassword(user, newPassword);
            _membershipService.SetPassword(user, newPassword);
            _userEventHandler.ChangedPassword(user, newPassword);
            return RedirectToAction("ChangePasswordSuccess");
        public ActionResult ChangePasswordSuccess() {
        public ActionResult RegistrationPending() {
        public ActionResult ChallengeEmailSent() {
        public ActionResult ChallengeEmailSuccess() {
        public ActionResult ChallengeEmailFail() {
        public ActionResult ChallengeEmail(string nonce) {
            var user = _userService.ValidateChallenge(nonce);
            if (user != null) {
                _userEventHandler.ConfirmedEmail(user);
                return RedirectToAction("ChallengeEmailSuccess");
            return RedirectToAction("ChallengeEmailFail");
        #region Validation Methods
        private bool ValidateChangePassword(string currentPassword, string newPassword, string confirmPassword, IUser user) {
            if (string.IsNullOrEmpty(currentPassword)) {
                ModelState.AddModelError("currentPassword", T("You must specify a current password."));
            if (string.Equals(currentPassword, newPassword, StringComparison.Ordinal)) {
                ModelState.AddModelError("newPassword", T("The new password must be different from the current password."));
            return ValidatePassword(newPassword, confirmPassword, user);
        private IUser ValidateLogOn(string userNameOrEmail, string password) {
            bool validate = true;
            if (string.IsNullOrEmpty(userNameOrEmail)) {
                ModelState.AddModelError("userNameOrEmail", T("You must specify a username or e-mail."));
                validate = false;
            // Here we don't do the "full" validation of the password, because policies may have
            // changed since its creation and that should not prevent a user from logging in.
            if (string.IsNullOrEmpty(password)) {
                ModelState.AddModelError("password", T("You must specify a password."));
            if (!validate)
                return null;
            var validationResult = _membershipService.ValidateUser(userNameOrEmail, password, out List<LocalizedString> validationErrors);
            if (validationResult == null) {
                _userEventHandler.LogInFailed(userNameOrEmail, password);
            foreach (var error in validationErrors) {
                ModelState.AddModelError("_FORM", error);
            return validationResult;
        private bool ValidateRegistration(string userName, string email, string password, string confirmPassword) {
            var context = new AccountValidationContext {
                UserName = userName,
                Email = email,
                Password = password
            };
            _accountValidationService.ValidateUserName(context);
            _accountValidationService.ValidateEmail(context);
            // Don't do the other validations if we already know we failed
            if (!context.ValidationSuccessful) {
                foreach (var error in context.ValidationErrors) {
                    ModelState.AddModelError(error.Key, error.Value);
            if (!_userService.VerifyUserUnicity(userName, email)) {
                // Not a new registration, but perhaps we already have that user and they
                // haven't validated their email address. This doesn't care whether there
                // were other issues with the registration attempt that caused its validation
                // to fail: if the user exists and still has to confirm their email, we show
                // a link to the action from which the challenge email is sent again.
                var membershipSettings = _membershipService.GetSettings();
                if (membershipSettings.UsersMustValidateEmail) {
                    var user = _userService.GetUserByNameOrEmail(email);
                    if (user == null) {
                        user = _userService.GetUserByNameOrEmail(userName);
                    if (user != null && user.EmailStatus == UserStatus.Pending) {
                        // We can't have links in the "text" of a ModelState Error. We are using a notifier
                        // to provide the user with an option to ask for a new challenge email.
                        _orchardServices.Notifier.Warning(
                            T("User with that username and/or email already exists. Follow <a href=\"{0}\">this link</a> if you want to receive a new email to validate your address.",
                                Url.Action(actionName: "RequestChallengeEmail", routeValues: new { email = email })));
                        // In creating the link above we use the email that was written in the form
                        // rather than the actual user's email address to prevent exploiting this
                        // for information discovery.
                // We should add the error to the ModelState anyway.
                context.ValidationErrors.Add("userExists", T("User with that username and/or email already exists."));
            _accountValidationService.ValidatePassword(context);
            if (!string.Equals(password, confirmPassword, StringComparison.Ordinal)) {
                context.ValidationErrors.Add("_FORM", T("The new password and confirmation password do not match."));
            return ModelState.IsValid;
        private bool ValidatePassword(string password, IUser user) {
                Password = password,
                User = user
            var result = _accountValidationService.ValidatePassword(context);
            if (!result) {
            return result;
        private bool ValidatePassword(string password, string confirmPassword, IUser user) {
                ModelState.AddModelError("_FORM", T("The new password and confirmation password do not match."));
            return ValidatePassword(password, user);
        private static string ErrorCodeToString(MembershipCreateStatus createStatus) {
            // See http://msdn.microsoft.com/en-us/library/system.web.security.membershipcreatestatus.aspx for
            // a full list of status codes.
            switch (createStatus) {
                case MembershipCreateStatus.DuplicateUserName:
                    return "Username already exists. Please enter a different user name.";
                case MembershipCreateStatus.DuplicateEmail:
                    return "A username for that e-mail address already exists. Please enter a different e-mail address.";
                case MembershipCreateStatus.InvalidPassword:
                    return "The password provided is invalid. Please enter a valid password value.";
                case MembershipCreateStatus.InvalidEmail:
                    return "The e-mail address provided is invalid. Please check the value and try again.";
                case MembershipCreateStatus.InvalidAnswer:
                    return "The password retrieval answer provided is invalid. Please check the value and try again.";
                case MembershipCreateStatus.InvalidQuestion:
                    return "The password retrieval question provided is invalid. Please check the value and try again.";
                case MembershipCreateStatus.InvalidUserName:
                    return "The user name provided is invalid. Please check the value and try again.";
                case MembershipCreateStatus.ProviderError:
                    return
                        "The authentication provider returned an error. Please verify your entry and try again. If the problem persists, please contact your system administrator.";
                case MembershipCreateStatus.UserRejected:
                        "The user creation request has been canceled. Please verify your entry and try again. If the problem persists, please contact your system administrator.";
                default:
                        "An unknown error occurred. Please verify your entry and try again. If the problem persists, please contact your system administrator.";
        #endregion
    }
}
