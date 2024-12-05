using Orchard.ContentManagement;
using Orchard.Security;
using Orchard.UI.Admin;
using Orchard.DisplayManagement;
using Orchard.Localization;
using Orchard.Services;
using System.Web.Mvc;
using Orchard.Mvc.Filters;
﻿using System;
using Orchard.Blogs.Models;
using Orchard.Blogs.Services;
using Orchard.Commands;
using Orchard.Widgets.Services;

namespace Orchard.Blogs.Commands {
    public class BlogWidgetCommands : DefaultOrchardCommandHandler {
        private readonly IWidgetCommandsService _widgetCommandsService;
        private readonly IBlogService _blogService;
        private readonly IContentManager _contentManager;
        private BlogPart blog;
        public BlogWidgetCommands(
            IWidgetCommandsService widgetCommandsService, 
            IBlogService blogService,
            IContentManager contentManager) {
            _widgetCommandsService = widgetCommandsService;
            _blogService = blogService;
            _contentManager = contentManager;
            RenderTitle = true;
        }
        [OrchardSwitch]
        public string Title { get; set; }
        public string Name { get; set; }
        public bool RenderTitle { get; set; }
        public string Zone { get; set; }
        public string Position { get; set; }
        public string Layer { get; set; }
        public string Identity { get; set; }
        public string Owner { get; set; }
        public string BlogPath { get; set; }
        public int BlogId { get; set; }
        public string Count { get; set; }
        [CommandName("blog widget create recentblogposts")]
        [CommandHelp("blog widget create recentblogposts /Title:<title> /Name:<name> /Zone:<zone> /Position:<position> /Layer:<layer> (/BlogId:<id> | /BlogPath:<path>) [/Identity:<identity>] [/RenderTitle:true|false] [/Owner:<owner>] [/Count:<count>]\r\n\t" + "Creates a new widget")]
        [OrchardSwitches("Title,Name,Zone,Position,Layer,BlogId,BlogPath,Identity,Owner,RenderTitle,Count")]
        public void CreateRecentBlogPostsWidget() {
            var type = "RecentBlogPosts";
            // Check any custom parameters that could cause creating the widget to fail.
            blog = GetBlog(BlogId, BlogPath);
            if (blog == null) {
                Context.Output.WriteLine(T("Creating {0} widget failed: blog was not found.", type));
                return;
            }
            // Create the widget using the standard parameters.
            var widget = _widgetCommandsService.CreateBaseWidget(
                Context, type, Title, Name, Zone, Position, Layer, Identity, RenderTitle, Owner, null, false, null);
            if (widget == null) {
            // Publish the successfully created widget.
            widget.As<RecentBlogPostsPart>().BlogId = blog.Id;
            // Setting count to 0 means all posts. It's an optional parameter and defaults to 5.
            if (!string.IsNullOrWhiteSpace(Count)) {
                int CountAsNumber = 0;
                if (Int32.TryParse(Count, out CountAsNumber)) {
                    widget.As<RecentBlogPostsPart>().Count = CountAsNumber;
                }
            _widgetCommandsService.Publish(widget);
            Context.Output.WriteLine(T("{0} widget created successfully.", type).Text);
        [CommandName("blog widget create blogarchives")]
        [CommandHelp("blog widget create blogarchives /Title:<title> /Name:<name> /Zone:<zone> /Position:<position> /Layer:<layer> (/BlogId:<id> | /BlogPath:<path>) [/Identity:<identity>] [/RenderTitle:true|false] [/Owner:<owner>]\r\n\t" + "Creates a new widget")]
        [OrchardSwitches("Title,Name,Zone,Position,Layer,BlogId,BlogPath,Identity,Owner,RenderTitle")]
        public void CreateBlogArchivesWidget() {
            var type = "BlogArchives";
            // Set the custom parameters.
            widget.As<BlogArchivesPart>().BlogId = blog.Id;
        private BlogPart GetBlog(int blogId, string blogPath) {
            return _contentManager.Get<BlogPart>(blogId) ?? _blogService.Get(blogPath);
    }
}
