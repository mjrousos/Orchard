using Orchard.ContentManagement;
using Orchard.Security;
using Orchard.UI.Admin;
using Orchard.DisplayManagement;
using Orchard.Localization;
using Orchard.Services;
using System.Web.Mvc;
using Orchard.Mvc.Filters;
﻿using Orchard.Comments.Models;

namespace Orchard.Comments.Services {
    public class CommentsCountProcessor : ICommentsCountProcessor {
        private readonly IContentManager _contentManager;
        public CommentsCountProcessor(
            IContentManager contentManager) {
            _contentManager = contentManager;
        }
        public void Process(int commentsPartId) {
            var commentsCount = _contentManager
                .Query<CommentPart, CommentPartRecord>()
                .Where(x => x.Status == CommentStatus.Approved && x.CommentedOn == commentsPartId)
                .Count();
            var commentsPart = _contentManager.Get<CommentsPart>(commentsPartId);
            if (commentsPart != null) {
                commentsPart.CommentsCount = commentsCount;
            }
    }
}
