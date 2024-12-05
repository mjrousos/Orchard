using Orchard.ContentManagement;
using Orchard.Security;
using Orchard.UI.Admin;
using Orchard.DisplayManagement;
using Orchard.Localization;
using Orchard.Services;
using System.Web.Mvc;
using Orchard.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Orchard.Comments.Models;
using Orchard.Logging;
using Orchard.Mvc;
using Orchard.Mvc.Extensions;
using Orchard.UI.Navigation;
using Orchard.UI.Notify;
using Orchard.Comments.ViewModels;
using Orchard.Comments.Services;

namespace Orchard.Comments.Controllers {
    using Orchard.Settings;
    [ValidateInput(false)]
    public class AdminController : Controller, IUpdateModel {
        private readonly IOrchardServices _orchardServices;
        private readonly ICommentService _commentService;
        private readonly ISiteService _siteService;
        private readonly IContentManager _contentManager;
        public AdminController(
            IOrchardServices orchardServices,
            ICommentService commentService,
            ISiteService siteService,
            IShapeFactory shapeFactory) {
            _orchardServices = orchardServices;
            _commentService = commentService;
            _siteService = siteService;
            _contentManager = _orchardServices.ContentManager;
            Logger = NullLogger.Instance;
            T = NullLocalizer.Instance;
            Shape = shapeFactory;
        }
        public ILogger Logger { get; set; }
        public Localizer T { get; set; }
        dynamic Shape { get; set; }
        public ActionResult Index(CommentIndexOptions options, PagerParameters pagerParameters) {
            Pager pager = new Pager(_siteService.GetSiteSettings(), pagerParameters);
            // Default options
            if (options == null)
                options = new CommentIndexOptions();
            // Filtering
            IContentQuery<CommentPart, CommentPartRecord> commentsQuery;
            switch (options.Filter) {
                case CommentIndexFilter.All:
                    commentsQuery = _commentService.GetComments();
                    break;
                case CommentIndexFilter.Approved:
                    commentsQuery = _commentService.GetComments(CommentStatus.Approved);
                case CommentIndexFilter.Pending:
                    commentsQuery = _commentService.GetComments(CommentStatus.Pending);
                default:
                    throw new ArgumentOutOfRangeException();
            }
            var pagerShape = Shape.Pager(pager).TotalItemCount(commentsQuery.Count());
            var entries = commentsQuery
                .OrderByDescending<CommentPartRecord>(cpr => cpr.CommentDateUtc)
                .Slice(pager.GetStartIndex(), pager.PageSize)
                .ToList()
                .Select(CreateCommentEntry);
            var model = new CommentsIndexViewModel {
                Comments = entries.ToList(),
                Options = options,
                Pager = pagerShape
            };
            return View(model);
        [HttpPost]
        [FormValueRequired("submit.BulkEdit")]
        public ActionResult Index(FormCollection input) {
            var viewModel = new CommentsIndexViewModel { Comments = new List<CommentEntry>(), Options = new CommentIndexOptions() };
            UpdateModel(viewModel);
            IEnumerable<CommentEntry> checkedEntries = viewModel.Comments.Where(c => c.IsChecked);
            switch (viewModel.Options.BulkAction) {
                case CommentIndexBulkAction.None:
                case CommentIndexBulkAction.Unapprove:
                    if (!_orchardServices.Authorizer.Authorize(Permissions.ManageComments, T("Couldn't moderate comment")))
                        return new HttpUnauthorizedResult();
                    //TODO: Transaction
                    foreach (CommentEntry entry in checkedEntries) {
                        _commentService.UnapproveComment(entry.Comment.Id);
                    }
                case CommentIndexBulkAction.Approve:
                        _commentService.ApproveComment(entry.Comment.Id);
                case CommentIndexBulkAction.Delete:
                    if (!_orchardServices.Authorizer.Authorize(Permissions.ManageComments, T("Couldn't delete comment")))
                        _commentService.DeleteComment(entry.Comment.Id);
            return RedirectToAction("Index");
        public ActionResult Details(int id, CommentDetailsOptions options) {
                options = new CommentDetailsOptions();
            IContentQuery<CommentPart, CommentPartRecord> comments;
                case CommentDetailsFilter.All:
                    comments = _commentService.GetCommentsForCommentedContent(id);
                case CommentDetailsFilter.Approved:
                    comments = _commentService.GetCommentsForCommentedContent(id, CommentStatus.Approved);
                case CommentDetailsFilter.Pending:
                    comments = _commentService.GetCommentsForCommentedContent(id, CommentStatus.Pending);
            var entries = comments.List().Select(comment => CreateCommentEntry(comment)).ToList();
            var model = new CommentsDetailsViewModel {
                Comments = entries,
                DisplayNameForCommentedItem = _commentService.GetDisplayForCommentedContent(id) == null ? "" : _commentService.GetDisplayForCommentedContent(id).DisplayText,
                CommentedItemId = id,
                CommentsClosedOnItem = _commentService.CommentsDisabledForCommentedContent(id),
        public ActionResult Details(FormCollection input) {
            var viewModel = new CommentsDetailsViewModel { Comments = new List<CommentEntry>(), Options = new CommentDetailsOptions() };
                case CommentDetailsBulkAction.None:
                case CommentDetailsBulkAction.Unapprove:
                case CommentDetailsBulkAction.Approve:
                case CommentDetailsBulkAction.Delete:
        public ActionResult Disable(int commentedItemId, string returnUrl) {
            if (!_orchardServices.Authorizer.Authorize(Permissions.ManageComments, T("Couldn't disable comments")))
                return new HttpUnauthorizedResult();
            _commentService.DisableCommentsForCommentedContent(commentedItemId);
            return this.RedirectLocal(returnUrl, () => RedirectToAction("Index"));
        public ActionResult Enable(int commentedItemId, string returnUrl) {
            if (!_orchardServices.Authorizer.Authorize(Permissions.ManageComments, T("Couldn't enable comments")))
            _commentService.EnableCommentsForCommentedContent(commentedItemId);
        public ActionResult Edit(int id) {
            var commentPart = _contentManager.Get<CommentPart>(id);
            if (commentPart == null)
                return new HttpNotFoundResult();
            dynamic editorShape = _contentManager.BuildEditor(commentPart);
            return View(editorShape);
        public ActionResult Edit(int id, FormCollection input) {
            if (!_orchardServices.Authorizer.Authorize(Permissions.ManageComments, T("Couldn't edit comment")))
            var editorShape = _contentManager.UpdateEditor(commentPart, this);
            if (!ModelState.IsValid) {
                foreach (var error in ModelState.Values.SelectMany(m => m.Errors).Select(e => e.ErrorMessage)) {
                    _orchardServices.Notifier.Error(T(error));
                }
                TempData["Comments.InvalidCommentEditorShape"] = editorShape;
        public ActionResult Approve(int id, string returnUrl) {
            if (!_orchardServices.Authorizer.Authorize(Permissions.ManageComments, T("Couldn't approve comment")))
            int commentedOn = commentPart.Record.CommentedOn;
            _commentService.ApproveComment(id);
            return this.RedirectLocal(returnUrl, () => RedirectToAction("Details", new { id = commentedOn }));
        public ActionResult Unapprove(int id, string returnUrl) {
            if (!_orchardServices.Authorizer.Authorize(Permissions.ManageComments, T("Couldn't unapprove comment")))
            _commentService.UnapproveComment(id);
        public ActionResult Delete(int id, string returnUrl) {
            if (!_orchardServices.Authorizer.Authorize(Permissions.ManageComments, T("Couldn't delete comment")))
            _commentService.DeleteComment(id);
        private CommentEntry CreateCommentEntry(CommentPart item) {
            return new CommentEntry {
                Comment = item.Record,
                CommentedOn = _commentService.GetCommentedContent(item.CommentedOn),
                IsChecked = false,
        bool IUpdateModel.TryUpdateModel<TModel>(TModel model, string prefix, string[] includeProperties, string[] excludeProperties) {
            return TryUpdateModel(model, prefix, includeProperties, excludeProperties);
        void IUpdateModel.AddModelError(string key, LocalizedString errorMessage) {
            ModelState.AddModelError(key, errorMessage.ToString());
    }
}
