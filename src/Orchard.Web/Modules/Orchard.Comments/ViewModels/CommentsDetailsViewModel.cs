using Orchard.ContentManagement;
using Orchard.Security;
using Orchard.UI.Admin;
using Orchard.DisplayManagement;
using Orchard.Localization;
using Orchard.Services;
using System.Web.Mvc;
using Orchard.Mvc.Filters;
﻿using System.Collections.Generic;

namespace Orchard.Comments.ViewModels {
    public class CommentsDetailsViewModel {
        public IList<CommentEntry> Comments { get; set; }
        public CommentDetailsOptions Options { get; set; }
        public string DisplayNameForCommentedItem { get; set; }
        public int CommentedItemId { get; set; }
        public bool CommentsClosedOnItem { get; set; }
    }
    public class CommentDetailsOptions {
        public CommentDetailsFilter Filter { get; set; }
        public CommentDetailsBulkAction BulkAction { get; set; }
    public enum CommentDetailsBulkAction {
        None,
        Unapprove,
        Approve,
        Delete
    public enum CommentDetailsFilter {
        All,
        Pending,
        Approved
}
