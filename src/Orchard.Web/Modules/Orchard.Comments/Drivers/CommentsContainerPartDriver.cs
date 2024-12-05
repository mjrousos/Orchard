using Orchard.ContentManagement;
using Orchard.Security;
using Orchard.UI.Admin;
using Orchard.DisplayManagement;
using Orchard.Localization;
using Orchard.Services;
using System.Web.Mvc;
using Orchard.Mvc.Filters;
using System;
using Orchard.Comments.Models;
using Orchard.Comments.Services;
using Orchard.ContentManagement.Drivers;

namespace Orchard.Comments.Drivers {
    public class CommentsContainerPartDriver : ContentPartDriver<CommentsContainerPart> {
        private readonly ICommentService _commentService;
        public CommentsContainerPartDriver(ICommentService commentService) {
            _commentService = commentService;
        }
        protected override DriverResult Display(CommentsContainerPart part, string displayType, dynamic shapeHelper) {
            var commentsForCommentedContent = _commentService.GetCommentsForContainer(part.ContentItem.Id);
            Func<int> pendingCount = () => commentsForCommentedContent.Where(x => x.Status == CommentStatus.Pending).Count();
            Func<int> approvedCount = () => commentsForCommentedContent.Where(x => x.Status == CommentStatus.Approved).Count();
            
            return Combined(
                ContentShape("Parts_Comments_Count",
                    () => shapeHelper.Parts_Comments_Count(CommentCount: approvedCount(), PendingCount: pendingCount())),
                ContentShape("Parts_Comments_Count_SummaryAdmin",
                    () => shapeHelper.Parts_Comments_Count_SummaryAdmin(CommentCount: approvedCount(), PendingCount: pendingCount()))
                );
    }
}
