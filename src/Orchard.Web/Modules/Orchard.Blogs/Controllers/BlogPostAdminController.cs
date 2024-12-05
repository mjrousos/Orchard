using Orchard.ContentManagement;
using Orchard.Security;
using Orchard.UI.Admin;
using Orchard.DisplayManagement;
using Orchard.Localization;
using Orchard.Services;
using System.Web.Mvc;
using Orchard.Mvc.Filters;
using System;
using System.Linq;
using System.Reflection;
using Orchard.Blogs.Extensions;
using Orchard.Blogs.Models;
using Orchard.Blogs.Services;
using Orchard.ContentManagement.Aspects;
using Orchard.Core.Contents.Settings;
using Orchard.Mvc;
using Orchard.Mvc.AntiForgery;
using Orchard.Mvc.Extensions;
using Orchard.UI.Notify;

namespace Orchard.Blogs.Controllers {
    /// <summary>
    /// TODO: (PH:Autoroute) This replicates a whole lot of Core.Contents functionality. All we actually need to do is take the BlogId from the query string in the BlogPostPartDriver, and remove
    /// helper extensions from UrlHelperExtensions.
    /// </summary>
    [ValidateInput(false), Admin]
    public class BlogPostAdminController : Controller, IUpdateModel {
        private readonly IBlogService _blogService;
        private readonly IBlogPostService _blogPostService;
        public BlogPostAdminController(IOrchardServices services, IBlogService blogService, IBlogPostService blogPostService) {
            Services = services;
            _blogService = blogService;
            _blogPostService = blogPostService;
            T = NullLocalizer.Instance;
        }
        public IOrchardServices Services { get; set; }
        public Localizer T { get; set; }
        public ActionResult Create(int blogId) {
            var blog = _blogService.Get(blogId, VersionOptions.Latest).As<BlogPart>();
            if (blog == null)
                return HttpNotFound();
            var blogPost = Services.ContentManager.New<BlogPostPart>("BlogPost");
            blogPost.BlogPart = blog;
            if (!Services.Authorizer.Authorize(Permissions.EditBlogPost, blogPost, T("Not allowed to create blog post")))
                return new HttpUnauthorizedResult();
            var model = Services.ContentManager.BuildEditor(blogPost);
            
            return View(model);
        [HttpPost, ActionName("Create")]
        [FormValueRequired("submit.Save")]
        public ActionResult CreatePOST(int blogId) {
            return CreatePOST(blogId, false);
        [FormValueRequired("submit.Publish")]
        public ActionResult CreateAndPublishPOST(int blogId) {
            if (!Services.Authorizer.Authorize(Permissions.PublishOwnBlogPost, T("Couldn't create content")))
            return CreatePOST(blogId, true);
        private ActionResult CreatePOST(int blogId, bool publish = false) {
            if (!Services.Authorizer.Authorize(Permissions.EditBlogPost, blogPost, T("Couldn't create blog post")))
            Services.ContentManager.Create(blogPost, VersionOptions.Draft);
            var model = Services.ContentManager.UpdateEditor(blogPost, this);
            if (!ModelState.IsValid) {
                Services.TransactionManager.Cancel();
                return View(model);
            }
            if (publish) {
                if (!Services.Authorizer.Authorize(Permissions.PublishBlogPost, blogPost.ContentItem, T("Couldn't publish blog post")))
                    return new HttpUnauthorizedResult();
                Services.ContentManager.Publish(blogPost.ContentItem);
            Services.Notifier.Success(T("Your {0} has been created.", blogPost.TypeDefinition.DisplayName));
            return Redirect(Url.BlogPostEdit(blogPost));
        public ActionResult CreateWithoutBlog() {
            var blogs = _blogService.Get().ToArray();
            if (blogs.Count() == 0) {
                Services.Notifier.Warning(T("To create a BlogPost you need to create a blog first. You have been redirected to the Blog creation page."));
                return RedirectToAction("Create", "BlogAdmin", new { area = "Orchard.Blogs" });
            } else {
                Services.Notifier.Warning(T("To create a BlogPost you need to choose a blog first. You have been redirected to the Blog selection page."));
                return RedirectToAction("List", "BlogAdmin", new { area = "Orchard.Blogs" });
        //todo: the content shape template has extra bits that the core contents module does not (remove draft functionality)
        //todo: - move this extra functionality there or somewhere else that's appropriate?
        public ActionResult Edit(int blogId, int postId) {
            var blog = _blogService.Get(blogId, VersionOptions.Latest);
            var post = _blogPostService.Get(postId, VersionOptions.Latest);
            if (post == null)
            if (!Services.Authorizer.Authorize(Permissions.EditBlogPost, post, T("Couldn't edit blog post")))
            var model = Services.ContentManager.BuildEditor(post);
        [HttpPost, ActionName("Edit")]
        public ActionResult EditPOST(int blogId, int postId, string returnUrl) {
            return EditPOST(blogId, postId, returnUrl, contentItem => {
                if (!contentItem.Has<IPublishingControlAspect>() && !contentItem.TypeDefinition.Settings.GetModel<ContentTypeSettings>().Draftable)
                    Services.ContentManager.Publish(contentItem);
            });
        public ActionResult EditAndPublishPOST(int blogId, int postId, string returnUrl) {
            // Get draft (create a new version if needed)
            var blogPost = _blogPostService.Get(postId, VersionOptions.DraftRequired);
            if (blogPost == null)
            if (!Services.Authorizer.Authorize(Permissions.PublishBlogPost, blogPost, T("Couldn't publish blog post")))
            return EditPOST(blogId, postId, returnUrl, contentItem => Services.ContentManager.Publish(contentItem));
        public ActionResult EditPOST(int blogId, int postId, string returnUrl, Action<ContentItem> conditionallyPublish) {
            if (!Services.Authorizer.Authorize(Permissions.EditBlogPost, blogPost, T("Couldn't edit blog post")))
            // Validate form input
            conditionallyPublish(blogPost.ContentItem);
            Services.Notifier.Success(T("Your {0} has been saved.", blogPost.TypeDefinition.DisplayName));
            return this.RedirectLocal(returnUrl, Url.BlogPostEdit(blogPost));
        [ValidateAntiForgeryTokenOrchard]
        public ActionResult DiscardDraft(int id) {
            // get the current draft version
            var draft = Services.ContentManager.Get(id, VersionOptions.Draft);
            if (draft == null) {
                Services.Notifier.Warning(T("There is no draft to discard."));
                return RedirectToEdit(id);
            // check edit permission
            if (!Services.Authorizer.Authorize(Permissions.EditBlogPost, draft, T("Couldn't discard blog post draft")))
            // locate the published revision to revert onto
            var published = Services.ContentManager.Get(id, VersionOptions.Published);
            if (published == null) {
                Services.Notifier.Error(T("Can not discard draft on unpublished blog post."));
                return RedirectToEdit(draft);
            // marking the previously published version as the latest
            // has the effect of discarding the draft but keeping the history
            draft.VersionRecord.Latest = false;
            published.VersionRecord.Latest = true;
            Services.Notifier.Success(T("Blog post draft version discarded"));
            return RedirectToEdit(published);
        ActionResult RedirectToEdit(int id) {
            return RedirectToEdit(Services.ContentManager.GetLatest<BlogPostPart>(id));
        ActionResult RedirectToEdit(IContent item) {
            if (item == null || item.As<BlogPostPart>() == null)
            return RedirectToAction("Edit", new { BlogId = item.As<BlogPostPart>().BlogPart.Id, PostId = item.ContentItem.Id });
        public ActionResult Delete(int blogId, int postId) {
            //refactoring: test PublishBlogPost/PublishBlogPost in addition if published
            if (!Services.Authorizer.Authorize(Permissions.DeleteBlogPost, post, T("Couldn't delete blog post")))
            _blogPostService.Delete(post);
            Services.Notifier.Success(T("Blog post was successfully deleted"));
            return Redirect(Url.BlogForAdmin(blog.As<BlogPart>()));
        public ActionResult Publish(int blogId, int postId) {
            if (!Services.Authorizer.Authorize(Permissions.PublishBlogPost, post, T("Couldn't publish blog post")))
            _blogPostService.Publish(post);
            Services.Notifier.Success(T("Blog post successfully published."));
        public ActionResult Unpublish(int blogId, int postId) {
            if (!Services.Authorizer.Authorize(Permissions.PublishBlogPost, post, T("Couldn't unpublish blog post")))
            _blogPostService.Unpublish(post);
            Services.Notifier.Success(T("Blog post successfully unpublished."));
        bool IUpdateModel.TryUpdateModel<TModel>(TModel model, string prefix, string[] includeProperties, string[] excludeProperties) {
            return TryUpdateModel(model, prefix, includeProperties, excludeProperties);
        void IUpdateModel.AddModelError(string key, LocalizedString errorMessage) {
            ModelState.AddModelError(key, errorMessage.ToString());
    }
}
