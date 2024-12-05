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
using System.Linq;
using System.Web;
using Orchard.ContentManagement.Aspects;
using Orchard.ContentManagement.MetaData;
using Orchard.ContentManagement.MetaData.Models;
using Orchard.Core.Common.Models;
using Orchard.Core.Contents;
using Orchard.Core.Contents.Settings;
using Orchard.CustomForms.Activities;
using Orchard.CustomForms.Models;
using Orchard.CustomForms.Rules;
using Orchard.Data;
using Orchard.Logging;
using Orchard.Mvc;
using Orchard.Mvc.Extensions;
using Orchard.Security.Permissions;
using Orchard.Themes;
using Orchard.Tokens;
using Orchard.UI.Notify;
using Orchard.Workflows.Services;

namespace Orchard.CustomForms.Controllers {
    [Themed(true)]
    [ValidateInput(false)]
    public class ItemController : Controller, IUpdateModel {
        private readonly IContentDefinitionManager _contentDefinitionManager;
        private readonly IContentManager _contentManager;
        private readonly ITransactionManager _transactionManager;
        private readonly IRulesManager _rulesManager;
        private readonly ITokenizer _tokenizer;
        private readonly IWorkflowManager _workflowManager;
        public ItemController(
            IOrchardServices orchardServices,
            IContentDefinitionManager contentDefinitionManager,
            IContentManager contentManager,
            ITransactionManager transactionManager,
            IShapeFactory shapeFactory,
            IRulesManager rulesManager,
            ITokenizer tokenizer,
            IWorkflowManager workflowManager) {
            Services = orchardServices;
            _contentDefinitionManager = contentDefinitionManager;
            _contentManager = contentManager;
            _transactionManager = transactionManager;
            _rulesManager = rulesManager;
            _tokenizer = tokenizer;
            _workflowManager = workflowManager;
            T = NullLocalizer.Instance;
            Logger = NullLogger.Instance;
            Shape = shapeFactory;
        }
        dynamic Shape { get; set; }
        public IOrchardServices Services { get; private set; }
        public Localizer T { get; set; }
        public ILogger Logger { get; set; }
        public ActionResult Create(int id) {
            var form = _contentManager.Get(id);
            if(form == null || !form.Has<CustomFormPart>()) {
                return HttpNotFound();
            }
            var customForm = form.As<CustomFormPart>();
            // Retrieve the id of the content to edit
            var queryString = Services.WorkContext.HttpContext.Request.QueryString;
            int.TryParse(queryString["contentId"], out int contentId);
            
            ContentItem contentItem;
            if (contentId > 0) {
                contentItem = _contentManager.Get(contentId);
                if (customForm.UseContentTypePermissions && !Services.Authorizer.Authorize(Core.Contents.Permissions.EditContent, contentItem))
                    return new HttpUnauthorizedResult();
            } else {
                contentItem = _contentManager.New(customForm.ContentType);
                if (customForm.UseContentTypePermissions && !Services.Authorizer.Authorize(Core.Contents.Permissions.CreateContent, contentItem))
            if (contentItem == null || contentItem.ContentType != customForm.ContentType)
                return new HttpUnauthorizedResult();
            if (!contentItem.Has<ICommonPart>()) {
                throw new OrchardException(T("The content type must have CommonPart attached"));
            if (!Services.Authorizer.Authorize(Permissions.CreateSubmitPermission(customForm.ContentType), contentItem, T("Cannot create content")))
            var model = _contentManager.BuildEditor(contentItem);
            var routeValues = _contentManager.GetItemMetadata(form).DisplayRouteValues;
                routeValues.Add("contentId", contentId);
          
            model
                .ContentItem(form)
                .ContentId(contentId)
                .ReturnUrl(Url.RouteUrl(routeValues));
            return View(model);
        [HttpPost, ActionName("Create")]
        [FormValueRequired("submit.Save")]
        public ActionResult CreatePOST(int id, int contentId, string returnUrl) {
            return CreatePOST(id, contentId, returnUrl, contentItem => {
                if (!contentItem.Has<IPublishingControlAspect>() && !contentItem.TypeDefinition.Settings.GetModel<ContentTypeSettings>().Draftable)
                    _contentManager.Publish(contentItem);
            });
        [FormValueRequired("submit.Publish")]
        public ActionResult CreateAndPublishPOST(int id, int contentId, string returnUrl) {
            if (form == null || !form.Has<CustomFormPart>()) {
            // pass a dummy content to the authorization check to check for "own" variations
            var dummyContent = _contentManager.New(customForm.ContentType);
            if (!Services.Authorizer.Authorize(Permissions.CreateSubmitPermission(customForm.ContentType), dummyContent, T("Couldn't create content")))
            return CreatePOST(id, contentId, returnUrl, contentItem => _contentManager.Publish(contentItem));
        private ActionResult CreatePOST(int id, int contentId, string returnUrl, Action<ContentItem> conditionallyPublish) {
            if (contentId > 0)
                contentItem = _contentManager.Get(contentId,VersionOptions.DraftRequired);
            else
            if (!Services.Authorizer.Authorize(Permissions.CreateSubmitPermission(customForm.ContentType), contentItem, T("Couldn't create content")))
            if(customForm.SaveContentItem && contentId <= 0)
                _contentManager.Create(contentItem, VersionOptions.Draft);
            var model = _contentManager.UpdateEditor(contentItem, this);
            if (!ModelState.IsValid) {
                _transactionManager.Cancel();
                // if custom form is inside a widget, we display the form itself
                if (form.ContentType == "CustomFormWidget") {
                    foreach (var error in ModelState.Values.SelectMany(m => m.Errors).Select(e => e.ErrorMessage)) {
                        Services.Notifier.Error(new LocalizedString(HttpUtility.HtmlEncode(error)));
                    }
                    // save the updated editor shape into TempData to survive a redirection and keep the edited values
                    TempData["CustomFormWidget.InvalidCustomFormState"] = model;
                    if (returnUrl != null) {
                        return this.RedirectLocal(returnUrl);
                }
                var routeValues = _contentManager.GetItemMetadata(form).DisplayRouteValues;
                if (contentId > 0) {
                    routeValues.Add("contentId", contentId);
                model
                    .ContentItem(form)
                    .ContentId(contentId)
                    .ReturnUrl(Url.RouteUrl(routeValues));
                return View(model);
            contentItem.As<ICommonPart>().Container = customForm.ContentItem;
            // save the submitted form
            if (customForm.SaveContentItem) {
                conditionallyPublish(contentItem);
                // Refresh content item
                contentItem = _contentManager.Get(contentItem.Id, VersionOptions.Latest);
            // triggers any event
            _rulesManager.TriggerEvent("CustomForm", "Submitted",
                    () => new Dictionary<string, object> { { "Content", contentItem } });
            // trigger any workflow
            _workflowManager.TriggerEvent(FormSubmittedActivity.EventName, contentItem,
                    () => new Dictionary<string, object> { { "Content", contentItem} , { "CustomForm", customForm.ContentItem } });
            if (customForm.Redirect) {
                returnUrl = _tokenizer.Replace(customForm.RedirectUrl, new Dictionary<string, object> { { "Content", contentItem } });
            // writes a confirmation message
            if (customForm.CustomMessage) {
                if (!String.IsNullOrWhiteSpace(customForm.Message)) {
                    Services.Notifier.Success(T(customForm.Message));
            var referrer = Request.UrlReferrer != null ? Request.UrlReferrer.ToString() : null;
            return this.RedirectLocal(returnUrl, () => this.RedirectLocal(referrer, () => Redirect(Request.RawUrl)));
        bool IUpdateModel.TryUpdateModel<TModel>(TModel model, string prefix, string[] includeProperties, string[] excludeProperties) {
            return TryUpdateModel(model, prefix, includeProperties, excludeProperties);
        void IUpdateModel.AddModelError(string key, LocalizedString errorMessage) {
            ModelState.AddModelError(key, errorMessage.ToString());
    }
}
